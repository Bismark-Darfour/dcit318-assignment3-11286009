using HealthcareSystem;

/// <summary>
/// Main entry point for the Healthcare System
/// Demonstrates Collections, Generics, and data management in C#
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("🏥 Healthcare Management System");
            Console.WriteLine("Demonstrating Collections and Generics in C#");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine();

            // Step 1: Instantiate HealthSystemApp
            var healthSystemApp = new HealthSystemApp();

            // Step 2: Call SeedData()
            healthSystemApp.SeedData();

            // Step 3: Call BuildPrescriptionMap()
            healthSystemApp.BuildPrescriptionMap();

            // Step 4: Print all patients
            healthSystemApp.PrintAllPatients();

            // Step 5: Display system statistics
            healthSystemApp.DisplaySystemStatistics();

            // Step 6: Select one PatientId and display all prescriptions for that patient
            Console.WriteLine("=== Patient Prescription Details ===");
            
            // Show prescriptions for Patient ID 1 (John Smith)
            healthSystemApp.PrintPrescriptionsForPatient(1);
            
            // Show prescriptions for Patient ID 2 (Sarah Johnson)
            healthSystemApp.PrintPrescriptionsForPatient(2);
            
            // Show prescriptions for Patient ID 3 (Michael Brown)
            healthSystemApp.PrintPrescriptionsForPatient(3);

            // Demonstrate generic repository features
            healthSystemApp.DemonstrateGenericFeatures();

            // Interactive demonstration
            Console.WriteLine("=== Interactive Demo ===");
            Console.WriteLine("Enter a Patient ID to view their prescriptions (or 'exit' to quit):");
            
            while (true)
            {
                Console.Write("Patient ID: ");
                var input = Console.ReadLine();
                
                if (input?.ToLower() == "exit")
                {
                    break;
                }
                
                if (int.TryParse(input, out int patientId))
                {
                    healthSystemApp.PrintPrescriptionsForPatient(patientId);
                }
                else
                {
                    Console.WriteLine("Please enter a valid Patient ID or 'exit'.");
                }
            }

            Console.WriteLine("\nThank you for using the Healthcare Management System!");
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
