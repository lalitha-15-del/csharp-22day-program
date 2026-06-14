using System;

class VitalSigns
{
    public string PatientName { get; set; }
    public double Temperature { get; set; }
    public int OxygenLevel { get; set; }
    public int PulseRate { get; set; }
}

class Program
{
    static void Main()
    {
        VitalSigns vitals = new VitalSigns();

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("       VITAL SIGNS MONITOR");
        Console.WriteLine("--------------------------------------------------");

        while (true)
        {
            try
            {
                Console.Write("Enter Patient Name: ");
                vitals.PatientName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(vitals.PatientName))
                    throw new Exception("Patient name cannot be empty.");

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
                Console.Write("Enter Temperature (C): ");
                vitals.Temperature = Convert.ToDouble(Console.ReadLine());

                if (vitals.Temperature < 30 || vitals.Temperature > 45)
                    throw new Exception("Enter valid temperature.");

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
                Console.Write("Enter Oxygen Level (%): ");
                vitals.OxygenLevel = Convert.ToInt32(Console.ReadLine());

                if (vitals.OxygenLevel < 0 || vitals.OxygenLevel > 100)
                    throw new Exception("Oxygen level must be between 0 and 100.");

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
                Console.Write("Enter Pulse Rate (BPM): ");
                vitals.PulseRate = Convert.ToInt32(Console.ReadLine());

                if (vitals.PulseRate <= 0)
                    throw new Exception("Enter valid pulse rate.");

                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        string status;
        string reason;

        if (vitals.Temperature > 39.0 ||
            vitals.OxygenLevel < 90 ||
            vitals.PulseRate < 50 ||
            vitals.PulseRate > 120)
        {
            status = "CRITICAL / EMERGENCY";

            if (vitals.Temperature > 39.0)
                reason = "High Temperature";
            else if (vitals.OxygenLevel < 90)
                reason = "Low Oxygen Level";
            else
                reason = "Abnormal Pulse Rate";
        }
        else if (vitals.Temperature > 37.5 ||
                 vitals.OxygenLevel < 95 ||
                 vitals.PulseRate > 100)
        {
            status = "OBSERVATION NEEDED";

            if (vitals.Temperature > 37.5)
                reason = "Elevated Temperature";
            else if (vitals.OxygenLevel < 95)
                reason = "Low Oxygen Level";
            else
                reason = "High Pulse Rate";
        }
        else
        {
            status = "NORMAL";
            reason = "All Vitals Within Normal Range";
        }

        Console.WriteLine("\n[Analyzing Data...]\n");

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("       MEDICAL ASSESSMENT REPORT");
        Console.WriteLine("--------------------------------------------------");

        Console.WriteLine($"Patient: {vitals.PatientName}");
        Console.WriteLine();

        Console.WriteLine("Vitals Recorded:");
        Console.WriteLine($"- Temp:   {vitals.Temperature} C");
        Console.WriteLine($"- Oxygen: {vitals.OxygenLevel} %");
        Console.WriteLine($"- Pulse:  {vitals.PulseRate} BPM");
        Console.WriteLine();

        Console.WriteLine($"Status Assessment: {status}");
        Console.WriteLine($"(Reason: {reason})");
        Console.WriteLine();

        if (status == "CRITICAL / EMERGENCY")
            Console.WriteLine("Action: Immediate medical attention required.");
        else if(status == "OBSERVATION NEEDED")
            Console.WriteLine("Action: Nurse to monitor every hour.");
        else
            Console.WriteLine("Action: Nurse to monitor every hour.");

        Console.WriteLine("--------------------------------------------------");
    }
}