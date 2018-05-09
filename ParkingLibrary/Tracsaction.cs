using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ParkingLibrary
{
    public class Tracsaction
    {
        DateTime Date { get; set; }
        Car Car { get; set; }
        public decimal Payment { get; private set; }

        public Tracsaction(Car car)
        {
            Date = DateTime.Now;
            this.Car = car;
            Settings.Prices.TryGetValue(Car.Type, out decimal price);
            if (Car.Balance >= price)
            {
                Payment = price;
            }
            else
            {
                Payment = Settings.Fine * price;
            }
            Console.WriteLine(" Tracsaction ");
            if (!File.Exists("Transactions.log"))
            {
                File.Create("Transactions.log");
            }

            //var file = File.AppendText("Transactions.log");
            //file.Write(Date + " / " + Car.Id + " / " + Payment + " grn");
             Console.WriteLine(Date + " / " + Car.Id + " / " + Payment + " grn");
        }
    }
}