using System;
using System.Globalization;
using ProjetoInterface.Entities;
using ProjetoInterface.Services;

namespace ProjetoInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter rent data\nModel: ");
                string model = Console.ReadLine();
                Console.Write("Pickup (dd/MM/yyyy HH:mm): ");
                DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                Console.Write("Return (dd/MM/yyyy HH:mm): ");
                DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                Console.Write("Price per hour: $ ");
                double pricePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Price per day: $ ");
                double pricePerDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                CarRent carRent = new CarRent(start, finish, new Vehicle(model));
                RentalService rentalService = new RentalService(pricePerDay, pricePerHour, carRent, new BrazilTaxService());

                carRent.Invoice = new Invoice(rentalService.BasicPayment, rentalService.Tax, rentalService.TotalPayment);

                Console.WriteLine("INVOICE");
                Console.WriteLine(carRent.Invoice);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}
