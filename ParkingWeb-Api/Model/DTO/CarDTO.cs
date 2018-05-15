using ParkingLibrary;
using ParkingWeb_Api.Model.DTO;
using ParkingWeb_Api.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingWeb_Api.Model.DTO
{
    public class CarDTO
    {
        public decimal Balance { get; set; }
        public CarType Type { get; set; }
    }
}
