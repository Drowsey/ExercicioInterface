using System;
using System.Collections.Generic;
using System.Text;
using ProjetoInterface.Entities;

namespace ProjetoInterface.Services
{
    class RentalService
    {
        public double PricePerHour { get; set; }
        public double PricePerDay { get; set; }
        public ITaxService _taxService { get; set; }

        public RentalService(double pricePerDay, double pricePerhour, ITaxService taxService)
        {
            PricePerDay = pricePerDay;
            PricePerHour = pricePerhour;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRent carRent)
        {
            TimeSpan duration = carRent.Finish.Subtract(carRent.Start);
            double basicPayment = 0;

            if (duration.TotalHours <= 12)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _taxService.Tax(basicPayment);

            carRent.Invoice = new Invoice(basicPayment, tax);

        }
    }

}
