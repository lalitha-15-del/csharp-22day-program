using System;

class Bill
{
    public string PatientName { get; set; }
    public int Age { get; set; }
    public decimal BaseAmount { get; set; }
    public decimal Discount { get; set; }
    public decimal Tax { get; set; }
    public decimal NetAmount { get; set; }
}

class Program
{
    static void Main()
    {
        const decimal CONSULTATION_FEE = 500m;
        const decimal BLOOD_TEST_FEE = 200m;
        const decimal XRAY_FEE = 1000m;
        const decimal ADMISSION_FEE = 2000m;

        Bill bill = new Bill();

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("       HOSPITAL BILLING CALCULATOR");
        Console.WriteLine("--------------------------------------------------");

        while (true)
        {
            try
            {
                Console.Write("Patient Name: ");
                bill.PatientName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(bill.PatientName))
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
                Console.Write("Patient Age: ");
                bill.Age = Convert.ToInt32(Console.ReadLine());

                if (bill.Age <= 0)
                    throw new Exception("Enter valid age.");

                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        bool consultationAdded = false;

        while (true)
        {
            try
            {
                Console.WriteLine("\nAdd Services:");
                Console.WriteLine("1. Consultation (500)");
                Console.WriteLine("2. Blood Test (200)");
                Console.WriteLine("3. X-Ray (1000)");
                Console.WriteLine("4. Admission (2000)");
                Console.WriteLine("5. Done");

                Console.Write("Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        bill.BaseAmount += CONSULTATION_FEE;
                        consultationAdded = true;
                        Console.WriteLine("[Added Consultation]");
                        break;

                    case 2:
                        bill.BaseAmount += BLOOD_TEST_FEE;
                        Console.WriteLine("[Added Blood Test]");
                        break;

                    case 3:
                        bill.BaseAmount += XRAY_FEE;
                        Console.WriteLine("[Added X-Ray]");
                        break;

                    case 4:
                        bill.BaseAmount += ADMISSION_FEE;
                        Console.WriteLine("[Added Admission]");
                        break;

                    case 5:
                        goto BillingComplete;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    BillingComplete:

        if (bill.Age > 60)
        {
            bill.Discount = bill.BaseAmount * 0.20m;
        }
        else if (bill.Age < 10 && consultationAdded)
        {
            bill.Discount = CONSULTATION_FEE * 0.50m;
        }

        decimal amountAfterDiscount = bill.BaseAmount - bill.Discount;

        bill.Tax = amountAfterDiscount * 0.05m;

        bill.NetAmount = amountAfterDiscount + bill.Tax;

        Console.WriteLine("\n[Calculating Bill...]\n");

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("            FINAL BILL INVOICE");
        Console.WriteLine("--------------------------------------------------");

        if (bill.Age > 60)
            Console.WriteLine($"Patient: {bill.PatientName} (Senior Citizen)");
        else if (bill.Age < 10)
            Console.WriteLine($"Patient: {bill.PatientName} (Child)");
        else
            Console.WriteLine($"Patient: {bill.PatientName}");

        Console.WriteLine();

        Console.WriteLine($"Base Amount: {bill.BaseAmount}");
        Console.WriteLine($"Discount: -{bill.Discount}");
        Console.WriteLine($"Tax (5%):+{bill.Tax}");

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"TOTAL PAYABLE:{bill.NetAmount}");
        Console.WriteLine("--------------------------------------------------");
    }
}