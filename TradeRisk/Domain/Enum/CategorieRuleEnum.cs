namespace TradeRisk.Domain.Enum
{
    /// <summary>
    /// Represents the conditional to compare the trade values
    /// 0 if trade value is less than the rule value
    /// 1 if trade value is greater than the rule value
    /// </summary>
    public enum CategorieRuleEnum
    {
        LESSTHAN = 0,
        GREATERTHAN = 1
    }
}
