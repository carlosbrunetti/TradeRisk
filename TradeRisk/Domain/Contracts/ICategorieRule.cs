
namespace TradeRisk.Domain.Contracts
{
    /// <summary>
    /// Represents the trade's rules
    /// </summary>
    public interface ICategorieRule
    {
        /// <summary>
        /// Rule transaction value
        /// </summary>
        double Value { get; set; }
        /// <summary>
        /// Client Sector PUBLIC/PRIVATE
        /// </summary>
        string ClientSector { get; set; }
        /// <summary>
        /// Trade risk LOWRISK/MEDIUMRISK/HIGHRISK
        /// </summary>
        string Risk { get; set; }
        /// <summary>
        /// Conditional to compare with trade's value
        /// 0 = LESSTHAN and 1 GREATERTHAN
        /// </summary>
        int Conditional { get; set; }
    }
}
