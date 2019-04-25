using Challenge_06_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_06_Console
{
    public class CarUI
    {
        private CarRepository _carRepo = new CarRepository();
        private List<Car> _listOfCars;

        public CarUI()
        {
            _listOfCars = _carRepo.GetListOfCars();
        }
        public void Run()
        {
            //StartDialogue();
            SeedCarList();
            bool running = true;
            while (running)
            {
                Console.Clear();
                running = Car();
            }
        }
        public bool Car()
        {
            Console.WriteLine("1. Add car to list\n" +
                "2. Remove car from list\n" +
                "3. Print list of cars\n" +
                "4. Print car list by type\n" +
                "5. Update A Cars Information\n" +
                "6. Exit");
            //Console.WriteLine("Pick option\n\t" +
            //  "6. Exit Program");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    AddToList();
                    break;
                case 2:
                    RemoveCar();
                    break;
                case 3:
                    PrintCar();
                    break;
                case 4:
                    CarByTypeList();
                    break;
                case 5:
                    UpdateCar();
                    break;
                case 6:
                    return false;
                default:

                    break;
            }
            return true;
        }

        //public void Run()
        //{
        //    RunMenu();
        //}
        //public void RunMenu()
        //{
        //    bool running = true;
        //    while (running)
        //    {
        //        Console.WriteLine("1. Add car to list\n" +
        //        "2. Remove car from list\n" +
        //        "3. Print list of cars\n" +
        //        "4. Exit");
        //        int input = int.Parse(Console.ReadLine());
        //        switch (input)
        //        {
        //            case 1:
        //                AddToList();
        //                break;
        //            case 2:
        //                RemoveCar();
        //                break;
        //            case 3:
        //                PrintCar();
        //                break;
        //            case 4:
        //                running = false;
        //                break;
        //            default:

        //                break;
        //        }
        //    }


        //}



        public void AddToList()
        {
            //Console.WriteLine("What is the Car type?");
            //string carTypeAsString = Console.ReadLine();
            //int CarType = int.Parse(carTypeAsString);

            Console.WriteLine("What is the car type?\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas");
            int carTypeAsInt = int.Parse(Console.ReadLine());

            //string carTypeAsString = Console.ReadLine();
            //int carTypeAsInt = int.Parse(carTypeAsString);

            CarType type;
            switch (carTypeAsInt)
            {
                default:
                case 1:
                    type = CarType.Electric;
                    break;
                case 2:
                    type = CarType.Hybrid;
                    break;
                case 3:
                    type = CarType.Gas;
                    break;
            }
            Console.WriteLine("What is the Car ID number? ");
            string carIDAsString = Console.ReadLine();
            int carID = int.Parse(carIDAsString);

            Console.WriteLine("What is the year and make of the car?");
            string make = Console.ReadLine();

            Console.WriteLine("What is the model of the car?");
            string model = Console.ReadLine();

            Console.WriteLine("What is the mileage on the car? ");
            string mileageAsString = Console.ReadLine();
            int mileage = int.Parse(mileageAsString);

            Console.WriteLine("What is the price of the car? ($xx,xxx)");
            string priceAsString = Console.ReadLine();
            decimal price = decimal.Parse(priceAsString);



            Car newCarItem = new Car(type, carID, make, model, mileage, price);
            _carRepo.AddCarToList(newCarItem);
        }
        public void CarByTypeList()
        {
            Console.WriteLine("View list of cars by type:\n\t" +
              "1. Electric\n\t" +
              "2. Hybrid\n\t" +
              "3. Gas\n\t");
            var typeResponse = int.Parse(Console.ReadLine());

            foreach (Car car in _listOfCars)
            {
                if (car.TypeOfCar == (CarType)typeResponse)
                {
                    Console.WriteLine($"{car.CarID} {car.TypeOfCar} {car.Make} {car.Model} {car.Mileage} {car.Price}");
                }

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void PrintCar()
        {
            foreach (Car car in _listOfCars)
            {
                Console.WriteLine($"{car.CarID} {car.TypeOfCar} {car.Make} {car.Model} {car.Mileage} {car.Price}\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void RemoveCar()
        {
            Console.Clear();
            PrintCar();

            Console.WriteLine("Which car do you want to remove?");
            int carID = int.Parse(Console.ReadLine());
            foreach (var car in _listOfCars)
            {
                if (carID == car.CarID)
                {
                    _carRepo.RemoveCar(car);
                    break;
                }
            }

            Console.ReadLine();
            Console.WriteLine("The car has been removed.");
            Console.ReadKey();
        }

        public void SeedCarList()
        {
            Car contentOne = new Car(CarType.Electric, 10, "2017 Chevy", "Bolt EV LT", 16500, 25998m);
            Car contentTwo = new Car(CarType.Electric, 20, "2018 Nissan", "Leaf", 21665, 28000m);
            Car contentThree = new Car(CarType.Hybrid, 30, "2018 Ford", "Fusion", 17885, 20100m);
            Car contentFour = new Car(CarType.Hybrid, 40, "2017 Chevrolet", "Volt", 20478, 19300m);
            Car contentFive = new Car(CarType.Gas, 50, "2018 Ford", "Taurus", 11362, 20900m);
            Car contentSix = new Car(CarType.Gas, 60, "2018 Chevrolet", "Malibu", 21100, 16300m);

            _carRepo.AddCarToList(contentOne);
            _carRepo.AddCarToList(contentTwo);
            _carRepo.AddCarToList(contentThree);
            _carRepo.AddCarToList(contentFour);
            _carRepo.AddCarToList(contentFive);
            _carRepo.AddCarToList(contentSix);

        }
        //public Car GetUserInputForCar()
        //{

        //    var carType = new EnterCarType();
        //    var carID = new EnterACarID();
        //    var make = new EnterMake();
        //    var model = new EnterModel();
        //    var mileage = new EnterMileage();
        //    var price = new EnterNewPrice();

        //    return new Car(carType, carID, make, model, mileage, price);
        //}

        public void UpdateCar()
        {
            PrintCar();
            Console.WriteLine("Enter the ID of the car you would like to update.");
            int carID = int.Parse(Console.ReadLine());
            Car updateCar = new Car();

            foreach (var car in _listOfCars)
            {
                if (carID == car.CarID)
                {
                    updateCar = car;
                }
            }

            Console.WriteLine("What needs to be updated?\n\t" +
              "1. Car Type\n\t" +
              "2. Car ID\n\t" +
              "3. Make\n\t" +
              "4. Model\n\t" +
              "5. Mileage\n\t" +
              "6. Price");
            int carInformationValue = int.Parse(Console.ReadLine());
            switch (carInformationValue)
            {
                case 1:
                    Console.WriteLine($"Current car type is {updateCar.TypeOfCar}\n");
                    Console.WriteLine("What is the new car type?\n" +
                        "1. Electric\n" +
                        "2. Hybrid\n" +
                        "3. Gas");
                    int carTypeAsInt = int.Parse(Console.ReadLine());

                    CarType type;
                    switch (carTypeAsInt)
                    {
                        default:
                        case 1:
                            type = CarType.Electric;
                            break;
                        case 2:
                            type = CarType.Hybrid;
                            break;
                        case 3:
                            type = CarType.Gas;
                            break;
                    }
                    updateCar.TypeOfCar = type;
                    break;

                case 2:
                    Console.WriteLine($"Enter a new Car ID");
                    int carIdAsInt = int.Parse(Console.ReadLine());
                    updateCar.CarID = carIdAsInt;
                    break;


                case 3:
                    Console.WriteLine("Enter a new make for the car.");
                    string newMake = Console.ReadLine();
                    updateCar.Make = newMake;
                    break;

                case 4:
                    Console.WriteLine($"Enter a new model for the car.");
                    string newModel = Console.ReadLine();
                    updateCar.Model = newModel;
                    break;

                case 5:
                    Console.WriteLine($"Enter new mileage for the car.");
                    int mileageAsInt = int.Parse(Console.ReadLine());
                    updateCar.Mileage = mileageAsInt;
                    break;

                case 6:
                    Console.WriteLine($"Enter new price for the car.");
                    decimal priceAsInt = decimal.Parse(Console.ReadLine());
                    updateCar.Price = priceAsInt;
                    break;
                
            }
        }
    }
}
