using FinanceManagementSystem;

/// <summary>
/// Demonstration class showing edge cases and additional functionality
/// including insufficient funds handling
/// </summary>
public static class Demo
{
    /// <summary>
    /// Run extended demonstrations of the finance management system
    /// </summary>
    public static void RunExtendedDemo()
    {
        Console.WriteLine("=== Finance Management System - Extended Demo ===\n");

        // Test insufficient funds scenario
        var savingsAccount = new SavingsAccount("SAV002", 100m);
        Console.WriteLine($"Created test account: {savingsAccount.AccountNumber}");
        Console.WriteLine($"Initial Balance: ${savingsAccount.Balance:F2}\n");

        // Create a transaction that exceeds the balance
        var largeTransaction = new Transaction(4, DateTime.Now, 500m, "Large Purchase");
        Console.WriteLine($"Attempting large transaction: {largeTransaction}\n");

        // Process the transaction (should be declined)
        var processor = new BankTransferProcessor();
        processor.Process(largeTransaction);

        // Try to apply to account (should show insufficient funds)
        savingsAccount.ApplyTransaction(largeTransaction);

        // Create a valid transaction
        var validTransaction = new Transaction(5, DateTime.Now, 50m, "Small Purchase");
        Console.WriteLine($"Processing valid transaction: {validTransaction}\n");

        processor.Process(validTransaction);
        savingsAccount.ApplyTransaction(validTransaction);

        // Demonstrate record immutability
        Console.WriteLine("=== Demonstrating Record Immutability ===");
        var originalTransaction = new Transaction(6, DateTime.Now, 25m, "Test");
        Console.WriteLine($"Original: {originalTransaction}");

        // Records are immutable - we can only create new instances with 'with' expressions
        var modifiedTransaction = originalTransaction with { Amount = 30m };
        Console.WriteLine($"Modified (new instance): {modifiedTransaction}");
        Console.WriteLine($"Original unchanged: {originalTransaction}\n");

        // Demonstrate polymorphism with processors
        Console.WriteLine("=== Demonstrating Polymorphism ===");
        ITransactionProcessor[] processors = {
            new BankTransferProcessor(),
            new MobileMoneyProcessor(),
            new CryptoWalletProcessor()
        };

        var testTransaction = new Transaction(7, DateTime.Now, 100m, "Polymorphism Test");

        foreach (var proc in processors)
        {
            proc.Process(testTransaction);
        }

        Console.WriteLine("Extended demo completed!");
    }
}
