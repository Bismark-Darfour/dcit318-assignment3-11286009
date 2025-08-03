using System;

namespace InventoryRecordSystem;

/// <summary>
/// Main program that demonstrates the complete inventory record system
/// Shows records, generics, file I/O, and exception handling working together
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("🏭 Inventory Record System");
        Console.WriteLine("Demonstrating C# Records, Generics, and File I/O Operations");
        Console.WriteLine(new string('=', 70));

        try
        {
            // Step 1: Create an instance of InventoryApp
            Console.WriteLine("\n🚀 Step 1: Creating InventoryApp instance...");
            var inventoryApp = new InventoryApp("inventory_records.json");

            // Step 2: Call SeedSampleData()
            Console.WriteLine("\n🌱 Step 2: Seeding sample data...");
            inventoryApp.SeedSampleData();

            // Step 3: Call SaveData() to persist to disk
            Console.WriteLine("\n💾 Step 3: Saving data to disk...");
            inventoryApp.SaveData();

            // Step 4: Clear memory and simulate a new session
            Console.WriteLine("\n🔄 Step 4: Clearing memory (simulating new session)...");
            inventoryApp.ClearMemory();
            Console.WriteLine($"Items in memory after clear: {inventoryApp.GetItemCount()}");

            // Step 5: Call LoadData() to read from file
            Console.WriteLine("\n📖 Step 5: Loading data from file...");
            inventoryApp.LoadData();

            // Step 6: Call PrintAllItems() to confirm data was recovered
            Console.WriteLine("\n📋 Step 6: Printing all recovered items...");
            inventoryApp.PrintAllItems();

            // Additional demonstration: Record immutability
            inventoryApp.DemonstrateRecordImmutability();

            // Demonstrate error handling scenarios
            DemonstrateErrorHandling();

            Console.WriteLine("\n✅ Program completed successfully!");
            Console.WriteLine("🎯 All inventory records, generics, and file operations working correctly.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ Program failed with error: {ex.Message}");
            Console.WriteLine($"📋 Full error details: {ex}");
        }
        finally
        {
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }

    /// <summary>
    /// Demonstrates various error handling scenarios
    /// </summary>
    private static void DemonstrateErrorHandling()
    {
        Console.WriteLine("\n=== Demonstrating Error Handling ===");

        // Test 1: Invalid record creation
        Console.WriteLine("\n1. Testing invalid record creation:");
        try
        {
            var invalidItem = InventoryItem.Create(-1, "", -5, DateTime.Now.AddDays(1));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"   ❌ Caught expected error: {ex.Message}");
        }

        // Test 2: Duplicate ID handling
        Console.WriteLine("\n2. Testing duplicate ID handling:");
        try
        {
            var logger = new InventoryLogger<InventoryItem>("test.json");
            var item1 = InventoryItem.Create(100, "Test Item 1", 10, DateTime.Now);
            var item2 = InventoryItem.Create(100, "Test Item 2", 15, DateTime.Now); // Same ID

            logger.Add(item1);
            logger.Add(item2); // Should throw exception
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"   ❌ Caught expected error: {ex.Message}");
        }

        // Test 3: File operations with invalid path
        Console.WriteLine("\n3. Testing file operations with invalid path:");
        try
        {
            var logger = new InventoryLogger<InventoryItem>("/invalid/path/that/does/not/exist/test.json");
            logger.Add(InventoryItem.Create(200, "Test Item", 5, DateTime.Now));
            logger.SaveToFile(); // Should handle directory creation or throw appropriate error
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ❌ Caught file operation error: {ex.GetType().Name} - {ex.Message}");
        }

        // Test 4: Loading from non-existent file
        Console.WriteLine("\n4. Testing load from non-existent file:");
        try
        {
            var logger = new InventoryLogger<InventoryItem>("non_existent_file.json");
            logger.LoadFromFile(); // Should handle gracefully
            Console.WriteLine("   ✅ Handled non-existent file gracefully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ❌ Unexpected error: {ex.Message}");
        }

        Console.WriteLine("\n✅ Error handling demonstrations completed");
    }

    /// <summary>
    /// Demonstrates advanced record features
    /// </summary>
    private static void DemonstrateAdvancedRecordFeatures()
    {
        Console.WriteLine("\n=== Demonstrating Advanced Record Features ===");

        // Create some sample items
        var item1 = InventoryItem.Create(1, "Laptop", 5, DateTime.Now.AddDays(-10));
        var item2 = InventoryItem.Create(1, "Laptop", 5, DateTime.Now.AddDays(-10));
        var item3 = InventoryItem.Create(2, "Mouse", 15, DateTime.Now.AddDays(-5));

        Console.WriteLine("\n1. Value Equality:");
        Console.WriteLine($"   item1 == item2: {item1 == item2}"); // Should be true (same values)
        Console.WriteLine($"   item1.Equals(item2): {item1.Equals(item2)}"); // Should be true
        Console.WriteLine($"   ReferenceEquals(item1, item2): {ReferenceEquals(item1, item2)}"); // Should be false

        Console.WriteLine("\n2. Hash Code Consistency:");
        Console.WriteLine($"   item1.GetHashCode(): {item1.GetHashCode()}");
        Console.WriteLine($"   item2.GetHashCode(): {item2.GetHashCode()}"); // Should be same as item1
        Console.WriteLine($"   item3.GetHashCode(): {item3.GetHashCode()}"); // Should be different

        Console.WriteLine("\n3. Deconstruction:");
        var (id, name, quantity, dateAdded) = item1;
        Console.WriteLine($"   Deconstructed: ID={id}, Name={name}, Quantity={quantity}, Date={dateAdded:yyyy-MM-dd}");

        Console.WriteLine("\n4. With Expressions (Non-destructive mutation):");
        var modifiedItem = item1 with { Quantity = 10, Name = "Gaming Laptop" };
        Console.WriteLine($"   Original: {item1}");
        Console.WriteLine($"   Modified: {modifiedItem}");

        Console.WriteLine("\n5. ToString() Override:");
        Console.WriteLine($"   Custom ToString: {item1}");
    }
}
