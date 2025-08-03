# DCIT 318 Assignment 3 - Student ID: 11286009

This repository contains solutions for DCIT 318 Assignment 3, implementing advanced C# programming concepts including interfaces, records, sealed classes, and inheritance control.

## Project Structure

```
dcit318-assignment3-11286009/
├── FinanceManagementSystem/ # Finance Management System ✅ COMPLETED
│   ├── *.cs            # C# source files
│   ├── *.csproj        # Project configuration
│   ├── README.md       # Question 1 specific documentation
│   └── bin/obj/        # Build artifacts
├── HealthcareSystem/    # Healthcare Management System ✅ COMPLETED
│   ├── *.cs            # C# source files
│   ├── *.csproj        # Project configuration
│   ├── README.md       # Question 2 specific documentation
│   └── bin/obj/        # Build artifacts
├── WarehouseSystem/     # Warehouse Inventory System ✅ COMPLETED
│   ├── *.cs            # C# source files
│   ├── *.csproj        # Project configuration
│   ├── README.md       # Question 3 specific documentation
│   └── bin/obj/        # Build artifacts
├── GradingSystem/       # School Grading System ✅ COMPLETED
│   ├── *.cs            # C# source files
│   ├── *.csproj        # Project configuration
│   ├── README.md       # Question 4 specific documentation
│   ├── *.txt           # Input/Output data files
│   └── bin/obj/        # Build artifacts
└── InventoryRecordSystem/ # Inventory Record Management ✅ COMPLETED
    ├── *.cs            # C# source files
    ├── *.csproj        # Project configuration
    ├── README.md       # Question 5 specific documentation
    ├── *.json          # Data persistence files
    └── bin/obj/        # Build artifacts
```

## Questions Overview

### Question 1: Finance Management System ✅ COMPLETED
- **Focus**: Interfaces, Records, Sealed Classes, Inheritance Control
- **Features**: Transaction processing, Account management, Data integrity
- **Technologies**: C# Records, Interfaces, Sealed Classes, Virtual Methods
- **Status**: Fully implemented and tested

### Question 2: Healthcare Management System ✅ COMPLETED
- **Focus**: Collections, Generics, Type Safety, Data Management
- **Features**: Patient records, Prescription tracking, Generic repository pattern
- **Technologies**: C# Collections (List, Dictionary), Generics, LINQ
- **Status**: Fully implemented and tested

### Question 3: Warehouse Inventory System ✅ COMPLETED
- **Focus**: Collections, Generics, Exception Handling, Safe Operations
- **Features**: Multi-type inventory, Custom exceptions, Generic repository with constraints
- **Technologies**: C# Collections (Dictionary, List), Generics with constraints, Custom exceptions
- **Status**: Fully implemented and tested

### Question 4: School Grading System ✅ COMPLETED
- **Focus**: File I/O Operations, Exception Handling, Data Processing
- **Features**: Student grade management, File processing, Report generation
- **Technologies**: File I/O operations, Custom exceptions, LINQ, Switch expressions
- **Status**: Fully implemented and tested

### Question 5: Inventory Record Management ✅ COMPLETED
- **Focus**: C# Records, Generics, File I/O, Data Persistence
- **Features**: Immutable inventory records, Generic logging system, JSON persistence
- **Technologies**: C# Records, Generics with constraints, System.Text.Json, File operations
- **Status**: Fully implemented and tested

## How to Run

### Question 1
```bash
cd FinanceManagementSystem
dotnet build
dotnet run
```

### Question 2
```bash
cd HealthcareSystem
dotnet build
dotnet run
```

### Question 3
```bash
cd WarehouseSystem
dotnet build
dotnet run
```

### Question 4
```bash
cd GradingSystem
dotnet build
dotnet run
```

### Question 5
```bash
cd InventoryRecordSystem
dotnet build
dotnet run
```

## Key Learning Objectives Demonstrated

1. **Record Types**: Immutable data structures with value equality and positional syntax
2. **Interface Implementation**: Polymorphic behavior through contracts
3. **Sealed Classes**: Inheritance control and design intent
4. **Virtual Methods**: Extensible base class functionality
5. **Generic Programming**: Type-safe and reusable code with generics
6. **Generic Constraints**: Restricting generic types to specific interfaces
7. **Collections Management**: List, Dictionary, and LINQ operations
8. **Exception Handling**: Custom exceptions and safe error management
9. **File I/O Operations**: Reading from and writing to files
10. **Data Processing**: CSV parsing, validation, and report generation
11. **Data Integrity**: Validation and error handling
12. **JSON Serialization**: Data persistence with System.Text.Json
13. **Factory Pattern**: Object creation with validation
14. **Modern C# Features**: Latest language constructs and best practices

## Author
- **Student ID**: 11286009
- **Course**: DCIT 318
- **Assignment**: 3
