namespace WarehouseSystem
{
    /// <summary>
    /// Main warehouse manager class that coordinates inventory operations
    /// Demonstrates generic methods, exception handling, and repository pattern
    /// </summary>
    public class WarehouseManager
    {
        /// <summary>
        /// Repository for managing electronic items
        /// </summary>
        private InventoryRepository<ElectronicItem> _electronics;

        /// <summary>
        /// Repository for managing grocery items
        /// </summary>
        private InventoryRepository<GroceryItem> _groceries;

        /// <summary>
        /// Constructor initializes both repositories
        /// </summary>
        public WarehouseManager()
        {
            _electronics = new InventoryRepository<ElectronicItem>();
            _groceries = new InventoryRepository<GroceryItem>();
        }

        /// <summary>
        /// Seeds the warehouse with sample data
        /// Adds sample electronic and grocery items
        /// </summary>
        public void SeedData()
        {
            Console.WriteLine("=== Seeding Warehouse Data ===");

            try
            {
                // Add sample electronic items
                _electronics.AddItem(new ElectronicItem(1001, "Laptop", 15, "Dell", 24));
                _electronics.AddItem(new ElectronicItem(1002, "Smartphone", 25, "Samsung", 12));
                _electronics.AddItem(new ElectronicItem(1003, "Tablet", 8, "Apple", 12));

                Console.WriteLine("✅ Added 3 electronic items");

                // Add sample grocery items
                _groceries.AddItem(new GroceryItem(2001, "Milk", 50, DateTime.Now.AddDays(7)));
                _groceries.AddItem(new GroceryItem(2002, "Bread", 30, DateTime.Now.AddDays(3)));
                _groceries.AddItem(new GroceryItem(2003, "Eggs", 40, DateTime.Now.AddDays(14)));

                Console.WriteLine("✅ Added 3 grocery items");
                Console.WriteLine($"Total items in warehouse: {_electronics.Count + _groceries.Count}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error seeding data: {ex.Message}\n");
            }
        }

        /// <summary>
        /// Generic method to print all items in a repository
        /// Demonstrates generic method with constraints
        /// </summary>
        /// <typeparam name="T">Type of inventory item</typeparam>
        /// <param name="repo">The repository to print items from</param>
        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            var items = repo.GetAllItems();
            
            if (items.Count == 0)
            {
                Console.WriteLine("No items found in this category.");
                return;
            }

            foreach (var item in items.OrderBy(i => i.Id))
            {
                Console.WriteLine($"  {item}");
            }

            Console.WriteLine($"  📊 Total items: {items.Count}, Total quantity: {repo.GetTotalQuantity()}");
            
            var lowStockItems = repo.GetLowStockItems();
            if (lowStockItems.Count > 0)
            {
                Console.WriteLine($"  ⚠️  Low stock items: {string.Join(", ", lowStockItems.Select(i => i.Name))}");
            }
        }

        /// <summary>
        /// Generic method to increase stock of an item
        /// Demonstrates exception handling in generic methods
        /// </summary>
        /// <typeparam name="T">Type of inventory item</typeparam>
        /// <param name="repo">The repository containing the item</param>
        /// <param name="id">ID of the item to update</param>
        /// <param name="quantity">Quantity to add</param>
        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                var newQuantity = item.Quantity + quantity;
                repo.UpdateQuantity(id, newQuantity);
                Console.WriteLine($"✅ Stock increased: {item.Name} now has {newQuantity} units");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"❌ Cannot increase stock: {ex.Message}");
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"❌ Invalid quantity operation: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Unexpected error increasing stock: {ex.Message}");
            }
        }

        /// <summary>
        /// Generic method to remove an item by ID
        /// Demonstrates exception handling in generic methods
        /// </summary>
        /// <typeparam name="T">Type of inventory item</typeparam>
        /// <param name="repo">The repository containing the item</param>
        /// <param name="id">ID of the item to remove</param>
        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id); // Get item first to show its name
                repo.RemoveItem(id);
                Console.WriteLine($"✅ Successfully removed: {item.Name} (ID: {id})");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"❌ Cannot remove item: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Unexpected error removing item: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new electronic item with exception handling
        /// </summary>
        /// <param name="item">Electronic item to add</param>
        public void AddElectronicItem(ElectronicItem item)
        {
            try
            {
                _electronics.AddItem(item);
                Console.WriteLine($"✅ Successfully added electronic item: {item.Name}");
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"❌ Cannot add electronic item: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Unexpected error adding electronic item: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new grocery item with exception handling
        /// </summary>
        /// <param name="item">Grocery item to add</param>
        public void AddGroceryItem(GroceryItem item)
        {
            try
            {
                _groceries.AddItem(item);
                Console.WriteLine($"✅ Successfully added grocery item: {item.Name}");
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"❌ Cannot add grocery item: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Unexpected error adding grocery item: {ex.Message}");
            }
        }

        /// <summary>
        /// Demonstrates all error scenarios as requested in the assignment
        /// </summary>
        public void DemonstrateErrorHandling()
        {
            Console.WriteLine("=== Demonstrating Exception Handling ===");

            // 1. Try to add a duplicate item
            Console.WriteLine("\n1. Attempting to add duplicate electronic item:");
            var duplicateElectronic = new ElectronicItem(1001, "Duplicate Laptop", 5, "HP", 12);
            AddElectronicItem(duplicateElectronic);

            // 2. Try to remove a non-existent item
            Console.WriteLine("\n2. Attempting to remove non-existent item:");
            RemoveItemById(_electronics, 9999);

            // 3. Try to update with invalid quantity
            Console.WriteLine("\n3. Attempting to update with invalid (negative) quantity:");
            try
            {
                _electronics.UpdateQuantity(1001, -5);
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"❌ Invalid quantity update: {ex.Message}");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"❌ Item not found for quantity update: {ex.Message}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Displays comprehensive warehouse statistics
        /// </summary>
        public void DisplayWarehouseStatistics()
        {
            Console.WriteLine("=== Warehouse Statistics ===");
            Console.WriteLine($"📱 Electronic Items: {_electronics.Count} types, {_electronics.GetTotalQuantity()} total units");
            Console.WriteLine($"🛒 Grocery Items: {_groceries.Count} types, {_groceries.GetTotalQuantity()} total units");
            Console.WriteLine($"📦 Total Inventory: {_electronics.Count + _groceries.Count} types, {_electronics.GetTotalQuantity() + _groceries.GetTotalQuantity()} total units");

            // Check for expired grocery items
            var expiredItems = _groceries.GetAllItems().Where(g => g.IsExpired()).ToList();
            if (expiredItems.Count > 0)
            {
                Console.WriteLine($"⚠️  Expired grocery items: {string.Join(", ", expiredItems.Select(i => i.Name))}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Public getters for repositories (for demonstration purposes)
        /// </summary>
        public InventoryRepository<ElectronicItem> Electronics => _electronics;
        public InventoryRepository<GroceryItem> Groceries => _groceries;
    }
}
