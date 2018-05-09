using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLibrary
{
    public class Car
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public CarType Type { get; set; }
        private static int nextId = 0;
        private static int NextId { get => nextId++; }


        public Car(decimal balance, CarType type)
        {
            Balance = balance;
            Type = type;
            Id = NextId;
        }
        public void ReplenishBalance(decimal replenish)
        {
            Balance += replenish;
        }
    }
}