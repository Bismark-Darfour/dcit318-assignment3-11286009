namespace WarehouseSystem
{
    /// <summary>
    /// Marker interface for inventory items
    /// Defines the contract that all inventory items must implement
    /// Enables polymorphic behavior and generic constraints
    /// </summary>
    public interface IInventoryItem
    {
        /// <summary>
        /// Unique identifier for the inventory item
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Name or description of the inventory item
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Current quantity in stock
        /// </summary>
        int Quantity { get; set; }
    }
}
