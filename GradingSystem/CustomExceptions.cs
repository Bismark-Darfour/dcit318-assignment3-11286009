using System;

/// <summary>
/// Custom exception thrown when a score cannot be converted to an integer
/// Demonstrates custom exception handling for data validation
/// </summary>
public class InvalidScoreFormatException : Exception
{
    /// <summary>
    /// Constructor with custom message
    /// </summary>
    /// <param name="message">Error message describing the invalid score format</param>
    public InvalidScoreFormatException(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor with custom message and inner exception
    /// </summary>
    /// <param name="message">Error message describing the invalid score format</param>
    /// <param name="innerException">The original exception that caused this error</param>
    public InvalidScoreFormatException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public InvalidScoreFormatException() : base("Invalid score format detected")
    {
    }
}

/// <summary>
/// Custom exception thrown when required fields are missing from input data
/// Demonstrates custom exception handling for data validation
/// </summary>
public class MissingFieldException : Exception
{
    /// <summary>
    /// Constructor with custom message
    /// </summary>
    /// <param name="message">Error message describing the missing field</param>
    public MissingFieldException(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor with custom message and inner exception
    /// </summary>
    /// <param name="message">Error message describing the missing field</param>
    /// <param name="innerException">The original exception that caused this error</param>
    public MissingFieldException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public MissingFieldException() : base("Required field is missing")
    {
    }
}
