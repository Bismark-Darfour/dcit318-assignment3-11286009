using FinanceManagementSystem;

/// <summary>
/// Main entry point for the Finance Management System
/// Demonstrates the integration of interfaces, records, and sealed classes
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create an instance of FinanceApp and run the simulation
            var financeApp = new FinanceApp();
            financeApp.Run();

            // Optionally run extended demo
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("Would you like to see the extended demo? (y/n)");
            var response = Console.ReadLine();
            
            if (response?.ToLower().StartsWith("y") == true)
            {
                Console.WriteLine();
                Demo.RunExtendedDemo();
            }

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
