namespace WarehouseSystem
{
    /// <summary>
    /// Represents an electronic item in the warehouse inventory
    /// Implements IInventoryItem interface for polymorphic behavior
    /// </summary>
    public class ElectronicItem : IInventoryItem
    {
        /// <summary>
        /// Unique identifier for the electronic item
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Name of the electronic item
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Current quantity in stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Brand/manufacturer of the electronic item
        /// </summary>
        public string Brand { get; private set; }

        /// <summary>
        /// Warranty period in months
        /// </summary>
        public int WarrantyMonths { get; private set; }

        /// <summary>
        /// Constructor to initialize all fields
        /// </summary>
        /// <param name="id">Unique item identifier</param>
        /// <param name="name">Name of the electronic item</param>
        /// <param name="quantity">Initial quantity in stock</param>
        /// <param name="brand">Brand/manufacturer</param>
        /// <param name="warrantyMonths">Warranty period in months</param>
        public ElectronicItem(int id, string name, int quantity, string brand, int warrantyMonths)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Quantity = quantity;
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
            WarrantyMonths = warrantyMonths;
        }

        /// <summary>
        /// String representation of the electronic item
        /// </summary>
        /// <returns>Formatted electronic item information</returns>
        public override string ToString()
        {
            return $"Electronic [ID: {Id}, Name: {Name}, Quantity: {Quantity}, Brand: {Brand}, Warranty: {WarrantyMonths} months]";
        }

        /// <summary>
        /// Equality comparison based on ID
        /// </summary>
        /// <param name="obj">Object to compare with</param>
        /// <returns>True if objects are equal</returns>
        public override bool Equals(object? obj)
        {
            return obj is ElectronicItem item && Id == item.Id;
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
