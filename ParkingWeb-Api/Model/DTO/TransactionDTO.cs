using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingWeb_Api.Model.DTO
{
    public class TransactionDTO
    {
        public string CarID { get; set; }
        public decimal Payment { get; set; }
    }
}
