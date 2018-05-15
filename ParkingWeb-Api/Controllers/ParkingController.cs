using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingLibrary;

namespace ParkingWeb_Api.Controllers
{
    [Route("api/Parking/[action]")]
    public class ParkingController : Controller
    {
        Parking _parking;

        public ParkingController(Parking parking)
        {
            _parking = parking;
        }

        public int GetFreePlace()
        {
            return _parking.GetFreePlace();
        }

        public int GetBusyPlace()
        {
            return _parking.GetBusyPlace();
        }

        public decimal GetProfit()
        {
            return _parking.Balance;
        }
    }
}
