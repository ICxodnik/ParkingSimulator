
using Microsoft.AspNetCore.Mvc;
using ParkingLibrary;
using ParkingWeb_Api.Model.Entity;
using ParkingWeb_Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingWeb_Api.Controllers
{
    public class TransactionController : Controller
    {
        TransactionRepository _repositoryTranc;
        CarRepository _repositoryCar;

        public TransactionController(TransactionRepository repositoryTranc, CarRepository repositoryCar, Parking parking)
        {
            _parking = parking;
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
