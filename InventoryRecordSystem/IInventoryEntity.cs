namespace InventoryRecordSystem;

/// <summary>
/// Marker interface for inventory entities that can be logged
/// Demonstrates interface-based design for generic constraints
/// </summary>
public interface IInventoryEntity
{
    /// <summary>
    /// Unique identifier for the inventory entity
    /// </summary>
    int Id { get; }
}
