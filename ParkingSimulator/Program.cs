using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLibrary;

namespace ParkingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Parking.Instance.AddCar(new Car(50, CarType.Motorcycle));
            Parking.Instance.AddCar(new Car(10, CarType.Bus));
            Parking.Instance.AddCar(new Car(15, CarType.Truck));

            Parking.Instance.StartWorking();

            while (true)
            {
                Menu.Instance.BasicMenu();

                var input = Console.ReadKey();
                Console.WriteLine();
                switch (input.KeyChar)
                {
                    case '0':
                        Menu.Instance.ShowBalanceOfCar();
                        break;
                    case '1':
                        Menu.Instance.AddNewcar();
                        break;
                    case '2':
                        Menu.Instance.RemoveCar();
                        break;
                    case '3':
                        Menu.Instance.AddBalance();
                        break;
                    case '4':
                        Menu.Instance.ShowListOfCars();
                        break;
                    case '5':
                        Menu.Instance.CountFreeSpace();
                        break;
                    case '6':
                        Menu.Instance.CountBusySpace();
                        break;
                    case '7':
                        Menu.Instance.ShowLog();
                        break;
                    case '8':
                        Menu.Instance.TotalParkingIncome();
                        break;
                    case '9':
                        Menu.Instance.ParkingIncomeByLastMinute();
                        break;
                    case 'q':
                        Console.Clear();
                        break;
                    default:
                        Menu.Instance.IncorectInput();
                        break;
                }

            }
        }
    }
}
