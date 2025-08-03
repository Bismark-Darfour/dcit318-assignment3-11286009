namespace FinanceManagementSystem
{
    /// <summary>
    /// Sealed class representing a savings account with specialized transaction handling
    /// Sealed to prevent further inheritance and maintain controlled behavior
    /// </summary>
    public sealed class SavingsAccount : Account
    {
        /// <summary>
        /// Constructor for SavingsAccount
        /// </summary>
        /// <param name="accountNumber">Unique account identifier</param>
        /// <param name="initialBalance">Starting balance for the savings account</param>
        public SavingsAccount(string accountNumber, decimal initialBalance) 
            : base(accountNumber, initialBalance)
        {
        }

        /// <summary>
        /// Override of ApplyTransaction with insufficient funds checking
        /// Ensures data integrity by preventing overdrafts
        /// </summary>
        /// <param name="transaction">Transaction to be applied</param>
        public override void ApplyTransaction(Transaction transaction)
        {
            Console.WriteLine($"Processing transaction for Savings Account {AccountNumber}");
            Console.WriteLine($"Transaction: ${transaction.Amount:F2} for {transaction.Category}");
            Console.WriteLine($"Current balance: ${Balance:F2}");

            if (transaction.Amount > Balance)
            {
                Console.WriteLine("Insufficient funds - Transaction declined\n");
                return;
            }

            Balance -= transaction.Amount;
            Console.WriteLine($"Transaction successful! New balance: ${Balance:F2}\n");
        }
    }
}
