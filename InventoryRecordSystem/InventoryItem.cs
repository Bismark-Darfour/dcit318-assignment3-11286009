using System;

namespace InventoryRecordSystem;

/// <summary>
/// Immutable inventory item record using C# record syntax
/// Demonstrates immutable data representation and record features
/// </summary>
public record InventoryItem(
    int Id,
    string Name,
    int Quantity,
    DateTime DateAdded
) : IInventoryEntity
{
    /// <summary>
    /// Static factory method with validation for creating valid inventory items
    /// </summary>
    /// <param name="id">Unique identifier</param>
    /// <param name="name">Item name</param>
    /// <param name="quantity">Item quantity</param>
    /// <param name="dateAdded">Date item was added</param>
    /// <returns>Valid InventoryItem instance</returns>
    /// <exception cref="ArgumentException">Thrown when validation fails</exception>
    public static InventoryItem Create(int id, string name, int quantity, DateTime dateAdded)
    {
        if (id <= 0)
            throw new ArgumentException("ID must be positive", nameof(id));
        
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or empty", nameof(name));
        
        if (quantity < 0)
            throw new ArgumentException("Quantity cannot be negative", nameof(quantity));
        
        if (dateAdded > DateTime.Now)
            throw new ArgumentException("Date added cannot be in the future", nameof(dateAdded));

        return new InventoryItem(id, name, quantity, dateAdded);
    }

    /// <summary>
    /// Creates a new inventory item with updated quantity (demonstrating immutability)
    /// </summary>
    /// <param name="newQuantity">New quantity value</param>
    /// <returns>New InventoryItem instance with updated quantity</returns>
    public InventoryItem WithQuantity(int newQuantity)
    {
        if (newQuantity < 0)
            throw new ArgumentException("Quantity cannot be negative", nameof(newQuantity));
        
        return this with { Quantity = newQuantity };
    }

    /// <summary>
    /// Creates a new inventory item with updated name (demonstrating immutability)
    /// </summary>
    /// <param name="newName">New name value</param>
    /// <returns>New InventoryItem instance with updated name</returns>
    public InventoryItem WithName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Name cannot be null or empty", nameof(newName));
        
        return this with { Name = newName };
    }

    /// <summary>
    /// Gets the age of the inventory item in days
    /// </summary>
    public int AgeDays => (DateTime.Now - DateAdded).Days;

    /// <summary>
    /// Gets a status description based on quantity
    /// </summary>
    public string Status => Quantity switch
    {
        0 => "Out of Stock",
        <= 10 => "Low Stock",
        <= 50 => "Normal Stock",
        _ => "High Stock"
    };

    /// <summary>
    /// Enhanced string representation
    /// </summary>
    /// <returns>Formatted string with item details and status</returns>
    public override string ToString()
    {
        return $"InventoryItem {{ ID: {Id}, Name: '{Name}', Quantity: {Quantity}, DateAdded: {DateAdded:yyyy-MM-dd}, Status: {Status}, Age: {AgeDays} days }}";
    }
}
