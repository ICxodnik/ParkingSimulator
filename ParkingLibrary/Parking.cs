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
        private List<Transaction> Tracsactions = new List<Transaction>();
        private Timer paymentTimer;
        private Timer retentionTimer;
        decimal Balance { get; set; } = 0;

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
            paymentTimer = new Timer(Timer, 0, new TimeSpan(0, 0, 10), Settings.Timer);
            retentionTimer = new Timer((object obj) => DumpLastTransactions(), 0, 0, 25000);

            Console.WriteLine("StartWorking");
        }

        private void DumpLastTransactions()
        {
            var transactions = GetTransactions(true);
            var profit = transactions.Sum(tr => tr.payment);

            logger.WriteLine($"{DateTime.Now.ToUniversalTime()} - {profit} profit accuired from {transactions.Count} transaction(s)");
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
            Transaction transaction = new Transaction(car.Id, GetPayment(car), DateTime.Now);
            Balance += transaction.payment;

            Tracsactions.Add(transaction);

            var log = $"{transaction.date.ToUniversalTime()} - transfer {transaction.payment} grn from car {transaction.carId}";
            Console.WriteLine(log);
        }

        public IList<Transaction> GetTransactions(bool removeOlder = false)
        {
            var now = DateTime.Now;
            var transactionRetentionTime = TimeSpan.FromMinutes(1);
            var transactions = Tracsactions.Where(tr => tr.date - now <= transactionRetentionTime).ToList();
            if (removeOlder)
            {
                Tracsactions = transactions;
            }
            return transactions;
        }

        public int GetFreePlace()
        {
            return Settings.ParkingSpace - Cars.Count;
        }

        public void Dispose()
        {
            paymentTimer.Dispose();
            retentionTimer.Dispose();
            logger.Dispose();
        }
    }
}
