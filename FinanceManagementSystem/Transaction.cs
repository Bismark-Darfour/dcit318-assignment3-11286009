namespace FinanceManagementSystem
{
    /// <summary>
    /// Record type representing financial transaction data
    /// Records provide immutability and value-based equality
    /// </summary>
    public record Transaction(
        int Id,
        DateTime Date,
        decimal Amount,
        string Category
    );
}
