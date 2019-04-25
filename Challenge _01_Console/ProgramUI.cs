using Challenge_01_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge__01_Console
{
    class ProgramUI
    {
        private Menu_Repository _menuRepo;
        private List<MenuOrder> _listOfContent;
        

        //This is a constructor for the ProgramUI, inside of the constructor are items I want created when an instance of ProgramUI is initialized.
        public ProgramUI()
        {
            _menuRepo = new Menu_Repository();
            _listOfContent = _menuRepo.GetMenuOrdersList();
        }

        public void Run()
        {
            // StartDialogue();
            //while (running);
            {
                Console.Clear();
                bool running = true;
                SeedMenuOrdersList();
                Menu();
            }
        }

        private void Menu()
        {
            bool running = true;
            while (running)
            {

            
            Console.WriteLine("1. Add a meal \n" +
                "2. Remove a meal\n" +
                "3. Print list\n" +
                "4. Exit");
            int input = ParseInput();
                switch (input)
                {
                    case 1:
                        AddMealNumber();
                        break;
                    case 2:
                        RemoveProduct();
                        break;
                    case 3:
                        PrintMenuOrders();
                        break;
                    case 4:
                        running = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void AddMealNumber()
        {
            Console.WriteLine("What is the meal number?");
            string mealNumberAsString = Console.ReadLine();
            int mealNumber = int.Parse(mealNumberAsString);

            Console.WriteLine("What is the mealName?");
            string mealName = Console.ReadLine();

            Console.WriteLine("What is the description of the meal?");
            string description = Console.ReadLine();

            Console.WriteLine("What are the ingredients in the meal?");
            string listOfIngredients = Console.ReadLine();

            Console.WriteLine("What is the price of the meal?");
            string priceAsString = Console.ReadLine();
            decimal price = decimal.Parse(priceAsString);

            MenuOrder newMenuItem = new MenuOrder(mealNumber, mealName, description, listOfIngredients, price);
            _menuRepo.AddToList(newMenuItem);
        }

        private void RemoveProduct()
        {
            Console.Clear();
            PrintMenuOrders();

            Console.WriteLine("What is the meal number for the order you would like to remove?");
            //int mealNumber = ParseInput();
            int mealNumber = int.Parse(Console.ReadLine());
            foreach (var meal in _listOfContent)
            {
                if (mealNumber == meal.MealNumber)
                {
                    _menuRepo.RemoveMeal(meal);
                    break;
                }
            }

            Console.ReadLine();

            Console.WriteLine("Your item has been removed.");
            Console.ReadKey();
        }

        private void PrintMenuOrders()
        {
            List<MenuOrder> meals = _menuRepo.GetMenuOrdersList();
            foreach (MenuOrder content in _listOfContent)
            {
                Console.WriteLine($"{content.MealNumber} {content.MealName} {content.Description} {content.ListOfIngredients} {content.Price}");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }

             public int ParseInput()
            {
             int input = int.Parse(Console.ReadLine());
              if (input < 1 || input > 4)
            {
                Console.WriteLine("Your input was invalid, please enter a valid menu number.");
                 input = ParseInput();
             }
                 return input;
            }

        private void SeedMenuOrdersList()
        {
            MenuOrder contentOne = new MenuOrder(3, "chicken combo", "combo meal", "bun, chicken pattie, mayo, lettuce", 6.95m);
            MenuOrder contentTwo = new MenuOrder(2, "cheeseburger combo", "combo meal", "bun, pattie, lettuce, pickle, onion, tomato, cheese", 5.95m);
            MenuOrder contentThree = new MenuOrder(1, "hamburger combo", "combo meal", "bun, pattie, lettuce, pickle, onion, tomato", 5.75m);
            
            _menuRepo.AddToList(contentOne);
            _menuRepo.AddToList(contentTwo);
            _menuRepo.AddToList(contentThree);

        }

    }
}

