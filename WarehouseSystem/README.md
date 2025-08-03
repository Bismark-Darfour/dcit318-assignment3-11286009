# Warehouse Inventory Management System

**DCIT 318 Assignment 3 - Question 3 Solution**

A comprehensive warehouse inventory management system demonstrating C# Collections, Generics, and Exception Handling for managing different types of products with safe and efficient operations.

## Features

### Core Components

1. **Marker Interface** (`IInventoryItem`)
   - Defines common contract for all inventory items
   - Properties: Id, Name, Quantity
   - Enables polymorphic behavior and generic constraints

2. **Product Classes**
   - **ElectronicItem**: Electronics with brand and warranty information
   - **GroceryItem**: Grocery items with expiry date tracking
   - Both implement IInventoryItem interface

3. **Generic Repository** (`InventoryRepository<T>`)
   - Type-safe storage using Dictionary<int, T> for O(1) lookups
   - Generic methods with proper exception handling
   - Constraint: T must implement IInventoryItem

4. **Custom Exceptions**
   - **DuplicateItemException**: Thrown when adding items with duplicate IDs
   - **ItemNotFoundException**: Thrown when items are not found
   - **InvalidQuantityException**: Thrown for negative quantities

5. **WarehouseManager** (`WarehouseManager.cs`)
   - Coordinates operations across multiple repositories
   - Generic methods for type-safe operations
   - Comprehensive exception handling with user-friendly messages

## Key Programming Concepts Demonstrated

### Generics with Constraints
- **Generic Repository**: `InventoryRepository<T> where T : IInventoryItem`
- **Generic Methods**: Type-safe operations across different item types
- **Compile-time Safety**: Prevents type-related runtime errors

### Collections
- **Dictionary<int, T>**: Efficient O(1) lookups by item ID
- **List<T>**: Dynamic collections for returning multiple items
- **LINQ Integration**: Functional programming for data filtering and operations

### Exception Handling
- **Custom Exceptions**: Domain-specific error types with meaningful messages
- **Try-Catch Blocks**: Graceful error handling in all operations
- **Exception Propagation**: Proper exception chaining and context preservation

### Interface Design
- **Marker Interface**: Defines common contract for all inventory items
- **Polymorphism**: Uniform handling of different item types
- **Abstraction**: Clean separation between interface and implementation

## Sample Output

The application demonstrates:
- Adding different types of inventory items
- Dictionary-based storage and retrieval
- Custom exception handling for various error scenarios
- Generic repository operations with type safety
- Interactive inventory management operations
- Expiry date tracking for grocery items
- Low stock alerts and warehouse statistics

## Architecture Benefits

1. **Type Safety**: Generic constraints prevent runtime type errors
2. **Performance**: Dictionary-based storage for efficient lookups
3. **Extensibility**: Easy to add new product types by implementing IInventoryItem
4. **Error Handling**: Comprehensive exception handling with meaningful messages
5. **Code Reusability**: Single repository implementation works with all item types
6. **Maintainability**: Clear separation of concerns and single responsibility principle

## How to Run

```bash
dotnet build
dotnet run
```

## Error Scenarios Demonstrated

1. **Duplicate Item Addition**: Attempting to add items with existing IDs
2. **Item Not Found**: Trying to access or remove non-existent items
3. **Invalid Quantity**: Setting negative quantities
4. **Null Reference Handling**: Proper validation of input parameters
5. **Format Exceptions**: Interactive input validation

## Advanced Features

- **Expiry Date Tracking**: Automatic expired item detection for groceries
- **Low Stock Alerts**: Identification of items below threshold quantities
- **Warehouse Statistics**: Comprehensive reporting on inventory status
- **Interactive Operations**: User-friendly interface for inventory management
- **LINQ Integration**: Functional programming for data analysis
