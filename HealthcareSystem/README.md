# Healthcare Management System

**DCIT 318 Assignment 3 - Question 2 Solution**

A comprehensive healthcare management system demonstrating C# Collections and Generics for managing patient records and prescriptions with type safety, scalability, and reusability.

## Features

### Core Components

1. **Generic Repository** (`Repository<T>`)
   - Type-safe storage and retrieval for any entity type
   - Generic methods: Add, GetAll, GetById, Remove
   - Demonstrates generic programming principles

2. **Patient Class** (`Patient.cs`)
   - Properties: Id, Name, Age, Gender
   - Proper encapsulation and validation
   - Override methods for equality and string representation

3. **Prescription Class** (`Prescription.cs`)
   - Properties: Id, PatientId, MedicationName, DateIssued
   - Links prescriptions to patients
   - Date handling and formatting

4. **HealthSystemApp** (`HealthSystemApp.cs`)
   - Manages repositories and prescription mapping
   - Dictionary-based grouping for efficient data retrieval
   - Comprehensive patient and prescription management

## Key Programming Concepts Demonstrated

### Generics
- **Type Safety**: Repository<T> works with any type while maintaining compile-time safety
- **Code Reusability**: Single repository implementation handles both Patient and Prescription entities
- **Generic Constraints**: Proper use of generic methods and classes

### Collections
- **List<T>**: Dynamic storage for entities in repositories
- **Dictionary<int, List<Prescription>>**: Efficient grouping and lookup of prescriptions by patient ID
- **LINQ Integration**: Functional programming with collections for data queries

### Data Management
- **Entity Relationships**: Proper modeling of patient-prescription relationships
- **Data Integrity**: Validation and null checking throughout the system
- **Efficient Lookups**: Dictionary-based prescription mapping for O(1) retrieval

## Sample Output

The application demonstrates:
- Creating and managing patient records
- Prescription assignment and tracking
- Dictionary-based grouping of prescriptions by patient
- Interactive prescription lookup
- Generic repository functionality with different entity types

## How to Run

```bash
dotnet build
dotnet run
```

## Architecture Benefits

1. **Type Safety**: Generic repository prevents runtime type errors
2. **Scalability**: Easy to add new entity types using the same repository pattern
3. **Performance**: Dictionary-based lookups for efficient prescription retrieval
4. **Maintainability**: Clean separation of concerns and single responsibility principle
5. **Extensibility**: Generic design allows for easy feature additions
