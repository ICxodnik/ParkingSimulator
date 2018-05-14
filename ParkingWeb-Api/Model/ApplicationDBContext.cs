using Microsoft.EntityFrameworkCore;
using ParkingWeb_Api.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingWeb_Api.Model
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
