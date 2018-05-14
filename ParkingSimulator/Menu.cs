using ParkingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSimulator
{
    class Menu
    {
        private static Menu instance = new Menu();
        Menu()
        {

        }

        public void BasicMenu()
        {
            Console.WriteLine();
            Console.WriteLine("0 - show balance of car");
            Console.WriteLine("1 - add new car to parking place");
            Console.WriteLine("2 - remove car from parking place");
            Console.WriteLine("3 - add balance  for car");
            Console.WriteLine("4 - show list of cars on parking place");
            Console.WriteLine("5 - count free space on parking place");
            Console.WriteLine("6 - count busy space on parking place");
            Console.WriteLine("7 - show log for last minute");
            Console.WriteLine("8 - total parking income");
            Console.WriteLine("9 - parking income by last minute");
            Console.WriteLine("q - Exit \n");
        }

        public void IncorectInput()
        {
            Console.WriteLine("Incorect input");
        }

        public void ShowBalanceOfCar()
        {
            Console.WriteLine("Input id car or input q back to main menu");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int a))
            {
                int idcar = Convert.ToInt32(input);
                try
                { Console.WriteLine("Balance of car " + Parking.Instance.ShowBalanceCar(idcar)); }
                catch
                { Console.WriteLine("Car don't exist");}
            }
        }

        public void ParkingIncomeByLastMinute()
        {
            Console.WriteLine("Balance for last minute " + Parking.Instance.GetSumMinute());
        }

        public void TotalParkingIncome()
        {
            Console.WriteLine("Total parking balance " + Parking.Instance.Balance);
        }

        public void ShowLog()
        {
            var transac = Parking.Instance.GetTransactions();
            foreach (Transaction tranc in transac)
                Console.WriteLine($"Id {tranc.carId}, date {tranc.date}, payment{tranc.payment} grn");
        }

        public void CountBusySpace()
        {
            Console.WriteLine("Count busy places " + Parking.Instance.GetBusyPlace());
        }

        public void CountFreeSpace()
        {
            Console.WriteLine("Count free places " + Parking.Instance.GetFreePlace());
        }

        public void ShowListOfCars()
        {
            foreach (Car car in Parking.Instance.Cars)
                Console.WriteLine($"Id {car.Id}, type {car.Type}, balance{car.Balance}");
        }

        public void AddBalance()
        {
            Console.WriteLine("Input id car or input q back to main menu");
            int idcar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input balance or input q back to main menu");
            decimal balance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Parking.Instance.AddBalanceCar(balance, idcar));
        }

        public void RemoveCar()
        {
            Console.WriteLine("Input id car or input q back to main menu");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Parking.Instance.RemoveCar(id));
        }

        public void AddNewcar()
        {
            SelectTypeCar();
            var input = Console.ReadLine();
            if (int.TryParse(input, out int a))
            {
                int type = Convert.ToInt32(input);
                Car car = new Car((CarType)type);
                Console.WriteLine(Parking.Instance.AddCar(car));
                Console.WriteLine("Id of car " + car.Id);
            }
        }

        public void SelectTypeCar()
        {
            Console.WriteLine("select car type or input q back to main menu");
            Console.WriteLine("1 - Passenger");
            Console.WriteLine("2 - Truck");
            Console.WriteLine("3 - Bus");
            Console.WriteLine("4 - Motorcycle\n");
        }

        public static Menu Instance { get { return instance; } }
    }
}
