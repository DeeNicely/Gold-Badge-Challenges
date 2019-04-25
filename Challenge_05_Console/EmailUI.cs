using Challenge_05_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_05_Console
{
    public class EmailUI
    {
        private EmailRepository _emailRepo = new emailRepository();
        private List<Email> _listOfCustomers;

        public EmailUI()
        {
            _listOfCustomers = _emailRepo.GetListOfCustomersByType();
        }
        public void Run()
        {
            //StartDialogue();
            SeedCarList();
            bool running = true;
            while (running)
            {
                Console.Clear();
                running = Email();
            }
        }
        public bool Email()
        {
            Console.WriteLine("1. Add customer to list\n" +
                "2. Remove customer from list\n" +
                "3. Print list of customers\n" +
                "4. Print customer list by type\n" +
                "5. Update customer Information\n" +
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
                    RemoveCustomer();
                    break;
                case 3:
                    PrintCustomer();
                    break;
                case 4:
                    CustomerTypeList();
                    break;
                case 5:
                    UpdateCustomer();
                    break;
                case 6:
                    return false;
                default:

                    break;
            }
            return true;
        }


        public void AddToList()
        {
           Console.WriteLine("What type of customer is this?\n" +
                "1. Current\n" +
                "2. Past\n" +
                "3. Potential");
            int customerTypeAsInt = int.Parse(Console.ReadLine());

            //string carTypeAsString = Console.ReadLine();
            //int carTypeAsInt = int.Parse(carTypeAsString);

            CustomerType type;
            switch (customerTypeAsInt)
            {
                default:
                case 1:
                    type = CustomerType.Past;
                    break;
                case 2:
                    type = CustomerType.Current;
                    break;
                case 3:
                    type = CustomerType.Potential;
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



            Email newEmailItem = new Email(typeOfCustomer, lastName, firstName, emailMessage);
            _emailRepo.AddCustomerToList(newEmailItem);
        }
        public void CustomerByTypeList()
        {
            Console.WriteLine("View list of customers by type:\n\t" +
              "1. Past\n\t" +
              "2. Present\n\t" +
              "3. Potential\n\t");
            var typeResponse = int.Parse(Console.ReadLine());

            foreach (TypeOfCustomer customer in _listOfCustomers)
            {
                if (customer.TypeOfCustomer == (TypeOfCustomer)typeResponse)
                {
                    Console.WriteLine($" {customer.TypeOfCustomer} {customer.LastName} {customer.FirstName} {customer.EmailMessage}");
                }

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void PrintCustomer()
        {
            foreach (CustomerType customer in _listOfCustomers)
            {
                Console.WriteLine($"{customer.TypeOfCustomer} {customer.LastName} {customer.FirstName} {customer.EmailMessage}\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void RemoveCustomer()
        {
            Console.Clear();
            PrintCustomer();

            Console.WriteLine("Which customer do you want to remove?");
            int carID = int.Parse(Console.ReadLine());
            foreach (var customer in _listOfCustomers)
            {
                if (lastName == customer.LastName)
                {
                    _emailRepo.RemoveCustomer(customer);
                    break;
                }
            }

            Console.ReadLine();
            Console.WriteLine("The customer has been removed.");
            Console.ReadKey();
        }

        public void SeedCarList()
        {
            Email contentOne = new Email(CustomerType.Current, "Pitt", "Brad", "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
            Email contentTwo = new Email(CustomerType.Current, "Hemsworth", "Chris", "Thank you for your work with us. We appreciate your loyalty.Here's a coupon.");
            Email contentThree = new Email(CustomerType.Past, "Hanks", "Tom", "It's been a long time since we've heard from you, we want you back.");
            Email contentFour = new Email(CustomerType.Past, "Pool", "Dead", "It's been a long time since we've heard from you, we want you back".);
            Email contentFive = new Email(CustomerType.Potential, "Gosling", "Ryan", "We currently have the lowest rates on Helicopter Insurance!");
            Email contentSix = new Email(CustomerType.Potential, "Downing, Jr.", "Robert", "We currently have the lowest rates on Helicopter Insurance!");

            _emailRepo.AddCustomerrToList(contentOne);
            _emailRepo.AddCustomerToList(contentTwo);
            _emailRepo.AddCustomerToList(contentThree);
            _emailRepo.AddCustomerToList(contentFour);
            _emailRepo.AddCustomerToList(contentFive);
            _emailRepo.AddCustomerToList(contentSix);

        }

        public void UpdateCustomerr()
        {
            PrintCustomer();
            Console.WriteLine("Enter the last name of the customer you would like to update.");
            //int carID = int.Parse(Console.ReadLine());
            string lastName = (Console.ReadLine());
            string updateCustomer = new Customer();

            foreach (var customer in _listOfCustomers)
            {
                if (lastName == customer.LastName)
                {
                    updateCustomer = customer;
                }
            }

            Console.WriteLine("What needs to be updated?\n\t" +
              "1. Customer Type\n\t" +
              "2. Last Name\n\t" +
              "3. First Name");

            int customerInformationValue = int.Parse(Console.ReadLine());
            switch (customerInformationValue)
            {
                case 1:
                    Console.WriteLine($"Current customer type is {updateCustomer.TypeOfCustomer}\n");
                    Console.WriteLine("What is the new customer type?\n" +
                        "1. Past\n" +
                        "2. Current\n" +
                        "3. Potential");
                    int customerTypeAsInt = int.Parse(Console.ReadLine());

                    CustomerType type;
                    switch (customerTypeAsInt)
                    {
                        default:
                        case 1:
                            type = CustomerType.Past;
                            break;
                        case 2:
                            type = CustomerType.Current;
                            break;
                        case 3:
                            type = CustomerType.Potential;
                            break;
                    }
                    updateCustomer.TypeOfCustomer = type;
                    break;

                case 2:
                    Console.WriteLine($"Enter a last name");
                    string newlastName = (Console.ReadLine();
                    updateCustomer.LastName = newlastName;
                    break;


                case 3:
                    Console.WriteLine($"Enter a first name");
                    string newfirstName = (Console.ReadLine();
                    updateCustomer.FirstName = newfirstName;
                    break;
            }
        }
    }
}
