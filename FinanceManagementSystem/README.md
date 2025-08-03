# Finance Management System

**DCIT 318 Assignment 3 - Question 1 Solution**

A comprehensive C# finance management system that demonstrates advanced object-oriented programming concepts including interfaces, records, sealed classes, and inheritance control.

## Features

### Core Components

1. **Transaction Record** (`Transaction.cs`)
   - Immutable record type representing financial data
   - Properties: Id, Date, Amount, Category
   - Provides value-based equality and immutability

2. **Payment Processing Interface** (`ITransactionProcessor.cs`)
   - Defines contract for transaction processing
   - Enables polymorphic behavior for different payment methods

3. **Transaction Processors** (`TransactionProcessors.cs`)
   - `BankTransferProcessor`: Handles bank transfer transactions
   - `MobileMoneyProcessor`: Processes mobile money transfers
   - `CryptoWalletProcessor`: Manages crypto wallet transactions

4. **Account System** (`Account.cs` & `SavingsAccount.cs`)
   - `Account`: Base class with core account functionality
   - `SavingsAccount`: Sealed class with specialized transaction handling and insufficient funds checking

5. **Finance Application** (`FinanceApp.cs`)
   - Main application logic integrating all components
   - Demonstrates system integration and simulation

## Key Programming Concepts Demonstrated

### Records
- **Immutability**: Transaction records cannot be modified after creation
- **Value Equality**: Records compare by value, not reference
- **Concise Syntax**: Compact declaration with automatic property generation

### Interfaces
- **Polymorphism**: Multiple processor implementations of `ITransactionProcessor`
- **Dependency Inversion**: Code depends on abstractions, not concrete implementations
- **Extensibility**: Easy to add new processor types without modifying existing code

### Sealed Classes
- **Inheritance Control**: `SavingsAccount` is sealed to prevent further inheritance
- **Controlled Behavior**: Ensures specialized account behavior isn't accidentally modified
- **Design Intent**: Clearly communicates that this class is final in the inheritance hierarchy

### Data Integrity
- **Insufficient Funds Check**: Prevents overdrafts in savings accounts
- **Protected Setters**: Balance can only be modified through controlled methods
- **Validation**: Transaction amounts are validated before processing

## How to Run

1. Ensure you have .NET 8.0 or later installed
2. Navigate to the project directory
3. Run the following commands:

```bash
dotnet build
dotnet run
```

## Sample Output

The application will demonstrate:
- Creating a savings account with initial balance
- Processing transactions with different processors
- Applying transactions to the account with balance validation
- Displaying comprehensive transaction summaries

## Architecture Benefits

1. **Modularity**: Each component has a single responsibility
2. **Extensibility**: New processor types can be added easily
3. **Type Safety**: Records and strong typing prevent runtime errors
4. **Immutability**: Transaction data cannot be accidentally modified
5. **Inheritance Control**: Sealed classes prevent unintended extensions
