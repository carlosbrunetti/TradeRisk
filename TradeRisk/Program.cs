using TradeRisk.Domain.Contracts;
using TradeRisk.Domain.Entities;
using TradeRisk.Services;
using System;
using System.Collections.Generic;

namespace TradeRisk
{
    public class Program
    {
        /// <summary>
        /// The application entry point.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            // Prepare for run.
            var trades = _populateTrades();
            var tradeAnalysisService = new TradeAnalysisService(); // This should be controlled by a dependency injection system.

            // Evaluate risks.
            var evaluatedRiskCategories = tradeAnalysisService.EvaluateRiskCategories(trades);            

            // Display
            foreach (var category in evaluatedRiskCategories)
            {
                Console.WriteLine(category);
            }

            // Wait for user to finish.
            Console.ReadKey();
        }

        /// <summary>
        /// Populate the trades that will be evaluated.
        /// </summary>
        /// <returns>Collection of trades.</returns>
        private static IList<ITrade> _populateTrades()
        {
            // This could be loaded from a file or a service in a realistic scenario.
            return new List<ITrade>()
            {
               new Trade(2000000, "Private"),
               new Trade(400000, "Public"),
               new Trade(500000, "Public"),
               new Trade(3000000, "Public")               
            };
        }       
    }
}
