using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLibrary
{
     public static class Settings
    {
        public readonly static TimeSpan Timer = new TimeSpan(0,0,10);
        public readonly static Dictionary<CarType, decimal> Prices = new Dictionary<CarType, decimal>
        {
            [CarType.Bus] = 5,
            [CarType.Truck] = 4,
            [CarType.Passenger] = 3,
            [CarType.Motorcycle] = 2,

        };
        public readonly static int ParkingSpace = 25;
        public readonly static decimal Fine = 1.2M;

        
    }
}
