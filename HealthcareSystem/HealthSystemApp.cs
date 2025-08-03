namespace HealthcareSystem
{
    /// <summary>
    /// Main application class for the Healthcare System
    /// Demonstrates collections, generics, and data management
    /// </summary>
    public class HealthSystemApp
    {
        /// <summary>
        /// Generic repository for managing patients
        /// </summary>
        private Repository<Patient> _patientRepo;

        /// <summary>
        /// Generic repository for managing prescriptions
        /// </summary>
        private Repository<Prescription> _prescriptionRepo;

        /// <summary>
        /// Dictionary mapping patient IDs to their prescriptions
        /// Demonstrates efficient data grouping and retrieval
        /// </summary>
        private Dictionary<int, List<Prescription>> _prescriptionMap;

        /// <summary>
        /// Constructor initializes repositories and prescription map
        /// </summary>
        public HealthSystemApp()
        {
            _patientRepo = new Repository<Patient>();
            _prescriptionRepo = new Repository<Prescription>();
            _prescriptionMap = new Dictionary<int, List<Prescription>>();
        }

        /// <summary>
        /// Seeds the system with sample patient and prescription data
        /// </summary>
        public void SeedData()
        {
            Console.WriteLine("=== Seeding Healthcare System Data ===\n");

            // Add sample patients
            _patientRepo.Add(new Patient(1, "John Smith", 45, "Male"));
            _patientRepo.Add(new Patient(2, "Sarah Johnson", 32, "Female"));
            _patientRepo.Add(new Patient(3, "Michael Brown", 67, "Male"));

            Console.WriteLine("Added 3 patients to the system.");

            // Add sample prescriptions
            _prescriptionRepo.Add(new Prescription(101, 1, "Lisinopril", new DateTime(2025, 7, 15)));
            _prescriptionRepo.Add(new Prescription(102, 1, "Metformin", new DateTime(2025, 7, 20)));
            _prescriptionRepo.Add(new Prescription(103, 2, "Ibuprofen", new DateTime(2025, 7, 18)));
            _prescriptionRepo.Add(new Prescription(104, 2, "Vitamin D3", new DateTime(2025, 8, 1)));
            _prescriptionRepo.Add(new Prescription(105, 3, "Atorvastatin", new DateTime(2025, 7, 25)));

            Console.WriteLine("Added 5 prescriptions to the system.\n");
        }

        /// <summary>
        /// Builds the prescription mapping dictionary
        /// Groups prescriptions by patient ID for efficient lookup
        /// </summary>
        public void BuildPrescriptionMap()
        {
            Console.WriteLine("=== Building Prescription Map ===");

            // Clear existing map
            _prescriptionMap.Clear();

            // Get all prescriptions and group by PatientId
            var allPrescriptions = _prescriptionRepo.GetAll();

            foreach (var prescription in allPrescriptions)
            {
                // If patient ID not in dictionary, create new list
                if (!_prescriptionMap.ContainsKey(prescription.PatientId))
                {
                    _prescriptionMap[prescription.PatientId] = new List<Prescription>();
                }

                // Add prescription to the patient's list
                _prescriptionMap[prescription.PatientId].Add(prescription);
            }

            Console.WriteLine($"Prescription map built successfully with {_prescriptionMap.Count} patient(s).\n");
        }

        /// <summary>
        /// Prints all patients in the system
        /// </summary>
        public void PrintAllPatients()
        {
            Console.WriteLine("=== All Patients in System ===");

            var patients = _patientRepo.GetAll();

            if (patients.Count == 0)
            {
                Console.WriteLine("No patients found in the system.");
                return;
            }

            foreach (var patient in patients)
            {
                Console.WriteLine(patient.ToString());
            }

            Console.WriteLine($"\nTotal patients: {patients.Count}\n");
        }

        /// <summary>
        /// Prints all prescriptions for a specific patient
        /// </summary>
        /// <param name="patientId">The ID of the patient</param>
        public void PrintPrescriptionsForPatient(int patientId)
        {
            Console.WriteLine($"=== Prescriptions for Patient ID: {patientId} ===");

            // First, get patient information
            var patient = _patientRepo.GetById(p => p.Id == patientId);
            if (patient == null)
            {
                Console.WriteLine($"Patient with ID {patientId} not found.");
                return;
            }

            Console.WriteLine($"Patient: {patient.Name} (Age: {patient.Age}, Gender: {patient.Gender})");
            Console.WriteLine();

            // Get prescriptions from the map
            var prescriptions = GetPrescriptionsByPatientId(patientId);

            if (prescriptions.Count == 0)
            {
                Console.WriteLine("No prescriptions found for this patient.");
            }
            else
            {
                Console.WriteLine("Prescriptions:");
                foreach (var prescription in prescriptions.OrderBy(p => p.DateIssued))
                {
                    Console.WriteLine($"  • {prescription.MedicationName} (Prescribed: {prescription.DateIssued:yyyy-MM-dd})");
                }
                Console.WriteLine($"\nTotal prescriptions: {prescriptions.Count}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Retrieves prescriptions for a specific patient from the dictionary
        /// </summary>
        /// <param name="patientId">The patient ID</param>
        /// <returns>List of prescriptions for the patient</returns>
        public List<Prescription> GetPrescriptionsByPatientId(int patientId)
        {
            if (_prescriptionMap.ContainsKey(patientId))
            {
                return new List<Prescription>(_prescriptionMap[patientId]); // Return copy
            }
            return new List<Prescription>(); // Return empty list if not found
        }

        /// <summary>
        /// Displays system statistics
        /// </summary>
        public void DisplaySystemStatistics()
        {
            Console.WriteLine("=== Healthcare System Statistics ===");
            Console.WriteLine($"Total Patients: {_patientRepo.Count}");
            Console.WriteLine($"Total Prescriptions: {_prescriptionRepo.Count}");
            Console.WriteLine($"Patients with Prescriptions: {_prescriptionMap.Count}");
            
            if (_prescriptionMap.Count > 0)
            {
                var avgPrescriptionsPerPatient = _prescriptionRepo.Count / (double)_prescriptionMap.Count;
                Console.WriteLine($"Average Prescriptions per Patient: {avgPrescriptionsPerPatient:F1}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demonstrates generic repository functionality
        /// </summary>
        public void DemonstrateGenericFeatures()
        {
            Console.WriteLine("=== Demonstrating Generic Repository Features ===");

            // Find patient by name using generic predicate
            var johnSmith = _patientRepo.GetById(p => p.Name.Contains("John"));
            if (johnSmith != null)
            {
                Console.WriteLine($"Found patient by name: {johnSmith}");
            }

            // Find prescription by medication name
            var lisinopril = _prescriptionRepo.GetById(p => p.MedicationName == "Lisinopril");
            if (lisinopril != null)
            {
                Console.WriteLine($"Found prescription: {lisinopril}");
            }

            // Count prescriptions for a specific patient using LINQ
            var patientPrescriptionCount = _prescriptionRepo.GetAll()
                .Where(p => p.PatientId == 1)
                .Count();
            Console.WriteLine($"Patient ID 1 has {patientPrescriptionCount} prescriptions");

            Console.WriteLine();
        }
    }
}
