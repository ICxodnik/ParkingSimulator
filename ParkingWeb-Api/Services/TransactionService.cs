
using ParkingLibrary;
using ParkingWeb_Api.Model.Entity;
using ParkingWeb_Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingWeb_Api.Services
{
    public class TransactionService
    {
        TransactionRepository _repositoryTranc;
        CarRepository _repositoryCar;

        public TransactionService(TransactionRepository repositoryTranc, CarRepository repositoryCar)
        {
            _repositoryTranc = repositoryTranc;
            _repositoryCar = repositoryCar;

        }

        public void PutCarBalance(int id, decimal balance)
        {
            CarEntity car = _repositoryCar.GetCar(id);
            _repositoryTranc.PutCarBalance(car, balance);

        }

        public List<Transaction> CarTransactionLastMinute(int id)
        {
            var tranc = _repositoryTranc.GetTrancLastMinute();
            return tranc.Where(x => x.carId == id).ToList();
        }
    }
}
