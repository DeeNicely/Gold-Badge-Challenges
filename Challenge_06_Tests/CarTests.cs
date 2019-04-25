using System;
using System.Collections.Generic;
using Challenge_06_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_06_Tests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        
        public void AddCarToList()
        {
            CarRepository carRepository = new CarRepository();
            Car carOne = new Car(CarType.Electric, 10, "2017 Chevy", "Bolt EV LT", 16500, 25998m);
            Car carTwo = new Car();
            carRepository.AddCarToList(carOne); 

            carRepository.AddCarToList(carTwo);
            List<Car> newCarInformation = carRepository.GetListOfCars();

            int actual = newCarInformation.Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(newCarInformation.Contains(carTwo));
        }

        [TestMethod]
        public void RemoveClaim()
        {
            CarRepository carRepo = new CarRepository();
            Car car = new Car();

            Car carOne = new Car(CarType.Electric, 10, "2017 Chevy", "Bolt EV LT", 16500, 25998m);

            carRepo.AddCarToList(car);
            carRepo.AddCarToList(carOne);
            carRepo.RemoveCar(carOne);

            int actual = carRepo.GetListOfCars().Count;
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }
    }  
}
