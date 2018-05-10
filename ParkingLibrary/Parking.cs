using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLibrary
{
    public class Parking : IDisposable
    {
        private List<Car> Cars = new List<Car>();
        private List<Tracsaction> Tracsactions = new List<Tracsaction>();
        decimal Balance { get; set; } = 0;
        decimal BalanceMinute { get; set; } = 0;

        private Logger logger = new Logger("Transactions.log");

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

        private decimal GetPayment(Car car)
        {
            var found = Settings.Prices.TryGetValue(car.Type, out decimal price);
            if (!found)
            {
                throw new ArgumentException($"Type {(int)car.Type} not found");
            }
            if (car.Balance >= price)
            {
                return price;
            }
            return Settings.Fine * price;
        }

        public void DebitMoney(Car car)
        {
            Tracsaction transaction = new Tracsaction(car.Id, GetPayment(car), DateTime.Now);
            Balance += transaction.payment;
            BalanceMinute += transaction.payment;

            Tracsactions.Add(transaction);
            Console.WriteLine("DebitMoney");

            var log = $"{transaction.date.ToUniversalTime()} - transfer {transaction.payment} grn from car {transaction.carId}";
            logger.WriteLine(log);
            Console.WriteLine(log);
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

        public void Dispose()
        {
            logger.Dispose();
        }
    }
}
