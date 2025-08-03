namespace FinanceManagementSystem
{
    /// <summary>
    /// Concrete implementation for bank transfer transaction processing
    /// </summary>
    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Processing Bank Transfer: ${transaction.Amount:F2} for {transaction.Category}");
            Console.WriteLine($"Transaction ID: {transaction.Id}, Date: {transaction.Date:yyyy-MM-dd}");
            Console.WriteLine("Bank transfer completed successfully.\n");
        }
    }

    /// <summary>
    /// Concrete implementation for mobile money transaction processing
    /// </summary>
    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Processing Mobile Money: ${transaction.Amount:F2} for {transaction.Category}");
            Console.WriteLine($"Transaction ID: {transaction.Id}, Date: {transaction.Date:yyyy-MM-dd}");
            Console.WriteLine("Mobile money transfer completed successfully.\n");
        }
    }

    /// <summary>
    /// Concrete implementation for crypto wallet transaction processing
    /// </summary>
    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Processing Crypto Wallet: ${transaction.Amount:F2} for {transaction.Category}");
            Console.WriteLine($"Transaction ID: {transaction.Id}, Date: {transaction.Date:yyyy-MM-dd}");
            Console.WriteLine("Crypto wallet transaction completed successfully.\n");
        }
    }
}
