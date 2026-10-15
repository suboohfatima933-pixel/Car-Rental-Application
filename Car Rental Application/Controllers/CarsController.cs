using Microsoft.AspNetCore.Mvc;
using Car_Rental_Application.Models;
using System.Collections.Generic;
using System.Linq;

namespace Car_Rental_Application.Controllers
{
    public class CarsController : Controller
    {
        private static List<Car> availableCars = new List<Car>
        {
            new Car { Id = 1, Name = "Alto", PricePerDay = 3000 },
            new Car { Id = 2, Name = "Corolla", PricePerDay = 6000 },
            new Car { Id = 3, Name = "Civic", PricePerDay = 8000 }
        };

        private static List<Car> bookedCars = new List<Car>();
        [HttpGet]
        public IActionResult Index()
        {
            return View(availableCars);
        }

        [HttpPost]
        public IActionResult Book(int id)
        {
            Car? car = availableCars.FirstOrDefault(car => car.Id == id);

            if (car == null)
            {
                return RedirectToAction("Index");
            }

            availableCars.Remove(car);
            bookedCars.Add(car);

            return RedirectToAction("Booked");
        }

        [HttpGet]
        public IActionResult Booked()
        {
            return View(bookedCars);
        }
    }

}