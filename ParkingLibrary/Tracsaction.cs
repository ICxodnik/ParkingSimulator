using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ParkingLibrary
{
    public class Transaction
    {
        public readonly DateTime date;
        public readonly int carId;
        public readonly decimal payment;

        public Transaction(int carId, decimal payment, DateTime date)
        {
            this.date = date;
            this.carId = carId;
            this.payment = payment;
        }
    }
}