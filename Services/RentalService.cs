using System;
using System.Collections.Generic;
using System.Text;
using ProjetoInterface.Entities;

namespace ProjetoInterface.Services
{
    class RentalService
    {
        public CarRent CarRent { get; set; }
        public double PricePerHour { get; set; }
        public double PricePerDay { get; set; }
        public ITaxService TaxService { get; set; }
        public TimeSpan Duration
        {
            get { return CarRent.Finish.Subtract(CarRent.Start); }
        }

        public RentalService(double pricePerDay, double pricePerhour, CarRent carRent, ITaxService taxService)
        {
            PricePerDay = pricePerDay;
            PricePerHour = pricePerhour;
            CarRent = carRent;
            TaxService = taxService;
        }
        public double BasicPayment
        {
            get
            {
                if (Duration.TotalHours <= 12)
                {
                    return PricePerHour * Math.Ceiling(Duration.TotalHours);
                }
                else
                {
                    return PricePerDay * Math.Ceiling(Duration.TotalDays);
                }
            }
        }
        public double Tax
        {
            get { return TaxService.Tax(BasicPayment); }
        }

        public double TotalPayment
        {
            get { return BasicPayment + Tax; }
        }

    }
}
