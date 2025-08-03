# Question 4: School Grading System

## Overview
A comprehensive grading system that demonstrates **file I/O operations** and **exception handling** in C#. The system reads student data from files, processes grades, and generates detailed reports.

## Features

### Core Components
- **Student Class**: Represents individual students with grade calculation logic
- **Custom Exceptions**: Specialized exception handling for data validation
- **StudentResultProcessor**: Handles file I/O and data processing
- **Program**: Main entry point with comprehensive error handling

### Key Functionality
1. **File Input Processing**: Reads student data from CSV files
2. **Grade Calculation**: Automatic letter grade assignment (A-F scale)
3. **Report Generation**: Creates detailed performance reports
4. **Exception Handling**: Robust error handling for various scenarios
5. **Data Validation**: Ensures data integrity and format compliance

## Technical Concepts Demonstrated

### File I/O Operations
- Reading from text files using `File.ReadAllLines()`
- Writing reports using `StreamWriter`
- CSV parsing and data extraction
- File existence validation

### Exception Handling
- **Custom Exceptions**:
  - `InvalidScoreFormatException`: For invalid score formats
  - `MissingFieldException`: For incomplete data records
- **Built-in Exceptions**:
  - `FileNotFoundException`: For missing input files
  - `ArgumentNullException`: For null parameter validation
- **Try-Catch-Finally Blocks**: Comprehensive error handling workflow

### Data Processing
- **LINQ Operations**: Sorting, grouping, and statistical calculations
- **Switch Expressions**: Modern C# pattern matching for grade calculation
- **Generic Collections**: `List<Student>` for type-safe data storage

## Project Structure
```
GradingSystem/
├── Student.cs                    # Student entity with grade logic
├── CustomExceptions.cs           # Custom exception classes
├── StudentResultProcessor.cs     # File I/O and processing logic
├── Program.cs                    # Main application entry point
├── GradingSystem.csproj          # Project configuration
└── Generated Files:
    ├── students.txt              # Input data file
    ├── student_report.txt        # Generated report
    └── sample_students.txt       # Sample data file
```

## Sample Input Format
```csv
ID, Student Name, Score
201, John Doe, 85
202, Jane Smith, 92
203, Mike Johnson, 78
```

## Sample Output Report
```
STUDENT GRADING REPORT
====================
208: Amy Taylor - 96 (A)
202: Jane Smith - 92 (A)
206: Lisa Davis - 88 (B)
201: John Doe - 85 (B)
210: Emma White - 82 (B)
203: Mike Johnson - 78 (C)
207: Chris Miller - 72 (C)
204: Sarah Wilson - 65 (D)
209: Ryan Clark - 55 (F)
205: Tom Brown - 45 (F)
```

## How to Run

### Prerequisites
- .NET 9.0 SDK
- Terminal/Command Line access

### Build and Run
```bash
# Navigate to the project directory
cd GradingSystem

# Build the project
dotnet build

# Run the application
dotnet run
```

### Expected Behavior
1. **Setup Phase**: Creates demo input files automatically
2. **Processing Phase**: Reads student data and processes grades
3. **Reporting Phase**: Generates comprehensive grade reports
4. **Error Demonstration**: Shows various exception handling scenarios
5. **File Generation**: Creates output files for review

## Exception Handling Demonstrations

The application demonstrates handling of:
1. **FileNotFoundException**: When input files don't exist
2. **InvalidScoreFormatException**: When score data is not numeric
3. **MissingFieldException**: When required fields are missing
4. **General Exception**: Catch-all for unexpected errors

## Grade Scale
- **A**: 90-100 points (Excellent)
- **B**: 80-89 points (Good)
- **C**: 70-79 points (Satisfactory)
- **D**: 60-69 points (Needs Improvement)
- **F**: 0-59 points (Failing)

## Assignment Requirements Fulfilled

✅ **File I/O Operations**: Complete file reading and writing implementation  
✅ **Exception Handling**: Custom exceptions and comprehensive error handling  
✅ **Data Processing**: CSV parsing, validation, and report generation  
✅ **Error Recovery**: Graceful handling of various error scenarios  
✅ **User Experience**: Clear error messages and progress indicators  

## Technical Highlights

- **Modern C# Features**: Switch expressions, null-conditional operators
- **Best Practices**: Proper resource disposal with `using` statements
- **Code Documentation**: Comprehensive XML documentation comments
- **Error Messaging**: User-friendly error messages with guidance
- **Data Validation**: Range checking and format validation

## Educational Value

This implementation showcases:
- Professional error handling patterns
- File I/O best practices in C#
- Data validation techniques
- Report generation strategies
- Modern C# language features
