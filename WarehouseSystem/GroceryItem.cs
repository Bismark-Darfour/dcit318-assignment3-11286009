namespace WarehouseSystem
{
    /// <summary>
    /// Represents a grocery item in the warehouse inventory
    /// Implements IInventoryItem interface for polymorphic behavior
    /// </summary>
    public class GroceryItem : IInventoryItem
    {
        /// <summary>
        /// Unique identifier for the grocery item
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Name of the grocery item
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Current quantity in stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Expiry date of the grocery item
        /// </summary>
        public DateTime ExpiryDate { get; private set; }

        /// <summary>
        /// Constructor to initialize all fields
        /// </summary>
        /// <param name="id">Unique item identifier</param>
        /// <param name="name">Name of the grocery item</param>
        /// <param name="quantity">Initial quantity in stock</param>
        /// <param name="expiryDate">Expiry date of the item</param>
        public GroceryItem(int id, string name, int quantity, DateTime expiryDate)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Quantity = quantity;
            ExpiryDate = expiryDate;
        }

        /// <summary>
        /// Checks if the grocery item is expired
        /// </summary>
        /// <returns>True if the item is expired</returns>
        public bool IsExpired()
        {
            return DateTime.Now > ExpiryDate;
        }

        /// <summary>
        /// Gets the number of days until expiry (negative if expired)
        /// </summary>
        /// <returns>Days until expiry</returns>
        public int DaysUntilExpiry()
        {
            return (ExpiryDate - DateTime.Now).Days;
        }

        /// <summary>
        /// String representation of the grocery item
        /// </summary>
        /// <returns>Formatted grocery item information</returns>
        public override string ToString()
        {
            var expiryStatus = IsExpired() ? " [EXPIRED]" : $" [Expires in {DaysUntilExpiry()} days]";
            return $"Grocery [ID: {Id}, Name: {Name}, Quantity: {Quantity}, Expiry: {ExpiryDate:yyyy-MM-dd}]{expiryStatus}";
        }

        /// <summary>
        /// Equality comparison based on ID
        /// </summary>
        /// <param name="obj">Object to compare with</param>
        /// <returns>True if objects are equal</returns>
        public override bool Equals(object? obj)
        {
            return obj is GroceryItem item && Id == item.Id;
        }

        /// <summary>
        /// Hash code based on ID
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
