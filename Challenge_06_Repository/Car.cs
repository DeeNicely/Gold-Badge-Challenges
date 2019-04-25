using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_06_Repository
{

    public enum CarType
    {
        Electric = 1,
        Hybrid = 2,
        Gas = 3
    }
    public class Car
    {
        public CarType TypeOfCar { get; set; }
        public int CarID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Mileage { get; set; }
        public decimal Price { get; set; }

        public Car() { }

        public Car(CarType typeOfCar, int carID, string make, string model, int mileage, decimal price)
        {
            TypeOfCar = typeOfCar;
            CarID = carID;
            Make = make;
            Model = model;
            Mileage = mileage;
            Price = price;
        }

    }
}
