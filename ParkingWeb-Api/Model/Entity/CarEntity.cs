using ParkingLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingWeb_Api.Model.Entity
{
    public class CarEntity
    {
        [Key]
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public CarType Type { get; set; }
    }
}
