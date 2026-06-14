using System;
using System.Collections.Generic;

class PatientRecord
{
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal BillAmount { get; set; }
    public string Status { get; set; }
}

class Program
{
    static void Main()
    {
        List<PatientRecord> patients = new List<PatientRecord>
        {
            new PatientRecord
            {
                Name = "John Doe",
                Department = "General",
                BillAmount = 500,
                Status = "Discharged"
            },

            new PatientRecord
            {
                Name = "Jane Smith",
                Department = "Dental",
                BillAmount = 1200,
                Status = "Admitted"
            },

            new PatientRecord
            {
                Name = "Bob Brown",
                Department = "General",
                BillAmount = 400,
                Status = "Discharged"
            },

            new PatientRecord
            {
                Name = "Alice Wilson",
                Department = "Ortho",
                BillAmount = 2500,
                Status = "Admitted"
            },

            new PatientRecord
            {
                Name = "Sam Kumar",
                Department = "Dental",
                BillAmount = 800,
                Status = "Discharged"
            }
        };

        int totalPatients = 0;
        decimal totalRevenue = 0;

        int generalCount = 0;
        int dentalCount = 0;
        int orthoCount = 0;

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("       DAILY HOSPITAL ACTIVITY REPORT");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Date: {DateTime.Now:d}");
        Console.WriteLine();

        Console.WriteLine("Patient List:");

        int serialNo = 1;

        foreach (PatientRecord patient in patients)
        {
            Console.WriteLine(
                $"{serialNo}. {patient.Name} - {patient.Department} - ₹{patient.BillAmount}");

            serialNo++;

            totalPatients++;
            totalRevenue += patient.BillAmount;

            if (patient.Department == "General")
                generalCount++;
            else if (patient.Department == "Dental")
                dentalCount++;
            else if (patient.Department == "Ortho")
                orthoCount++;
        }

        Console.WriteLine();
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("SUMMARY STATISTICS");
        Console.WriteLine("--------------------------------------------------");

        Console.WriteLine($"Total Patients Visited: {totalPatients}");
        Console.WriteLine($"Total Revenue: ₹{totalRevenue}");

        Console.WriteLine();
        Console.WriteLine("Traffic by Department:");

        Console.WriteLine($"General: {generalCount}");
        Console.WriteLine($"Dental:  {dentalCount}");
        Console.WriteLine($"Ortho:   {orthoCount}");

        Console.WriteLine();
        Console.WriteLine("End of Report.");
        Console.WriteLine("--------------------------------------------------");
    }
}