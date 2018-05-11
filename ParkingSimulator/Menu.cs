using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSimulator
{
    static class Menu
    {
        public static void BasicMenu()
        {
            Console.WriteLine("1 - add new car to parking place");
            Console.WriteLine("2 - remove car from parking place");
            Console.WriteLine("3 - add balance  for car");
            Console.WriteLine("4 - show list of cars on parking place");
            Console.WriteLine("5 - count free space on parking place");
            Console.WriteLine("6 - count busy space on parking place");
            Console.WriteLine("7 - show log for last minute");
            Console.WriteLine("8 - total parking income");
            Console.WriteLine("9 - parking income by last minute");
            Console.WriteLine("q - Exit");
        }
    }
}
