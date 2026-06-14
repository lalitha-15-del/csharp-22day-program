using System;
using System.Collections.Generic;

class Appointment
{
    public string PatientName { get; set; }
    public string Department { get; set; }
    public string Doctor { get; set; }
    public string TimeSlot { get; set; }
}

class Program
{
    static void Main()
    {
        List<string> departments = new List<string>
        {
            "General Medicine",
            "Dental",
            "Orthopedics"
        };

        List<string> generalDoctors = new List<string>
        {
            "Dr. A. Kumar",
            "Dr. B. Singh"
        };

        List<string> dentalDoctors = new List<string>
        {
            "Dr. C. Roy",
            "Dr. D. Gupta"
        };

        List<string> orthopedicDoctors = new List<string>
        {
            "Dr. E. Sharma",
            "Dr. F. Verma"
        };

        List<string> timeSlots = new List<string>
        {
            "10:00 AM",
            "11:00 AM",
            "12:00 PM"
        };

        Appointment appointment = new Appointment();
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("            APPOINTMENT BOOKING SYSTEM\n             ");
        Console.WriteLine("----------------------------------------------------");
        while (true)
        {
            try
            {
                Console.Write("Enter Patient Name: ");
                appointment.PatientName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(appointment.PatientName))
                    throw new Exception("Patient name cannot be empty.");

                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        int departmentChoice;

        while (true)
        {
            try
            {
                Console.WriteLine("\nSelect Department");

                for (int i = 0; i < departments.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {departments[i]}");
                }

                Console.Write("Enter Choice: ");
                departmentChoice = Convert.ToInt32(Console.ReadLine());

                if (departmentChoice < 1 || departmentChoice > departments.Count)
                    throw new Exception("Invalid Department");

                appointment.Department = departments[departmentChoice - 1];
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        List<string> selectedDoctors;

        switch (departmentChoice)
        {
            case 1:
                selectedDoctors = generalDoctors;
                break;

            case 2:
                selectedDoctors = dentalDoctors;
                break;

            default:
                selectedDoctors = orthopedicDoctors;
                break;
        }

        while (true)
        {
            try
            {
                Console.WriteLine("\nSelect Doctor");

                for (int i = 0; i < selectedDoctors.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {selectedDoctors[i]}");
                }

                Console.Write("Enter Choice: ");
                int doctorChoice = Convert.ToInt32(Console.ReadLine());

                if (doctorChoice < 1 || doctorChoice > selectedDoctors.Count)
                    throw new Exception("Invalid Doctor");

                appointment.Doctor = selectedDoctors[doctorChoice - 1];
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
                Console.WriteLine("\nSelect Time Slot");

                for (int i = 0; i < timeSlots.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {timeSlots[i]}");
                }

                Console.Write("Enter Choice: ");
                int slotChoice = Convert.ToInt32(Console.ReadLine());

                if (slotChoice < 1 || slotChoice > timeSlots.Count)
                    throw new Exception("Invalid Time Slot");

                appointment.TimeSlot = timeSlots[slotChoice - 1];
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine("\n[Booking Confirmed]\n");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("    APPOINTMENT TICKET        ");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Patient:    " + appointment.PatientName);
        Console.WriteLine("Department: " + appointment.Department);
        Console.WriteLine("Doctor:     " + appointment.Doctor);
        Console.WriteLine("Time:       " + appointment.TimeSlot);
        Console.WriteLine("Status:     Confirmed");
    }
}