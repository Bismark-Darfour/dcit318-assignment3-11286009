# Question 5: Inventory Record System

## Overview
A comprehensive inventory management system that demonstrates **C# records**, **generic programming**, and **file I/O operations**. The system uses immutable records for data representation, generics for type-safe operations, and JSON serialization for persistent storage.

## Features

### Core Components
- **InventoryItem Record**: Immutable data representation using C# record syntax
- **IInventoryEntity Interface**: Marker interface for generic constraints
- **InventoryLogger<T>**: Generic logger with type constraints and file operations
- **InventoryApp**: Integration layer demonstrating complete workflow

### Key Functionality
1. **Immutable Data Representation**: Records ensure data integrity and value semantics
2. **Generic Programming**: Type-safe operations with interface constraints
3. **File I/O Operations**: JSON serialization/deserialization with error handling
4. **Exception Handling**: Comprehensive error management for file operations
5. **Data Validation**: Factory methods ensure valid record creation

## Technical Concepts Demonstrated

### C# Records
- **Immutable Data**: Records provide immutable data structures by default
- **Value Equality**: Automatic implementation of value-based equality
- **Positional Syntax**: Concise record declaration with parameters
- **With Expressions**: Non-destructive mutation using `with` keyword
- **Deconstruction**: Automatic deconstruction support

### Generic Programming
- **Generic Constraints**: `where T : IInventoryEntity` ensures type safety
- **Type Safety**: Compile-time type checking for collection operations
- **Reusable Code**: Generic logger works with any inventory entity type
- **Interface-based Design**: Marker interface pattern for constraint specification

### File I/O Operations
- **JSON Serialization**: Automatic serialization of record types
- **Resource Management**: Proper disposal using `using` statements
- **Error Handling**: Comprehensive exception handling for file operations
- **Directory Management**: Automatic directory creation when needed

## Project Structure
```
InventoryRecordSystem/
├── IInventoryEntity.cs           # Marker interface for logging constraint
├── InventoryItem.cs              # Immutable record with validation
├── InventoryLogger.cs            # Generic logger with file operations
├── InventoryApp.cs               # Integration layer and workflow
├── Program.cs                    # Main application and demonstrations
├── InventoryRecordSystem.csproj  # Project configuration
└── Generated Files:
    └── inventory_records.json    # Serialized inventory data
```

## Record Definition
```csharp
public record InventoryItem(
    int Id,
    string Name,
    int Quantity,
    DateTime DateAdded
) : IInventoryEntity
{
    // Factory method with validation
    public static InventoryItem Create(int id, string name, int quantity, DateTime dateAdded)
    
    // Immutability helpers
    public InventoryItem WithQuantity(int newQuantity)
    public InventoryItem WithName(string newName)
    
    // Computed properties
    public int AgeDays => (DateTime.Now - DateAdded).Days;
    public string Status => /* Stock level calculation */;
}
```

## Generic Logger
```csharp
public class InventoryLogger<T> where T : IInventoryEntity
{
    private readonly List<T> _log;
    private readonly string _filePath;
    
    public void Add(T item)
    public List<T> GetAll()
    public void SaveToFile()        // JSON serialization
    public void LoadFromFile()      // JSON deserialization
}
```

## Sample JSON Output
```json
[
  {
    "id": 1,
    "name": "Wireless Bluetooth Headphones",
    "quantity": 25,
    "dateAdded": "2025-07-04T23:12:06.938695+00:00",
    "ageDays": 30,
    "status": "Normal Stock"
  }
]
```

## How to Run

### Prerequisites
- .NET 9.0 SDK
- System.Text.Json package (automatically restored)

### Build and Run
```bash
# Navigate to the project directory
cd InventoryRecordSystem

# Build the project
dotnet build

# Run the application
dotnet run
```

### Expected Workflow
1. **Create InventoryApp**: Initialize with JSON file path
2. **Seed Sample Data**: Add 7 inventory items to demonstrate records
3. **Save to File**: Serialize records to JSON format
4. **Clear Memory**: Simulate new application session
5. **Load from File**: Deserialize records from JSON
6. **Display Results**: Show recovered data with statistics
7. **Demonstrate Features**: Record immutability and error handling

## Assignment Requirements Fulfilled

✅ **Immutable Inventory Record**: InventoryItem record with positional syntax  
✅ **Marker Interface**: IInventoryEntity with Id property  
✅ **Generic Logger**: InventoryLogger<T> with interface constraint  
✅ **File Operations**: JSON serialization with proper error handling  
✅ **Exception Handling**: Comprehensive error management  
✅ **Integration Layer**: InventoryApp with complete workflow  
✅ **Main Application Flow**: All required steps implemented  

## Record Features Demonstrated

### Immutability
- Records are immutable by default
- `with` expressions create new instances
- Original instances remain unchanged

### Value Equality
```csharp
var item1 = InventoryItem.Create(1, "Laptop", 5, DateTime.Now);
var item2 = InventoryItem.Create(1, "Laptop", 5, DateTime.Now);
Console.WriteLine(item1 == item2);        // True (value equality)
Console.WriteLine(item1.Equals(item2));   // True (value equality)
Console.WriteLine(ReferenceEquals(item1, item2)); // False (different objects)
```

### Deconstruction
```csharp
var (id, name, quantity, dateAdded) = inventoryItem;
```

### With Expressions
```csharp
var updated = originalItem with { Quantity = 10, Name = "Updated Name" };
```

## Generic Programming Benefits

1. **Type Safety**: Compile-time verification of operations
2. **Code Reuse**: Single logger implementation for multiple entity types
3. **Performance**: No boxing/unboxing overhead
4. **IntelliSense**: Full IDE support with type information
5. **Constraint Validation**: Interface constraints ensure compatibility

## File I/O Error Handling

The system handles:
- **FileNotFoundException**: Missing input files
- **IOException**: File access issues
- **JsonException**: Invalid JSON format
- **UnauthorizedAccessException**: Permission issues
- **DirectoryNotFoundException**: Missing directories

## Educational Value

This implementation showcases:
- Modern C# record syntax and features
- Generic programming with constraints
- Professional file I/O patterns
- JSON serialization best practices
- Immutable data design principles
- Comprehensive error handling strategies

## Technical Highlights

- **Records**: Concise, immutable data representation
- **Generics**: Type-safe, reusable components
- **File I/O**: Robust JSON persistence with error handling
- **Factory Pattern**: Validated object creation
- **Resource Management**: Proper disposal patterns
- **Modern C#**: Latest language features and best practices
