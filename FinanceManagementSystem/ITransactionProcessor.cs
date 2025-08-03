namespace FinanceManagementSystem
{
    /// <summary>
    /// Interface defining the contract for transaction processing
    /// Enables polymorphic behavior for different payment methods
    /// </summary>
    public interface ITransactionProcessor
    {
        void Process(Transaction transaction);
    }
}
