using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class StudentResultProcessor
{
    public List<Student> ReadStudentsFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }

        var students = new List<Student>();
        string[] lines = File.ReadAllLines(filePath);
        
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            
            string[] parts = line.Split(',');
            if (parts.Length < 3)
            {
                throw new MissingFieldException("Invalid line format");
            }

            if (!int.TryParse(parts[0].Trim(), out int id))
            {
                throw new InvalidScoreFormatException("Invalid ID");
            }

            string name = parts[1].Trim();
            
            if (!int.TryParse(parts[2].Trim(), out int score))
            {
                throw new InvalidScoreFormatException("Invalid score");
            }

            students.Add(new Student(id, name, score));
        }
        
        return students;
    }

    public void WriteReportToFile(List<Student> students, string outputFilePath)
    {
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            writer.WriteLine("STUDENT GRADING REPORT");
            writer.WriteLine("====================");
            
            foreach (var student in students.OrderByDescending(s => s.Score))
            {
                writer.WriteLine($"{student.Id}: {student.FullName} - {student.Score} ({student.GetGrade()})");
            }
        }
    }

    public void CreateSampleInputFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("101, Alice Johnson, 95");
            writer.WriteLine("102, Bob Smith, 87");
        }
    }
}
