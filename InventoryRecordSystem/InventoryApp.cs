using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryRecordSystem;

/// <summary>
/// Integration layer that demonstrates the complete inventory system workflow
/// Shows how to use records, generics, and file operations together
/// </summary>
public class InventoryApp
{
    /// <summary>
    /// Logger instance for managing inventory items
    /// </summary>
    private readonly InventoryLogger<InventoryItem> _logger;

    /// <summary>
    /// Constructor that initializes the app with a logger
    /// </summary>
    /// <param name="filePath">File path for persistent storage</param>
    public InventoryApp(string filePath = "inventory_data.json")
    {
        _logger = new InventoryLogger<InventoryItem>(filePath);
        Console.WriteLine("🏢 InventoryApp initialized");
    }

    /// <summary>
    /// Seeds the logger with sample inventory data
    /// Demonstrates creating and adding inventory records
    /// </summary>
    public void SeedSampleData()
    {
        Console.WriteLine("\n=== Seeding Sample Data ===");

        try
        {
            // Create sample inventory items using record syntax with validation
            var items = new[]
            {
                InventoryItem.Create(1, "Wireless Bluetooth Headphones", 25, DateTime.Now.AddDays(-30)),
                InventoryItem.Create(2, "Gaming Mechanical Keyboard", 15, DateTime.Now.AddDays(-20)),
                InventoryItem.Create(3, "4K Ultra HD Monitor", 8, DateTime.Now.AddDays(-15)),
                InventoryItem.Create(4, "USB-C Fast Charging Cable", 50, DateTime.Now.AddDays(-10)),
                InventoryItem.Create(5, "Wireless Mouse", 0, DateTime.Now.AddDays(-5)), // Out of stock item
                InventoryItem.Create(6, "Laptop Stand", 12, DateTime.Now.AddDays(-3)),
                InventoryItem.Create(7, "Webcam HD 1080p", 7, DateTime.Now.AddDays(-1))
            };

            foreach (var item in items)
            {
                _logger.Add(item);
            }

            Console.WriteLine($"✅ Successfully seeded {items.Length} sample items");
            Console.WriteLine($"📊 Logger statistics: {_logger.GetStatistics()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error seeding sample data: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Saves current data to persistent storage
    /// Demonstrates file I/O operations
    /// </summary>
    public void SaveData()
    {
        Console.WriteLine("\n=== Saving Data to File ===");

        try
        {
            _logger.SaveToFile();
            Console.WriteLine("💾 Data saved successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Failed to save data: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Loads data from persistent storage
    /// Demonstrates file I/O and exception handling
    /// </summary>
    public void LoadData()
    {
        Console.WriteLine("\n=== Loading Data from File ===");

        try
        {
            _logger.LoadFromFile();
            Console.WriteLine($"📖 Data loaded successfully - {_logger.Count} items");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Failed to load data: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Prints all items from the loaded data
    /// Demonstrates working with loaded records
    /// </summary>
    public void PrintAllItems()
    {
        Console.WriteLine("\n=== Printing All Items ===");

        var items = _logger.GetAll();
        
        if (items.Count == 0)
        {
            Console.WriteLine("📭 No items found in inventory");
            return;
        }

        Console.WriteLine($"📋 Total Items: {items.Count}");
        Console.WriteLine(new string('-', 120));
        Console.WriteLine($"{"ID",-4} {"Name",-30} {"Quantity",-10} {"Date Added",-12} {"Status",-15} {"Age (Days)",-12}");
        Console.WriteLine(new string('-', 120));

        foreach (var item in items.OrderBy(i => i.Id))
        {
            Console.WriteLine($"{item.Id,-4} {item.Name,-30} {item.Quantity,-10} {item.DateAdded:yyyy-MM-dd,-12} {item.Status,-15} {item.AgeDays,-12}");
        }

        Console.WriteLine(new string('-', 120));
        
        // Additional statistics
        PrintInventoryStatistics(items);
    }

    /// <summary>
    /// Prints detailed inventory statistics
    /// </summary>
    /// <param name="items">List of inventory items</param>
    private void PrintInventoryStatistics(List<InventoryItem> items)
    {
        Console.WriteLine("\n📊 Inventory Statistics:");
        
        var totalItems = items.Sum(i => i.Quantity);
        var outOfStockCount = items.Count(i => i.Quantity == 0);
        var lowStockCount = items.Count(i => i.Quantity > 0 && i.Quantity <= 10);
        var avgQuantity = items.Average(i => i.Quantity);
        var oldestItem = items.OrderBy(i => i.DateAdded).First();
        var newestItem = items.OrderByDescending(i => i.DateAdded).First();

        Console.WriteLine($"   Total Inventory Units: {totalItems}");
        Console.WriteLine($"   Average Quantity per Item: {avgQuantity:F1}");
        Console.WriteLine($"   Out of Stock Items: {outOfStockCount}");
        Console.WriteLine($"   Low Stock Items (≤10): {lowStockCount}");
        Console.WriteLine($"   Oldest Item: {oldestItem.Name} (Added: {oldestItem.DateAdded:yyyy-MM-dd})");
        Console.WriteLine($"   Newest Item: {newestItem.Name} (Added: {newestItem.DateAdded:yyyy-MM-dd})");
    }

    /// <summary>
    /// Demonstrates record immutability by updating items
    /// </summary>
    public void DemonstrateRecordImmutability()
    {
        Console.WriteLine("\n=== Demonstrating Record Immutability ===");

        var items = _logger.GetAll();
        if (items.Count == 0)
        {
            Console.WriteLine("No items available for demonstration");
            return;
        }

        var firstItem = items.First();
        Console.WriteLine($"Original item: {firstItem}");

        // Demonstrate creating new instances with 'with' expressions
        var updatedQuantity = firstItem.WithQuantity(firstItem.Quantity + 10);
        var updatedName = firstItem.WithName($"Updated {firstItem.Name}");

        Console.WriteLine($"With updated quantity: {updatedQuantity}");
        Console.WriteLine($"With updated name: {updatedName}");
        Console.WriteLine($"Original unchanged: {firstItem}");
        
        // Demonstrate value equality
        var copy = firstItem with { };
        Console.WriteLine($"Copy equals original: {copy.Equals(firstItem)}");
        Console.WriteLine($"Reference equals: {ReferenceEquals(copy, firstItem)}");
    }

    /// <summary>
    /// Simulates clearing memory (clearing the in-memory log)
    /// </summary>
    public void ClearMemory()
    {
        Console.WriteLine("\n=== Simulating Memory Clear ===");
        _logger.Clear();
        Console.WriteLine("🧹 Memory cleared - simulating new session");
    }

    /// <summary>
    /// Gets the current count of items in memory
    /// </summary>
    public int GetItemCount()
    {
        return _logger.Count;
    }
}
