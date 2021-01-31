using TradeRisk.Domain.Contracts;

namespace TradeRisk.Class
{
    /// <inheritdoc />
    public class CategorieRule : ICategorieRule
    {
        /// <inheritdoc />
        public double Value { get; set; }
        /// <inheritdoc />
        public string ClientSector { get ; set ; }
        /// <inheritdoc />
        public string Risk { get ; set ; }
        /// <inheritdoc />
        public int Conditional { get; set; }
    }
}
