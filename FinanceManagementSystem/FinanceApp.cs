namespace FinanceManagementSystem
{
    /// <summary>
    /// Main application class that integrates all components of the finance management system
    /// Demonstrates the use of interfaces, records, sealed classes, and inheritance
    /// </summary>
    public class FinanceApp
    {
        private List<Transaction> _transactions;

        /// <summary>
        /// Constructor initializes the transaction list
        /// </summary>
        public FinanceApp()
        {
            _transactions = new List<Transaction>();
        }

        /// <summary>
        /// Main application logic that demonstrates the finance management system
        /// </summary>
        public void Run()
        {
            Console.WriteLine("=== Finance Management System ===\n");

            // Step 1: Create a SavingsAccount with initial balance
            var savingsAccount = new SavingsAccount("SAV001", 1000m);
            Console.WriteLine($"Created Savings Account: {savingsAccount.AccountNumber}");
            Console.WriteLine($"Initial Balance: ${savingsAccount.Balance:F2}\n");

            // Step 2: Create three sample transactions using records
            var transaction1 = new Transaction(1, DateTime.Now, 150m, "Groceries");
            var transaction2 = new Transaction(2, DateTime.Now, 200m, "Utilities");
            var transaction3 = new Transaction(3, DateTime.Now, 75m, "Entertainment");

            Console.WriteLine("Created transactions:");
            Console.WriteLine($"1. {transaction1}");
            Console.WriteLine($"2. {transaction2}");
            Console.WriteLine($"3. {transaction3}\n");

            // Step 3: Create transaction processors (demonstrating interface implementation)
            var mobileMoneyProcessor = new MobileMoneyProcessor();
            var bankTransferProcessor = new BankTransferProcessor();
            var cryptoWalletProcessor = new CryptoWalletProcessor();

            Console.WriteLine("=== Processing Transactions ===\n");

            // Step 4: Process transactions using different processors
            Console.WriteLine("1. Processing with Mobile Money Processor:");
            mobileMoneyProcessor.Process(transaction1);

            Console.WriteLine("2. Processing with Bank Transfer Processor:");
            bankTransferProcessor.Process(transaction2);

            Console.WriteLine("3. Processing with Crypto Wallet Processor:");
            cryptoWalletProcessor.Process(transaction3);

            Console.WriteLine("=== Applying Transactions to Account ===\n");

            // Step 5: Apply transactions to the savings account
            savingsAccount.ApplyTransaction(transaction1);
            savingsAccount.ApplyTransaction(transaction2);
            savingsAccount.ApplyTransaction(transaction3);

            // Step 6: Add transactions to the list
            _transactions.Add(transaction1);
            _transactions.Add(transaction2);
            _transactions.Add(transaction3);

            // Display final summary
            Console.WriteLine("=== Transaction Summary ===");
            Console.WriteLine($"Total transactions processed: {_transactions.Count}");
            Console.WriteLine($"Final account balance: ${savingsAccount.Balance:F2}");
            
            decimal totalTransacted = _transactions.Sum(t => t.Amount);
            Console.WriteLine($"Total amount transacted: ${totalTransacted:F2}");

            Console.WriteLine("\n=== All Transactions ===");
            foreach (var transaction in _transactions)
            {
                Console.WriteLine($"ID: {transaction.Id}, Date: {transaction.Date:yyyy-MM-dd}, " +
                                $"Amount: ${transaction.Amount:F2}, Category: {transaction.Category}");
            }
        }
    }
}
