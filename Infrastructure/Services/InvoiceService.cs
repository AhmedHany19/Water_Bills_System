using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public static class InvoiceService
    {
        public static DateTime DateNow = DateTime.Now;
        public static DateTime from = new DateTime(DateNow.Year, DateNow.Month, 1);
        public static DateTime to = from.AddMonths(1).AddDays(-1);
        public static decimal totalBill(decimal totalInvoice, decimal taxValue, decimal serviceFee)
        {


            var totalBilling = totalInvoice + taxValue + serviceFee;
            return totalBilling;
        }
        public static int amountConsumptionCal(int currentConsumption, int perviuosConsumption)
        {
            var amount = currentConsumption - perviuosConsumption;
            return amount;
        }
        public static decimal wastewaterConsumptionValue(decimal consumptionValue, bool isThereSanitation)
        {
            decimal value = 0;
            double percent = 0.5;
            if (isThereSanitation)
                value = consumptionValue * Decimal.Parse(percent.ToString());
            else
                value = 0;

            return value;
        }
        public static decimal taxValue(decimal totalInvoice, decimal taxRate)
        {
            var result = totalInvoice * (taxRate / 100);
            return result;
        }
        public static double waterValue(int amount, int unit)
        {
            double total = 0;

            if (unit == 1)
            {
                // Tier 5 
                if (amount > 60)
                {
                    double valInTier5 = amount - 60;
                    int valForEachTier = 60 / 4;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valForEachTier * 3;
                    double val4 = valForEachTier * 4;
                    double val5 = valInTier5 * 6;
                    total = val1 + val2 + val3 + val4 + val5;
                }
                // Tier 4
                else if (amount <= 60 && amount >= 46)
                {
                    double valInTier4 = amount - 45;
                    int valForEachTier = 45 / 3;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valForEachTier * 3;
                    double val4 = valInTier4 * 4;
                    total = val1 + val2 + val3 + val4;
                }

                // Tier 3
                else if (amount <= 45 && amount >= 31)
                {
                    double valInTier3 = amount - 30;
                    int valForEachTier = 30 / 2;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valInTier3 * 3;
                    total = val1 + val2 + val3;
                }

                // Tier 2
                else if (amount <= 30 && amount >= 16)
                {
                    double valInTier2 = amount - 15;
                    int valForEachTier = 15;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valInTier2 * 1;
                    total = val1 + val2;
                }
                // Tier 1
                // If amount <1
                else
                {
                    double val1 = amount * 0.1;
                    total = val1;
                }
            }
            if (unit == 2)
            {
                // Tier 5 
                if (amount > 120)
                {
                    double valInTier5 = amount - 120;
                    int valForEachTier = 120 / 4;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valForEachTier * 3;
                    double val4 = valForEachTier * 4;
                    double val5 = valInTier5 * 6;
                    total = val1 + val2 + val3 + val4 + val5;
                    //  total = total + (total * 50 / 100);
                }
                // Tier 4
                else if (amount <= 120 && amount >= 91)
                {
                    double valInTier4 = amount - 90;
                    int valForEachTier = 90 / 3;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valForEachTier * 3;
                    double val4 = valInTier4 * 4;
                    total = val1 + val2 + val3 + val4;
                    //  total = total + (total * 50 / 100);
                }

                // Tier 3
                else if (amount <= 90 && amount >= 61)
                {
                    double valInTier3 = amount - 60;
                    int valForEachTier = 60 / 2;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valInTier3 * 3;
                    total = val1 + val2 + val3;
                    //  total = total + (total * 50 / 100);
                }

                // Tier 2
                else if (amount <= 60 && amount >= 31)
                {
                    double valInTier2 = amount - 30;
                    int valForEachTier = 30;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valInTier2 * 1;
                    total = val1 + val2;
                    //  total = total + (total * 50 / 100);
                }
                // Tier 1
                // If amount <1
                else
                {
                    double val1 = amount * 0.1;
                    total = val1;
                    // total = total + (total * 50 / 100);
                }
            }
            if (unit == 3)
            {
                // Tier 5 
                if (amount > 180)
                {
                    double valInTier5 = amount - 180;
                    int valForEachTier = 180 / 4;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valForEachTier * 3;
                    double val4 = valForEachTier * 4;
                    double val5 = valInTier5 * 6;
                    total = val1 + val2 + val3 + val4 + val5;
                    // total = total + (total * 50 / 100);
                }
                // Tier 4
                else if (amount <= 180 && amount >= 136)
                {
                    double valInTier4 = amount - 45;
                    int valForEachTier = 135 / 3;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valForEachTier * 3;
                    double val4 = valInTier4 * 4;
                    total = val1 + val2 + val3 + val4;
                    //  total = total + (total * 50 / 100);
                }

                // Tier 3
                else if (amount <= 135 && amount >= 91)
                {
                    double valInTier3 = amount - 90;
                    int valForEachTier = 90 / 2;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valInTier3 * 3;
                    total = val1 + val2 + val3;
                    //  total = total + (total * 50 / 100);
                }

                // Tier 2
                else if (amount <= 90 && amount >= 46)
                {
                    double valInTier2 = amount - 45;
                    int valForEachTier = 45;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valInTier2 * 1;
                    total = val1 + val2;
                    // total = total + (total * 50 / 100);
                }
                // Tier 1
                // If amount <1
                else
                {
                    double val1 = amount * 0.1;
                    total = val1;
                    //  total = total + (total * 50 / 100);
                }
            }
            if (unit == 4)
            {
                // Tier 5 
                if (amount > 240)
                {
                    double valInTier5 = amount - 240;
                    int valForEachTier = 240 / 4;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valForEachTier * 3;
                    double val4 = valForEachTier * 4;
                    double val5 = valInTier5 * 6;
                    total = val1 + val2 + val3 + val4 + val5;
                }
                // Tier 4
                else if (amount <= 240 && amount >= 181)
                {
                    double valInTier4 = amount - 180;
                    int valForEachTier = 180 / 3;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valForEachTier * 3;
                    double val4 = valInTier4 * 4;
                    total = val1 + val2 + val3 + val4;
                }

                // Tier 3
                else if (amount <= 180 && amount >= 121)
                {
                    double valInTier3 = amount - 120;
                    int valForEachTier = 120 / 2;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valInTier3 * 3;
                    total = val1 + val2 + val3;
                    //  total = total + (total * 50 / 100);
                }

                // Tier 2
                else if (amount <= 120 && amount >= 61)
                {
                    double valInTier2 = amount - 60;
                    int valForEachTier = 60;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valInTier2 * 1;
                    total = val1 + val2;
                    // total = total + (total * 50 / 100);
                }
                // Tier 1
                // If amount <1
                else
                {
                    double val1 = amount * 0.1;
                    total = val1;
                    //  total = total + (total * 50 / 100);
                }
            }
            if (unit == 5)
            {
                // Tier 5 
                if (amount > 300)
                {
                    double valInTier5 = amount - 300;
                    int valForEachTier = 300 / 4;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valForEachTier * 3;
                    double val4 = valForEachTier * 4;
                    double val5 = valInTier5 * 6;
                    total = val1 + val2 + val3 + val4 + val5;
                }
                // Tier 4
                else if (amount <= 300 && amount >= 226)
                {
                    double valInTier4 = amount - 225;
                    int valForEachTier = 225 / 3;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valForEachTier * 3;
                    double val4 = valInTier4 * 4;
                    total = val1 + val2 + val3 + val4;
                }

                // Tier 3
                else if (amount <= 225 && amount >= 151)
                {
                    double valInTier3 = amount - 150;
                    int valForEachTier = 150 / 2;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valInTier3 * 3;
                    total = val1 + val2 + val3;
                }

                // Tier 2
                else if (amount <= 150 && amount >= 76)
                {
                    double valInTier2 = amount - 75;
                    int valForEachTier = 75;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valInTier2 * 1;
                    total = val1 + val2;
                }
                // Tier 1
                else
                {
                    double val1 = amount * 0.1;
                    total = val1;
                }
            }
            if (unit == 6)
            {
                // Tier 5 
                if (amount > 360)
                {
                    double valInTier5 = amount - 360;
                    int valForEachTier = 360 / 4;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valForEachTier * 3;
                    double val4 = valForEachTier * 4;
                    double val5 = valInTier5 * 6;
                    total = val1 + val2 + val3 + val4 + val5;
                }
                // Tier 4
                else if (amount <= 360 && amount >= 271)
                {
                    double valInTier4 = amount - 270;
                    int valForEachTier = 270 / 3;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valForEachTier * 3;
                    double val4 = valInTier4 * 4;
                    total = val1 + val2 + val3 + val4;
                }

                // Tier 3
                else if (amount <= 270 && amount >= 181)
                {
                    double valInTier3 = amount - 180;
                    int valForEachTier = 180 / 2;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valForEachTier * 1;
                    double val3 = valInTier3 * 3;
                    total = val1 + val2 + val3;
                }

                // Tier 2
                else if (amount <= 180 && amount >= 91)
                {
                    double valInTier2 = amount - 90;
                    int valForEachTier = 90;
                    double val1 = valForEachTier * 0.1;
                    double val2 = valInTier2 * 1;
                    total = val1 + val2;
                }
                // Tier 1
                // If amount <1
                else
                {
                    double val1 = amount * 0.1;
                    total = val1;
                }
            }

            return total;

        }
    }
}
