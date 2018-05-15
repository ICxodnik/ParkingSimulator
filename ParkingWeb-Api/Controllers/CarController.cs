using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingLibrary;
using ParkingWeb_Api.Model.DTO;

namespace ParkingWeb_Api.Controllers
{
    [Route("api/Car")]
    public class CarController : Controller
    {
        Parking _parking;

        public CarController(Parking parking)
        {
            _parking = parking;
        }

        public List<Car> GetAll()
        {
            return _parking.Cars.ToList();
        }

        [Route("{id}")]
        public Car GetCar(int id)
        {
            return _parking.Cars.FirstOrDefault(car => car.Id == id);
        }

        [HttpDelete]
        [Route("{id}")]
        public string DeleteCar(int id)
        {
            return _parking.RemoveCar(id);
        }

        [HttpPost]
        public string AddNewCar([FromBody]CarDTO carDTO)
        {
            Car car = new Car(carDTO.Balance, carDTO.Type);

            return _parking.AddCar(car);
        }
    }
}
