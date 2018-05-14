using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingWeb_Api.Model.Entity
{
    public class TransactionEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public CarEntity Car { get; set; }
        public decimal Payment { get; set; }
    }
}
