using TradeRisk.Class;
using TradeRisk.Domain.Constants;
using TradeRisk.Domain.Contracts;
using TradeRisk.Domain.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TradeRisk.Services
{
    /// <inheritdoc />
    public class TradeAnalysisService : ITradeAnalysisService
    {
        /// <inheritdoc />
        public IList<string> EvaluateRiskCategories(IList<ITrade> trades)
        {
            var categories = new List<string>();
            var rules = _readFileCategorieRules();
            bool isValid;
            // Evaluate risk for each trade.
            foreach (var trade in trades)
            {
                isValid = false;
                foreach (var rule in rules)
                {
                    if (rule.ClientSector.Equals(trade.ClientSector,StringComparison.InvariantCultureIgnoreCase) && _evaluateRisk(trade,rule))
                    {
                        categories.Add(rule.Risk);
                        isValid = true;
                        break;
                    }
                }
                if (!isValid)
                    // If a trade/rule received is invalid, throw an error is the most appropriated action to fail-fast and raise a red flag for the issue investigation.
                    _riskException(trade.ClientSector);
            }

            return categories;
        }

        /// <summary>
        /// Evaluates the risk for a trade according to sector rules.
        /// </summary>
        /// <param name="trade">Trade to be evaluated.</param>
        /// /// <param name="rule">CategorieRule to be evaluated.</param>
        /// <returns>bool</returns>
        private bool _evaluateRisk(ITrade trade, ICategorieRule rule)
        {
            if (trade.ClientSector.Equals(TradeClientSector.PUBLIC, StringComparison.CurrentCultureIgnoreCase))
            {
                return _evaluateRiskForPublicSector(trade.Value, rule);
            }
            else if (trade.ClientSector.Equals(TradeClientSector.PRIVATE, StringComparison.CurrentCultureIgnoreCase))
            {
                return _evaluateRiskForPrivateSector(trade.Value, rule);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Evaluates the risk for a trade according to private sector rules.
        /// </summary>
        /// <param name="value">trade.value</param>
        /// <param name="categorieRule">CategorieRule</param>
        /// <returns>bool</returns>
        private bool _evaluateRiskForPublicSector(double value, ICategorieRule categorieRule)
        {
            if ((categorieRule.Conditional == (int)CategorieRuleEnum.LESSTHAN && value < categorieRule.Value)
                || (categorieRule.Conditional == (int)CategorieRuleEnum.GREATERTHAN && value > categorieRule.Value))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Evaluates the risk for a trade according to private sector rules.
        /// </summary>
        /// <param name="value">trade.value</param>
        /// <param name="categorieRule">CategorieRule</param>
        /// <returns>bool</returns>
        private bool _evaluateRiskForPrivateSector(double value, ICategorieRule categorieRule)
        {
            if ((categorieRule.Conditional == (int)CategorieRuleEnum.LESSTHAN && value < categorieRule.Value)
                || (categorieRule.Conditional == (int)CategorieRuleEnum.GREATERTHAN && value > categorieRule.Value))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Read a json file to load all rules
        /// </summary>
        /// <returns>List<CategorieRule>></returns>
        private IList<CategorieRule> _readFileCategorieRules()
        {
            List<CategorieRule> list = new List<CategorieRule>();

            var path = string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"\appsettings.json");

            using (StreamReader sr = new StreamReader(path))
            {
                string file = sr.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<CategorieRule>>(file);
            }
            return list;
        }

        /// <summary>
        /// throw an exception if trade/rule is invalid
        /// </summary>
        /// <param name="sector"></param>
        /// <returns>exception if trade/rule is invalid</returns>
        private string _riskException(string sector)
        {
            throw new Exception($"Risk rule evaluation not implemented for sector {sector}");
        }
    }
}
