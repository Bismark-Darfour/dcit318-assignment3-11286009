namespace HealthcareSystem
{
    /// <summary>
    /// Generic repository class for entity storage and retrieval
    /// Demonstrates generic programming for type safety and reusability
    /// </summary>
    /// <typeparam name="T">The type of entity to manage</typeparam>
    public class Repository<T>
    {
        /// <summary>
        /// Internal storage for entities of type T
        /// </summary>
        private List<T> items;

        /// <summary>
        /// Constructor initializes the internal storage
        /// </summary>
        public Repository()
        {
            items = new List<T>();
        }

        /// <summary>
        /// Adds an item to the repository
        /// </summary>
        /// <param name="item">The item to add</param>
        public void Add(T item)
        {
            if (item != null)
            {
                items.Add(item);
            }
        }

        /// <summary>
        /// Returns all items in the repository
        /// </summary>
        /// <returns>List of all items</returns>
        public List<T> GetAll()
        {
            return new List<T>(items); // Return a copy to maintain encapsulation
        }

        /// <summary>
        /// Gets an item by a predicate condition
        /// </summary>
        /// <param name="predicate">The condition to match</param>
        /// <returns>First matching item or null if not found</returns>
        public T? GetById(Func<T, bool> predicate)
        {
            return items.FirstOrDefault(predicate);
        }

        /// <summary>
        /// Removes an item that matches the predicate
        /// </summary>
        /// <param name="predicate">The condition to match for removal</param>
        /// <returns>True if an item was removed, false otherwise</returns>
        public bool Remove(Func<T, bool> predicate)
        {
            var itemToRemove = items.FirstOrDefault(predicate);
            if (itemToRemove != null)
            {
                return items.Remove(itemToRemove);
            }
            return false;
        }

        /// <summary>
        /// Gets the count of items in the repository
        /// </summary>
        public int Count => items.Count;
    }
}
