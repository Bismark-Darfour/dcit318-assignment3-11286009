using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Main entry point for the School Grading System
/// Demonstrates file I/O, exception handling, and data processing in C#
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("🎓 School Grading System");
        Console.WriteLine("Demonstrating File I/O and Exception Handling");
        Console.WriteLine(new string('=', 55));
        Console.WriteLine();

        // File paths
        string inputFilePath = "students.txt";
        string outputFilePath = "student_report.txt";
        string sampleFilePath = "sample_students.txt";

        try
        {
            var processor = new StudentResultProcessor();

            // Create sample files for demonstration
            Console.WriteLine("=== Setting Up Demo Files ===");
            CreateDemoFiles(processor, inputFilePath, sampleFilePath);
            Console.WriteLine();

            // Main processing flow as required
            Console.WriteLine("=== Processing Student Data ===");
            
            // Step 1: Read students from file
            List<Student> students = processor.ReadStudentsFromFile(inputFilePath);
            Console.WriteLine();

            // Step 2: Write report to file
            processor.WriteReportToFile(students, outputFilePath);
            Console.WriteLine();

            // Display summary
            DisplaySummary(students);

            // Demonstrate error handling scenarios
            Console.WriteLine("\n=== Demonstrating Exception Handling ===");
            DemonstrateExceptionHandling(processor);

            Console.WriteLine("\n=== Program Completed Successfully ===");
            Console.WriteLine($"📁 Check the following files:");
            Console.WriteLine($"   📄 Input file: {inputFilePath}");
            Console.WriteLine($"   📊 Report file: {outputFilePath}");
            Console.WriteLine($"   📋 Sample file: {sampleFilePath}");

        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"❌ File not found: {ex.Message}");
            Console.WriteLine("💡 Ensure the input file exists in the correct location.");
        }
        catch (InvalidScoreFormatException ex)
        {
            Console.WriteLine($"❌ Invalid score format: {ex.Message}");
            Console.WriteLine("💡 Ensure all scores are valid integers between 0-100.");
        }
        catch (MissingFieldException ex)
        {
            Console.WriteLine($"❌ Missing field: {ex.Message}");
            Console.WriteLine("💡 Ensure each line has ID, Name, and Score separated by commas.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Unexpected error: {ex.Message}");
            Console.WriteLine($"📋 Full error details: {ex}");
        }
        finally
        {
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }

    /// <summary>
    /// Creates demonstration files for testing
    /// </summary>
    /// <param name="processor">Student result processor instance</param>
    /// <param name="inputFilePath">Main input file path</param>
    /// <param name="sampleFilePath">Sample file path</param>
    static void CreateDemoFiles(StudentResultProcessor processor, string inputFilePath, string sampleFilePath)
    {
        // Create sample file
        processor.CreateSampleInputFile(sampleFilePath);

        // Create main input file with some test cases
        Console.WriteLine($"📄 Creating main input file: {inputFilePath}");
        using (StreamWriter writer = new StreamWriter(inputFilePath))
        {
            writer.WriteLine("201, John Doe, 85");
            writer.WriteLine("202, Jane Smith, 92");
            writer.WriteLine("203, Mike Johnson, 78");
            writer.WriteLine("204, Sarah Wilson, 65");
            writer.WriteLine("205, Tom Brown, 45");
            writer.WriteLine("206, Lisa Davis, 88");
            writer.WriteLine("207, Chris Miller, 72");
            writer.WriteLine("208, Amy Taylor, 96");
            writer.WriteLine("209, Ryan Clark, 55");
            writer.WriteLine("210, Emma White, 82");
        }
        Console.WriteLine("✅ Main input file created successfully");
    }

    /// <summary>
    /// Displays a summary of processed students
    /// </summary>
    /// <param name="students">List of students</param>
    static void DisplaySummary(List<Student> students)
    {
        Console.WriteLine("=== Processing Summary ===");
        Console.WriteLine($"📊 Total students processed: {students.Count}");

        if (students.Count > 0)
        {
            var gradeDistribution = students
                .GroupBy(s => s.GetGrade())
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count());

            Console.WriteLine("\n📈 Grade Distribution:");
            foreach (var grade in gradeDistribution)
            {
                double percentage = (grade.Value / (double)students.Count) * 100;
                Console.WriteLine($"   Grade {grade.Key}: {grade.Value} students ({percentage:F1}%)");
            }

            double averageScore = students.Average(s => s.Score);
            Console.WriteLine($"\n📋 Average Score: {averageScore:F1}");

            var topStudent = students.OrderByDescending(s => s.Score).First();
            Console.WriteLine($"🏆 Top Student: {topStudent.FullName} with {topStudent.Score} points");
        }
    }

    /// <summary>
    /// Demonstrates various exception handling scenarios
    /// </summary>
    /// <param name="processor">Student result processor instance</param>
    static void DemonstrateExceptionHandling(StudentResultProcessor processor)
    {
        Console.WriteLine("\n1. Testing FileNotFoundException:");
        try
        {
            processor.ReadStudentsFromFile("nonexistent_file.txt");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"   ❌ Caught: {ex.Message}");
        }

        Console.WriteLine("\n2. Testing InvalidScoreFormatException:");
        CreateInvalidScoreFile();
        try
        {
            processor.ReadStudentsFromFile("invalid_score.txt");
        }
        catch (InvalidScoreFormatException ex)
        {
            Console.WriteLine($"   ❌ Caught: {ex.Message}");
        }

        Console.WriteLine("\n3. Testing MissingFieldException:");
        CreateMissingFieldFile();
        try
        {
            processor.ReadStudentsFromFile("missing_field.txt");
        }
        catch (MissingFieldException ex)
        {
            Console.WriteLine($"   ❌ Caught: {ex.Message}");
        }

        // Clean up test files
        CleanupTestFiles();
    }

    /// <summary>
    /// Creates a test file with invalid score format
    /// </summary>
    static void CreateInvalidScoreFile()
    {
        using (StreamWriter writer = new StreamWriter("invalid_score.txt"))
        {
            writer.WriteLine("301, Test Student, ABC"); // Invalid score format
        }
    }

    /// <summary>
    /// Creates a test file with missing fields
    /// </summary>
    static void CreateMissingFieldFile()
    {
        using (StreamWriter writer = new StreamWriter("missing_field.txt"))
        {
            writer.WriteLine("302, Test Student"); // Missing score field
        }
    }

    /// <summary>
    /// Cleans up test files created for error demonstration
    /// </summary>
    static void CleanupTestFiles()
    {
        try
        {
            if (File.Exists("invalid_score.txt"))
                File.Delete("invalid_score.txt");
            if (File.Exists("missing_field.txt"))
                File.Delete("missing_field.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️  Could not clean up test files: {ex.Message}");
        }
    }
}
