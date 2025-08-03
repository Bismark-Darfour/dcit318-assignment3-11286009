namespace HealthcareSystem
{
    /// <summary>
    /// Represents a prescription in the healthcare system
    /// Demonstrates class relationships and date handling
    /// </summary>
    public class Prescription
    {
        /// <summary>
        /// Unique identifier for the prescription
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// ID of the patient this prescription belongs to
        /// </summary>
        public int PatientId { get; private set; }

        /// <summary>
        /// Name of the prescribed medication
        /// </summary>
        public string MedicationName { get; private set; }

        /// <summary>
        /// Date when the prescription was issued
        /// </summary>
        public DateTime DateIssued { get; private set; }

        /// <summary>
        /// Constructor that initializes all fields
        /// </summary>
        /// <param name="id">Unique prescription identifier</param>
        /// <param name="patientId">ID of the patient</param>
        /// <param name="medicationName">Name of the medication</param>
        /// <param name="dateIssued">Date prescription was issued</param>
        public Prescription(int id, int patientId, string medicationName, DateTime dateIssued)
        {
            Id = id;
            PatientId = patientId;
            MedicationName = medicationName ?? throw new ArgumentNullException(nameof(medicationName));
            DateIssued = dateIssued;
        }

        /// <summary>
        /// String representation of the prescription
        /// </summary>
        /// <returns>Formatted prescription information</returns>
        public override string ToString()
        {
            return $"Prescription [ID: {Id}, PatientID: {PatientId}, Medication: {MedicationName}, Date: {DateIssued:yyyy-MM-dd}]";
        }

        /// <summary>
        /// Equality comparison based on ID
        /// </summary>
        /// <param name="obj">Object to compare with</param>
        /// <returns>True if objects are equal</returns>
        public override bool Equals(object? obj)
        {
            return obj is Prescription prescription && Id == prescription.Id;
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
