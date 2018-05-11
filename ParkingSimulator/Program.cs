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
            Parking park = new Parking();
            park.AddCar(new Car(50, CarType.Motorcycle));
            park.AddCar(new Car(10, CarType.Bus));
            park.AddCar(new Car(15, CarType.Truck));


            park.StartWorking();

            while (true)
            {
                Menu.BasicMenu();

                var input = Console.ReadKey();
                switch (input.KeyChar)
                {

                    case '1':
                        Console.WriteLine("select car type or input q back to main menu");
                        Console.WriteLine("1 - Passenger");
                        Console.WriteLine("2 - Truck");
                        Console.WriteLine("3 - Bus");
                        Console.WriteLine("4 -Motorcycle");
                        int type = Convert.ToInt32(Console.ReadKey());
                        Console.WriteLine(park.AddCar(new Car((CarType)type)));
                        Console.ReadKey();
                        Menu.BasicMenu();
                        break;
                    case '2':
                        Console.WriteLine("Input id car or input q back to main menu");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(park.RemoveCar(id));
                        Console.ReadKey();
                        Menu.BasicMenu();
                        break;
                    case '3':
                        Console.WriteLine("Input id car or input q back to main menu");
                        int idcar = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input balance or input q back to main menu");
                        decimal balance = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(park.AddBalanceCar(balance, idcar));
                        Console.ReadKey();
                        Menu.BasicMenu();
                        break;
                    case '4':
                        foreach(Car car in park.Cars)
                            Console.WriteLine($"Id {car.Id}, type {car.Type}, balance{car.Balance}");
                        Console.ReadKey();
                        Menu.BasicMenu();
                        break;
                    case '5':
                        Console.WriteLine("Count free places " + park.GetFreePlace());
                        Console.ReadKey();
                        Menu.BasicMenu();
                        break;
                    case '6':
                        Console.WriteLine("Count busy places " + park.GetBusyPlace());
                        Console.ReadKey();
                        Menu.BasicMenu();
                        break;
                    case '7':
                        var transac = park.GetTransactions();
                        foreach (Transaction tranc in transac)
                            Console.WriteLine($"Id {tranc.carId}, date {tranc.date}, payment{tranc.payment} grn");
                        Console.ReadKey();
                        Menu.BasicMenu();
                        break;
                    case '8':
                        Console.WriteLine("Total parking balance " + park.Balance);
                        Console.ReadKey();
                        Menu.BasicMenu();
                        break;
                    case '9':
                        Console.WriteLine("Balance for last minute " + park.GetSumMinute());
                        Console.ReadKey();
                        Menu.BasicMenu();
                        break;
                    case 'q':
                        Console.Clear();
                        Menu.BasicMenu();
                        break;
                    default:
                        Console.WriteLine("Incorect input");
                        break;
                }
            }

        }
    }
}
