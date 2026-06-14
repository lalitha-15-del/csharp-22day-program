using System;

namespace HospitalRegistrationSystem
{
    class Patient
    {
        public string PatientID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
    }

    class RegistrationManager
    {
        public static Patient RegisterPatient()
        {
            Patient patient = new Patient();

            patient.PatientID = $"PAT-{DateTime.Now.Year}-001";

            while (true)
            {
                try
                {
                    Console.Write("Enter Patient Name: ");
                    patient.Name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(patient.Name))
                        throw new Exception("Name cannot be empty.");

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Enter Age: ");
                    patient.Age = Convert.ToInt32(Console.ReadLine());

                    if (patient.Age <= 0 || patient.Age >= 120)
                        throw new Exception("Age must be between 1 and 119.");

                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Please enter a valid numeric age.");
                }
            }
            while (true)
            {
                try
                {
                    Console.Write("Enter Gender (Male/Female/Other): ");
                    patient.Gender = Console.ReadLine().ToString();
                    if (patient.Gender != "Male" && patient.Gender != "Female"
                        && patient.Gender != "Others")
                        throw new Exception("Enter valid Gender");
                   
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            while (true)
            {
                try
                {
                    Console.Write("Enter Phone Number: ");
                    patient.PhoneNumber = Console.ReadLine();

                    if (patient.PhoneNumber.Length != 10 ||
                        !long.TryParse(patient.PhoneNumber, out _))
                        throw new Exception("Phone number must contain exactly 10 digits.");

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.Write("Enter City: ");
            patient.City = Console.ReadLine();

            return patient;
        }

        public static void PrintSlip(Patient patient)
        {
            Console.WriteLine("\n[Registration Complete]\n");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("PATIENT REGISTRATION SLIP");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Date: {DateTime.Now:d}");
            Console.WriteLine($"Patient ID: {patient.PatientID}");
            Console.WriteLine($"Name: {patient.Name}");
            Console.WriteLine($"Age: {patient.Age}");
            Console.WriteLine($"Gender: {patient.Gender}");
            Console.WriteLine($"Contact: {patient.PhoneNumber}");
            Console.WriteLine($"Location: {patient.City}");
            Console.WriteLine("--------------------------------------------------");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("HOSPITAL PATIENT REGISTRATION SYSTEM\n");

            Patient patient = RegistrationManager.RegisterPatient();

            RegistrationManager.PrintSlip(patient);
        }
    }
}