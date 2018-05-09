using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLibrary
{
    public class Car
    {
        string Id { get; set; }
        long Balance { get; set; }
        CarType Type { get; set; }
    }
}