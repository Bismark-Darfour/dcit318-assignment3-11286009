using System;

/// <summary>
/// Represents a student in the grading system
/// Demonstrates data encapsulation and grade calculation logic
/// </summary>
public class Student
{
    /// <summary>
    /// Student ID - unique identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Student's full name
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Student's score (0-100)
    /// </summary>
    public int Score { get; set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    public Student()
    {
        FullName = string.Empty;
    }

    /// <summary>
    /// Parameterized constructor
    /// </summary>
    /// <param name="id">Student ID</param>
    /// <param name="fullName">Student's full name</param>
    /// <param name="score">Student's score</param>
    public Student(int id, string fullName, int score)
    {
        Id = id;
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
        Score = score;
    }

    /// <summary>
    /// Calculates the letter grade based on score
    /// Demonstrates switch expressions (C# 8.0+ feature)
    /// </summary>
    /// <returns>Letter grade (A, B, C, D, F)</returns>
    public char GetGrade()
    {
        return Score switch
        {
            >= 90 => 'A',
            >= 80 => 'B',
            >= 70 => 'C',
            >= 60 => 'D',
            _ => 'F'
        };
    }

    /// <summary>
    /// Gets a descriptive grade status
    /// </summary>
    /// <returns>Grade status description</returns>
    public string GetGradeStatus()
    {
        return GetGrade() switch
        {
            'A' => "Excellent",
            'B' => "Good",
            'C' => "Satisfactory",
            'D' => "Needs Improvement",
            'F' => "Failing",
            _ => "Unknown"
        };
    }

    /// <summary>
    /// String representation of the student
    /// </summary>
    /// <returns>Formatted string with student information</returns>
    public override string ToString()
    {
        return $"ID: {Id}, Name: {FullName}, Score: {Score}, Grade: {GetGrade()}";
    }

    /// <summary>
    /// Determines if two students are equal based on ID
    /// </summary>
    /// <param name="obj">Object to compare with</param>
    /// <returns>True if students have same ID</returns>
    public override bool Equals(object? obj)
    {
        return obj is Student other && Id == other.Id;
    }

    /// <summary>
    /// Gets hash code based on student ID
    /// </summary>
    /// <returns>Hash code</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
