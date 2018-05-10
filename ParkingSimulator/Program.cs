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

            using (Parking parking = new Parking())
            {
                parking.AddCar(new Car(50, CarType.Motorcycle));
                parking.AddCar(new Car(10, CarType.Bus));
                parking.AddCar(new Car(15, CarType.Truck));


                parking.StartWorking();
                Console.ReadLine();
            }
        }
    }
}
