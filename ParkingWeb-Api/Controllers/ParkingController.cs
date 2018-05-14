using Microsoft.AspNetCore.Mvc;
using ParkingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingWeb_Api.Controllers
{
    //-Кількість вільних місць(GET)
    //-Кількість зайнятих місць(GET)
    //-Загальний дохід(GET)
    public class ParkingController : Controller
    {
        public int GetFreePlace()
        {
           return  Parking.Instance.GetFreePlace();
        }

        public int GetBusyPlace()
        {
            return Parking.Instance.GetFreePlace();
        }

        public decimal GetProfit()
        {
            return Parking.Instance.Balance;
        }

    }
}
