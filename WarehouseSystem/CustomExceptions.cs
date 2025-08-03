namespace WarehouseSystem
{
    /// <summary>
    /// Custom exception thrown when attempting to add an item with a duplicate ID
    /// </summary>
    public class DuplicateItemException : Exception
    {
        /// <summary>
        /// Constructor with custom message
        /// </summary>
        /// <param name="message">Error message describing the duplicate item issue</param>
        public DuplicateItemException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor with custom message and inner exception
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">Inner exception that caused this exception</param>
        public DuplicateItemException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Custom exception thrown when an item is not found in the inventory
    /// </summary>
    public class ItemNotFoundException : Exception
    {
        /// <summary>
        /// Constructor with custom message
        /// </summary>
        /// <param name="message">Error message describing the item not found issue</param>
        public ItemNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor with custom message and inner exception
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">Inner exception that caused this exception</param>
        public ItemNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Custom exception thrown when an invalid quantity is provided
    /// </summary>
    public class InvalidQuantityException : Exception
    {
        /// <summary>
        /// Constructor with custom message
        /// </summary>
        /// <param name="message">Error message describing the invalid quantity issue</param>
        public InvalidQuantityException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor with custom message and inner exception
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="innerException">Inner exception that caused this exception</param>
        public InvalidQuantityException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
