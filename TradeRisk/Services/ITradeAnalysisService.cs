using TradeRisk.Class;
using TradeRisk.Domain.Contracts;
using System.Collections.Generic;

namespace TradeRisk.Services
{
    /// <summary>
    /// Handle the analysis of trade transactions.
    /// </summary>
    public interface ITradeAnalysisService
    {
        /// <summary>
        /// Evaluate a bunch of trades and return it's corresponding categories.
        /// </summary>
        /// <param name="trades">Trades to be evaluated.</param>
        /// <returns>Categories.</returns>
        IList<string> EvaluateRiskCategories(IList<ITrade> trades);
    }
}
