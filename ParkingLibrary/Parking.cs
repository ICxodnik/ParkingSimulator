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
        public List<Car> Cars = new List<Car>();
        private List<Transaction> Tracsactions = new List<Transaction>();
        private Timer paymentTimer;
        private Timer retentionTimer;
        public decimal Balance { get; set; } = 0;

        private Logger logger = new Logger("Transactions.log");

        public string AddCar(Car car)
        {
            if (GetFreePlace() > 0)
            {
                if (!Cars.Exists(x => x == car))
                {
                    Cars.Add(car);
                    return "Done.";
                }
                return "Car already exist";
            }
            else return "Don't have free place";
        }

        public string StartWorking()
        {
            paymentTimer = new Timer(Timer, 0, new TimeSpan(0, 0, 10), Settings.Timer);
            retentionTimer = new Timer((object obj) => DumpLastTransactions(), 0, 0, 60000);
            return "Done.";

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

        public string RemoveCar(int id)
        {
            
            if (Cars.Exists(x => x.Id == id))
            {
                Cars = Cars.Where(x => x.Id != id).ToList();
            }
            else return "Car don't exist";
            return "Done.";
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

        public string DebitMoney(Car car)
        {
            Transaction transaction = new Transaction(car.Id, GetPayment(car), DateTime.Now);
            Balance += transaction.payment;

            Tracsactions.Add(transaction);

            var log = $"{transaction.date.ToUniversalTime()} - transfer {transaction.payment} grn from car {transaction.carId}";
            logger.WriteLine(log);
            return "Done.";

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

        public decimal GetSumMinute()
        {
            decimal sum = 0;
            var transac = GetTransactions();
            foreach (Transaction tranc in transac)
                sum += tranc.payment;
            return sum;
        }
        public int GetBusyPlace()
        {
            return Cars.Count;
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

        public string AddBalanceCar(decimal balance, int id)
        {
            Cars.First(x => x.Id == id).AddBalance(balance);
            return "Done.";

        }
    }
}
