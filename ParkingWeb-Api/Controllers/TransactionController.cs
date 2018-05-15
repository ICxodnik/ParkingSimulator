
using Microsoft.AspNetCore.Mvc;
using ParkingLibrary;
using ParkingWeb_Api.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingWeb_Api.Controllers
{
    [Route("api/Transaction")]
    public class TransactionController : Controller
    {
        Parking _parking;

        public TransactionController(Parking parking)
        {
            _parking = parking;
        }

        [HttpPut]
        [Route("{id}/{balance}")]
        public string PutCarBalance(int id, decimal balance)
        {
            return _parking.AddBalanceCar(balance, id);
        }

        public List<Transaction> GetTransactions()
        {
            return _parking.GetTransactionsForLastMinute().ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public List<Transaction> GetTransactions(int id)
        {
            return _parking.GetTransactionsForLastMinute().Where(trx => trx.carId == id).ToList();
        }

        [Route("GetLogFile")]
        [HttpGet]
        public string GetLogFile()
        {
            return _parking.GetTransactionLogs();
        }
    }
}
