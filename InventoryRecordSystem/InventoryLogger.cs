using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace InventoryRecordSystem;

/// <summary>
/// Generic inventory logger that can handle any type implementing IInventoryEntity
/// Demonstrates generic programming with constraints and file I/O operations
/// </summary>
/// <typeparam name="T">Type must implement IInventoryEntity interface</typeparam>
public class InventoryLogger<T> where T : IInventoryEntity
{
    /// <summary>
    /// Internal log storage for inventory items
    /// </summary>
    private readonly List<T> _log;

    /// <summary>
    /// File path for persistent storage
    /// </summary>
    private readonly string _filePath;

    /// <summary>
    /// JSON serialization options for consistent formatting
    /// </summary>
    private readonly JsonSerializerOptions _jsonOptions;

    /// <summary>
    /// Constructor that initializes the logger with a file path
    /// </summary>
    /// <param name="filePath">Path where data will be saved/loaded</param>
    public InventoryLogger(string filePath)
    {
        _log = new List<T>();
        _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        Console.WriteLine($"📝 InventoryLogger initialized with file path: {_filePath}");
    }

    /// <summary>
    /// Adds an item to the log
    /// </summary>
    /// <param name="item">Item to add to the log</param>
    /// <exception cref="ArgumentNullException">Thrown when item is null</exception>
    /// <exception cref="InvalidOperationException">Thrown when item with same ID already exists</exception>
    public void Add(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        // Check for duplicate IDs
        if (_log.Any(existing => existing.Id == item.Id))
            throw new InvalidOperationException($"Item with ID {item.Id} already exists in the log");

        _log.Add(item);
        Console.WriteLine($"✅ Added item to log: ID {item.Id}");
    }

    /// <summary>
    /// Returns all items in the log
    /// </summary>
    /// <returns>Read-only collection of all logged items</returns>
    public List<T> GetAll()
    {
        return new List<T>(_log); // Return a copy to maintain encapsulation
    }

    /// <summary>
    /// Gets the count of items in the log
    /// </summary>
    public int Count => _log.Count;

    /// <summary>
    /// Finds an item by ID
    /// </summary>
    /// <param name="id">ID to search for</param>
    /// <returns>Item if found, null otherwise</returns>
    public T? FindById(int id)
    {
        return _log.FirstOrDefault(item => item.Id == id);
    }

    /// <summary>
    /// Removes an item by ID
    /// </summary>
    /// <param name="id">ID of item to remove</param>
    /// <returns>True if item was removed, false if not found</returns>
    public bool RemoveById(int id)
    {
        var item = _log.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            _log.Remove(item);
            Console.WriteLine($"🗑️  Removed item with ID {id}");
            return true;
        }
        return false;
    }

    /// <summary>
    /// Clears all items from the log
    /// </summary>
    public void Clear()
    {
        int count = _log.Count;
        _log.Clear();
        Console.WriteLine($"🧹 Cleared {count} items from log");
    }

    /// <summary>
    /// Serializes all items to a JSON file
    /// Uses proper exception handling and resource disposal
    /// </summary>
    /// <exception cref="IOException">Thrown when file operations fail</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when access is denied</exception>
    public void SaveToFile()
    {
        Console.WriteLine($"💾 Saving {_log.Count} items to file: {_filePath}");

        try
        {
            // Ensure directory exists
            string? directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                Console.WriteLine($"📁 Created directory: {directory}");
            }

            // Serialize to JSON
            string jsonData = JsonSerializer.Serialize(_log, _jsonOptions);

            // Write to file using proper resource disposal
            using (var writer = new StreamWriter(_filePath, false))
            {
                writer.Write(jsonData);
            }

            Console.WriteLine($"✅ Successfully saved {_log.Count} items to {_filePath}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"❌ Access denied when saving to {_filePath}: {ex.Message}");
            throw;
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine($"❌ Directory not found when saving to {_filePath}: {ex.Message}");
            throw;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"❌ IO error when saving to {_filePath}: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Unexpected error when saving to {_filePath}: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Deserializes items from JSON file into the log collection
    /// Uses proper exception handling and resource disposal
    /// </summary>
    /// <exception cref="FileNotFoundException">Thrown when file doesn't exist</exception>
    /// <exception cref="JsonException">Thrown when JSON is invalid</exception>
    /// <exception cref="IOException">Thrown when file operations fail</exception>
    public void LoadFromFile()
    {
        Console.WriteLine($"📖 Loading data from file: {_filePath}");

        try
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine($"⚠️  File {_filePath} does not exist. Starting with empty log.");
                return;
            }

            string jsonData;

            // Read from file using proper resource disposal
            using (var reader = new StreamReader(_filePath))
            {
                jsonData = reader.ReadToEnd();
            }

            if (string.IsNullOrWhiteSpace(jsonData))
            {
                Console.WriteLine($"⚠️  File {_filePath} is empty. Starting with empty log.");
                return;
            }

            // Deserialize from JSON
            var loadedItems = JsonSerializer.Deserialize<List<T>>(jsonData, _jsonOptions);

            if (loadedItems != null)
            {
                _log.Clear();
                _log.AddRange(loadedItems);
                Console.WriteLine($"✅ Successfully loaded {_log.Count} items from {_filePath}");
            }
            else
            {
                Console.WriteLine($"⚠️  No items found in {_filePath}");
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"❌ File not found: {_filePath}: {ex.Message}");
            throw;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"❌ Invalid JSON format in {_filePath}: {ex.Message}");
            throw;
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"❌ Access denied when reading {_filePath}: {ex.Message}");
            throw;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"❌ IO error when reading {_filePath}: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Unexpected error when loading from {_filePath}: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Gets statistical information about the logged items
    /// </summary>
    /// <returns>Statistics summary</returns>
    public string GetStatistics()
    {
        if (_log.Count == 0)
            return "No items in log";

        var ids = _log.Select(item => item.Id).ToList();
        return $"Total Items: {_log.Count}, Min ID: {ids.Min()}, Max ID: {ids.Max()}";
    }
}
