using ParkingLibrary;
using ParkingWeb_Api.Model.Entity;
using ParkingWeb_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ParkingWeb_Api.Repositories
{
    //-Вивести Transactions.log(GET)
    //-Вивести транзакції за останню хвилину(GET)
    //-Вивести транзакції за останню хвилину по одній конкретній машині(GET)
    //-Поповнити баланс машини(PUT)
    public class TransactionRepository
    {
        ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Transaction> GetLog()
        {
           return Parking.Instance.Tracsactions;
        }

        public List<Transaction> GetTrancLastMinute()
        {
            return Parking.Instance.GetTransactionsForLastMinute().ToList();
        }

        public decimal GetSumForLastMinute()
        {
            return Parking.Instance.GetSumMinute();
        }

        public void PutCarBalance(CarEntity car, decimal balance)
        {
            car.Balance = balance;
        }
    }
}

