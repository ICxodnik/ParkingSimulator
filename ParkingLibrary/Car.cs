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
        private int generatorID = 0;
        private int GeneratorID { get => generatorID++; }


        public Car(decimal balance, CarType type)
        {
            Balance = balance;
            Type = type;
            Id = GeneratorID;
        }
        public void ReplenishBalance(decimal replenish)
        {
            Balance += replenish;
        }
    }
}