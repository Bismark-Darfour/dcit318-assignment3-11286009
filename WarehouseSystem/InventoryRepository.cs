namespace WarehouseSystem
{
    /// <summary>
    /// Generic inventory repository for managing inventory items
    /// Demonstrates generic programming with constraints and exception handling
    /// </summary>
    /// <typeparam name="T">Type of inventory item, must implement IInventoryItem</typeparam>
    public class InventoryRepository<T> where T : IInventoryItem
    {
        /// <summary>
        /// Internal storage using Dictionary for O(1) lookups by ID
        /// </summary>
        private Dictionary<int, T> _items;

        /// <summary>
        /// Constructor initializes the internal storage
        /// </summary>
        public InventoryRepository()
        {
            _items = new Dictionary<int, T>();
        }

        /// <summary>
        /// Adds an item to the inventory
        /// </summary>
        /// <param name="item">The item to add</param>
        /// <exception cref="DuplicateItemException">Thrown when item ID already exists</exception>
        /// <exception cref="ArgumentNullException">Thrown when item is null</exception>
        public void AddItem(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Item cannot be null");

            if (_items.ContainsKey(item.Id))
            {
                throw new DuplicateItemException($"Item with ID {item.Id} already exists in the inventory");
            }

            _items[item.Id] = item;
        }

        /// <summary>
        /// Retrieves an item by its ID
        /// </summary>
        /// <param name="id">The ID of the item to retrieve</param>
        /// <returns>The item with the specified ID</returns>
        /// <exception cref="ItemNotFoundException">Thrown when item is not found</exception>
        public T GetItemById(int id)
        {
            if (!_items.ContainsKey(id))
            {
                throw new ItemNotFoundException($"Item with ID {id} was not found in the inventory");
            }

            return _items[id];
        }

        /// <summary>
        /// Removes an item from the inventory
        /// </summary>
        /// <param name="id">The ID of the item to remove</param>
        /// <exception cref="ItemNotFoundException">Thrown when item is not found</exception>
        public void RemoveItem(int id)
        {
            if (!_items.ContainsKey(id))
            {
                throw new ItemNotFoundException($"Item with ID {id} was not found in the inventory");
            }

            _items.Remove(id);
        }

        /// <summary>
        /// Gets all items in the inventory
        /// </summary>
        /// <returns>List of all items</returns>
        public List<T> GetAllItems()
        {
            return new List<T>(_items.Values);
        }

        /// <summary>
        /// Updates the quantity of an item
        /// </summary>
        /// <param name="id">The ID of the item to update</param>
        /// <param name="newQuantity">The new quantity</param>
        /// <exception cref="ItemNotFoundException">Thrown when item is not found</exception>
        /// <exception cref="InvalidQuantityException">Thrown when quantity is negative</exception>
        public void UpdateQuantity(int id, int newQuantity)
        {
            if (newQuantity < 0)
            {
                throw new InvalidQuantityException($"Quantity cannot be negative. Provided: {newQuantity}");
            }

            if (!_items.ContainsKey(id))
            {
                throw new ItemNotFoundException($"Item with ID {id} was not found in the inventory");
            }

            _items[id].Quantity = newQuantity;
        }

        /// <summary>
        /// Gets the total count of items in the repository
        /// </summary>
        public int Count => _items.Count;

        /// <summary>
        /// Checks if an item exists in the repository
        /// </summary>
        /// <param name="id">The ID to check</param>
        /// <returns>True if item exists, false otherwise</returns>
        public bool ContainsItem(int id)
        {
            return _items.ContainsKey(id);
        }

        /// <summary>
        /// Gets the total quantity of all items combined
        /// </summary>
        /// <returns>Total quantity across all items</returns>
        public int GetTotalQuantity()
        {
            return _items.Values.Sum(item => item.Quantity);
        }

        /// <summary>
        /// Finds items with low stock (quantity below threshold)
        /// </summary>
        /// <param name="threshold">The threshold below which items are considered low stock</param>
        /// <returns>List of items with low stock</returns>
        public List<T> GetLowStockItems(int threshold = 10)
        {
            return _items.Values.Where(item => item.Quantity < threshold).ToList();
        }
    }
}
