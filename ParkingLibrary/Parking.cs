using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLibrary
{
    public class Parking
    {
        private List<Car> Cars = new List<Car>();
        private List<Tracsaction> Tracsactions = new List<Tracsaction>();
        decimal Balance { get; set; } = 0;
        decimal BalanceMinute { get; set; } = 0;

        public void AddCar(Car car)
        {
            if(!Cars.Exists(x=> x == car))
            {
                Cars.Add(car);
            }
            else throw new Exception("Car already exist");

        }

        public void StartWorking()
        {
            TimerCallback tm = new TimerCallback(Timer);
            Timer timer =  new Timer(tm, 0, new TimeSpan(0, 0, 10), Settings.Timer);
            Timer timerMinute = new Timer(GetMinute, 0, 0, 25000);
            Console.WriteLine("StartWorking");
            
        }

        public void Timer(object obj)
        {
            Cars.ForEach(x => DebitMoney(x));
            Console.WriteLine("Timer");
        }

        public void RemoveCar(Car car)
        {
            if (Cars.Exists(x => x == car))
            {
                Cars.Remove(car);
            }
            else throw new ArgumentNullException("Car don't exist");
            Console.WriteLine("DeleteCar");
        }

        public void DebitMoney(Car car)
        {
            Tracsaction tracsaction = new Tracsaction(car);
            Balance += tracsaction.Payment;
            BalanceMinute += tracsaction.Payment;
            Tracsactions.Add(tracsaction);
            Console.WriteLine("DebitMoney");
        }

        public int GetFreePlace()
        {
            return Settings.ParkingSpace - Cars.Count;
        }

        public void GetMinute(object obj)
        {
            Console.WriteLine(BalanceMinute + " = profit for minute");
            BalanceMinute = 0;
        }
    }
}
