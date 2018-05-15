using ParkingWeb_Api.Model;
using ParkingWeb_Api.Model.DTO;
using ParkingWeb_Api.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingWeb_Api.Repositories
{
    //-Список всіх машин(GET)
    //-Деталі по одній машині(GET)
    //-Видалити машину(DELETE)
    //-Додати машину(POST)

    public class CarRepository
    {
        ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CarEntity> GetAll()
        {
            return _context.Cars.ToList();
        }

        public CarEntity GetCar(int id)
        {
           return _context.Cars.FirstOrDefault(car => car.Id == id);
        }

        public void  DeleteCar(int id)
        {

            _context.Cars.Remove(GetCar(id));
        }

        public void AddNewCar(CarDTO carDTO)
        {
            CarEntity car = new CarEntity()
            {
                Balance = carDTO.Balance,
                Type = carDTO.Type
            };
        }
    }
}
