namespace FinanceManagementSystem
{
    /// <summary>
    /// Base class representing a general account
    /// Provides core account functionality with virtual methods for extensibility
    /// </summary>
    public class Account
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; protected set; }

        /// <summary>
        /// Constructor to initialize account with account number and initial balance
        /// </summary>
        /// <param name="accountNumber">Unique account identifier</param>
        /// <param name="initialBalance">Starting balance for the account</param>
        public Account(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        /// <summary>
        /// Virtual method to apply a transaction to the account
        /// Can be overridden by derived classes for specific behavior
        /// </summary>
        /// <param name="transaction">Transaction to be applied</param>
        public virtual void ApplyTransaction(Transaction transaction)
        {
            Balance -= transaction.Amount;
            Console.WriteLine($"Transaction applied to Account {AccountNumber}");
            Console.WriteLine($"Amount deducted: ${transaction.Amount:F2}");
            Console.WriteLine($"New balance: ${Balance:F2}\n");
        }
    }
}
