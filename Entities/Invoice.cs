using System;
using System.Globalization;

namespace ProjetoInterface.Entities
{
    class Invoice
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }
        public double TotalPayment
        {
            get { return BasicPayment + Tax; }
        }

        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public override string ToString()
        {
            return "Basic payment: $ " + BasicPayment.ToString("F2", CultureInfo.InvariantCulture)
                + "\nTax: $ " + Tax.ToString("F2", CultureInfo.InvariantCulture)
                + "\nTotalPayment: $ " + TotalPayment.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
