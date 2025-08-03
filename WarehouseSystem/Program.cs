using WarehouseSystem;

/// <summary>
/// Main entry point for the Warehouse Inventory Management System
/// Demonstrates Collections, Generics, and Exception Handling in C#
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("📦 Warehouse Inventory Management System");
            Console.WriteLine("Demonstrating Collections, Generics, and Exception Handling");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine();

            // Step 1: Instantiate WarehouseManager
            var warehouseManager = new WarehouseManager();

            // Step 2: Call SeedData()
            warehouseManager.SeedData();

            // Step 3: Print all grocery items
            Console.WriteLine("=== Grocery Items ===");
            warehouseManager.PrintAllItems(warehouseManager.Groceries);
            Console.WriteLine();

            // Step 4: Print all electronic items
            Console.WriteLine("=== Electronic Items ===");
            warehouseManager.PrintAllItems(warehouseManager.Electronics);
            Console.WriteLine();

            // Display warehouse statistics
            warehouseManager.DisplayWarehouseStatistics();

            // Step 5: Demonstrate exception handling scenarios
            warehouseManager.DemonstrateErrorHandling();

            // Additional demonstrations
            Console.WriteLine("=== Additional Operations Demo ===");
            
            // Demonstrate successful stock increase
            Console.WriteLine("\n✅ Successful Operations:");
            warehouseManager.IncreaseStock(warehouseManager.Electronics, 1001, 5);
            warehouseManager.IncreaseStock(warehouseManager.Groceries, 2001, 10);

            // Show updated statistics
            Console.WriteLine("\n=== Updated Warehouse Statistics ===");
            warehouseManager.DisplayWarehouseStatistics();

            // Interactive demonstration
            Console.WriteLine("=== Interactive Demo ===");
            InteractiveDemo(warehouseManager);

            Console.WriteLine("\nThank you for using the Warehouse Management System!");
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"💥 Fatal error in main application: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }

    /// <summary>
    /// Interactive demonstration allowing user to perform warehouse operations
    /// </summary>
    /// <param name="manager">The warehouse manager instance</param>
    static void InteractiveDemo(WarehouseManager manager)
    {
        Console.WriteLine("Choose an operation:");
        Console.WriteLine("1. View all electronics");
        Console.WriteLine("2. View all groceries");
        Console.WriteLine("3. Add electronic item");
        Console.WriteLine("4. Add grocery item");
        Console.WriteLine("5. Remove item");
        Console.WriteLine("6. Update quantity");
        Console.WriteLine("7. Exit");

        while (true)
        {
            Console.Write("\nEnter choice (1-7): ");
            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n=== All Electronic Items ===");
                        manager.PrintAllItems(manager.Electronics);
                        break;

                    case "2":
                        Console.WriteLine("\n=== All Grocery Items ===");
                        manager.PrintAllItems(manager.Groceries);
                        break;

                    case "3":
                        AddElectronicItemInteractive(manager);
                        break;

                    case "4":
                        AddGroceryItemInteractive(manager);
                        break;

                    case "5":
                        RemoveItemInteractive(manager);
                        break;

                    case "6":
                        UpdateQuantityInteractive(manager);
                        break;

                    case "7":
                        Console.WriteLine("Exiting interactive demo...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter 1-7.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error during operation: {ex.Message}");
            }
        }
    }

    static void AddElectronicItemInteractive(WarehouseManager manager)
    {
        try
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            
            Console.Write("Enter Name: ");
            string name = Console.ReadLine() ?? "";
            
            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine() ?? "0");
            
            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine() ?? "";
            
            Console.Write("Enter Warranty Months: ");
            int warranty = int.Parse(Console.ReadLine() ?? "0");

            var item = new ElectronicItem(id, name, quantity, brand, warranty);
            manager.AddElectronicItem(item);
        }
        catch (FormatException)
        {
            Console.WriteLine("❌ Invalid input format. Please enter valid numbers for ID, quantity, and warranty.");
        }
    }

    static void AddGroceryItemInteractive(WarehouseManager manager)
    {
        try
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            
            Console.Write("Enter Name: ");
            string name = Console.ReadLine() ?? "";
            
            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine() ?? "0");
            
            Console.Write("Enter Expiry Date (yyyy-mm-dd): ");
            DateTime expiry = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.AddDays(30).ToString("yyyy-MM-dd"));

            var item = new GroceryItem(id, name, quantity, expiry);
            manager.AddGroceryItem(item);
        }
        catch (FormatException)
        {
            Console.WriteLine("❌ Invalid input format. Please check your date format and numeric values.");
        }
    }

    static void RemoveItemInteractive(WarehouseManager manager)
    {
        try
        {
            Console.Write("Enter item type (e/g for electronic/grocery): ");
            string type = Console.ReadLine()?.ToLower() ?? "";
            
            Console.Write("Enter ID to remove: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            if (type == "e")
            {
                manager.RemoveItemById(manager.Electronics, id);
            }
            else if (type == "g")
            {
                manager.RemoveItemById(manager.Groceries, id);
            }
            else
            {
                Console.WriteLine("❌ Invalid type. Use 'e' for electronic or 'g' for grocery.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("❌ Invalid ID format. Please enter a valid number.");
        }
    }

    static void UpdateQuantityInteractive(WarehouseManager manager)
    {
        try
        {
            Console.Write("Enter item type (e/g for electronic/grocery): ");
            string type = Console.ReadLine()?.ToLower() ?? "";
            
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            
            Console.Write("Enter new quantity: ");
            int quantity = int.Parse(Console.ReadLine() ?? "0");

            if (type == "e")
            {
                manager.Electronics.UpdateQuantity(id, quantity);
                Console.WriteLine($"✅ Updated electronic item {id} quantity to {quantity}");
            }
            else if (type == "g")
            {
                manager.Groceries.UpdateQuantity(id, quantity);
                Console.WriteLine($"✅ Updated grocery item {id} quantity to {quantity}");
            }
            else
            {
                Console.WriteLine("❌ Invalid type. Use 'e' for electronic or 'g' for grocery.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("❌ Invalid input format. Please enter valid numbers.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error updating quantity: {ex.Message}");
        }
    }
}
