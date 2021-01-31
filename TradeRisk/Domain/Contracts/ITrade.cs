namespace TradeRisk.Domain.Contracts
{
    /// <summary>
    /// Represents a transaction between a bank and a client.
    /// </summary>
    public interface ITrade
    {
        /// <summary>
        /// Transaction value.
        /// </summary>
        double Value { get; }

        /// <summary>
        /// Sector of transaction client (currently available options in <see cref="TradeRisk.Domain.Constants.TradeClientSector"/>).
        /// </summary>
        string ClientSector { get; }
    }
}
