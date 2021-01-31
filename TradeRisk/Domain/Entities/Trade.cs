using TradeRisk.Domain.Contracts;

namespace TradeRisk.Domain.Entities
{
    /// <inheritdoc />
    public class Trade : ITrade
    {
        /// <inheritdoc />
        public double Value { get; }

        /// <inheritdoc />
        public string ClientSector { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">Value of a transaction.</param>
        /// <param name="clientSector">Sector of transaction client.</param>
        public Trade(double value, string clientSector)
        {
            Value = value;
            ClientSector = clientSector;
        }
    }
}
