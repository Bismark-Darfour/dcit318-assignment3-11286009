namespace HealthcareSystem
{
    /// <summary>
    /// Represents a patient in the healthcare system
    /// Demonstrates class design with proper encapsulation
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Unique identifier for the patient
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Patient's full name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Patient's age in years
        /// </summary>
        public int Age { get; private set; }

        /// <summary>
        /// Patient's gender
        /// </summary>
        public string Gender { get; private set; }

        /// <summary>
        /// Constructor that initializes all fields
        /// </summary>
        /// <param name="id">Unique patient identifier</param>
        /// <param name="name">Patient's full name</param>
        /// <param name="age">Patient's age</param>
        /// <param name="gender">Patient's gender</param>
        public Patient(int id, string name, int age, string gender)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Age = age;
            Gender = gender ?? throw new ArgumentNullException(nameof(gender));
        }

        /// <summary>
        /// String representation of the patient
        /// </summary>
        /// <returns>Formatted patient information</returns>
        public override string ToString()
        {
            return $"Patient [ID: {Id}, Name: {Name}, Age: {Age}, Gender: {Gender}]";
        }

        /// <summary>
        /// Equality comparison based on ID
        /// </summary>
        /// <param name="obj">Object to compare with</param>
        /// <returns>True if objects are equal</returns>
        public override bool Equals(object? obj)
        {
            return obj is Patient patient && Id == patient.Id;
        }

        /// <summary>
        /// Hash code based on ID
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
