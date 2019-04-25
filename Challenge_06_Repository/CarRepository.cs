using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_06_Repository
{
    public class CarRepository
    {
        public List<Car> _listOfCars = new List<Car>();

        public void AddCarToList(Car newCarInformation)
        {
            _listOfCars.Add(newCarInformation);
        }
        public List<Car> GetListOfCars()
        {
            return _listOfCars;
        }

        public void RemoveCar(Car newCarInformation)
        {
            _listOfCars.Remove(newCarInformation);
        }
        public bool RemoveCar(int carID)
        {
            bool removed = false;
            foreach (Car newCarInformation in _listOfCars)
            {
                if (newCarInformation.CarID == carID)
                {
                    RemoveCar(newCarInformation);
                    removed = true;
                    break;
                }
            }
            return removed;
        }
        //public List<Car> GetUpdatedListOfCars()
        //{
        //    return _listOfCars;
        //}
        //public Car ViewCarID(int carID)
        //{

        //    foreach (Car type in _listOfCars)
        //    {
        //        if (type.CarID == carID)
        //        {
        //            return type;
        //        }
        //    }
        //    return null;
        //}

        //public CarType GetCarListByType(int selectNumberForType)
        //{
        //    CarType type = new CarType();
        //    switch (selectNumberForType)
        //    {
        //        case 1:
        //            type = CarType.Electric;
        //            break;
        //        case 2:
        //            type = CarType.Hybrid;
        //            break;
        //        case 3:
        //            type = CarType.Gas;
        //            break;
        //    }
        //    return type;
        //}
    }
}
