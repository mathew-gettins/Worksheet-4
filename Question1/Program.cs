using System;
using System.Text;

namespace Question1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string name;
            string idNumber;
            double hoursWorked;
            double hourlyPayRate;

            // Get employee name and validate
            do
            {
                Console.Write("Enter employee name: ");
                name = Console.ReadLine();
            } while (!ValidateName(name));

            // Get employee ID number and validate
            do
            {
                Console.Write("Enter employee ID number: ");
                idNumber = Console.ReadLine();
            } while (!ValidateIdNumber(idNumber));

            // Get hours worked and validate
            hoursWorked = GetValidDoubleInput("Enter hours worked: ", "Hours worked must be a number between 10 and 50.", 10, 50);

            // Get hourly pay rate and validate
            hourlyPayRate = GetValidDoubleInput("Enter hourly pay rate: ", "Hourly pay rate must be a number between 10 and 65.", 10, 65);

            // Calculate tax and take home pay
            double grossPay = CalculateGrossPay(hoursWorked, hourlyPayRate);
            double taxRate = CalculateTaxRate(grossPay);
            double taxAmount = CalculateTaxAmount(grossPay, taxRate);
            double takeHomePay = CalculateTakeHomePay(grossPay, taxAmount);

            // Display results
            Console.WriteLine("Employee name: {0}", name);
            Console.WriteLine("Employee ID number: {0}", idNumber);
            Console.WriteLine("Gross pay: {0:C}", grossPay);
            Console.WriteLine("Tax rate: {0:P}", taxRate);
            Console.WriteLine("Tax amount: {0:C}", taxAmount);
            Console.WriteLine("Take home pay: {0:C}", takeHomePay);

            Console.ReadLine();
        }

        static bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Employee name is required. Please try again.");
                return false;
            }
            return true;
        }

        static bool ValidateIdNumber(string idNumber)
        {
            if (string.IsNullOrWhiteSpace(idNumber) || idNumber.Length != 6 || !idNumber.StartsWith("E"))
            {
                Console.WriteLine("Employee ID number must be 6 characters long and start with 'E'. Please try again.");
                return false;
            }
            return true;
        }

        static double GetValidDoubleInput(string prompt, string errorMessage, double minValue, double maxValue)
        {
            double inputValue;
            bool isInputValid;

            do
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out inputValue) && inputValue >= minValue && inputValue <= maxValue)
                {
                    isInputValid = true;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                    isInputValid = false;
                }
            } while (!isInputValid);

            return inputValue;
        }

        static double CalculateGrossPay(double hoursWorked, double hourlyPayRate)
        {
            return hoursWorked * hourlyPayRate;
        }

        static double CalculateTaxRate(double grossPay)
        {
            if (grossPay <= 3000)
            {
                return 0.0;
            }
            else if (grossPay <= 34000)
            {
                return 0.2;
            }
            else
            {
                return 0.4;
            }
        }

        static double CalculateTaxAmount(double grossPay, double taxRate)
        {
            return grossPay * taxRate;
        }

        static double CalculateTakeHomePay(double grossPay, double taxAmount)
        {
            return grossPay - taxAmount;
        }
    }
}
