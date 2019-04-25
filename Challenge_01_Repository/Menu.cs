using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01_Repository
{
    public class MenuOrder
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string ListOfIngredients { get; set; }
        public decimal Price { get; set; }
        public MenuOrder()
        {

        }
        public MenuOrder(int mealNumber, string mealName, string description, string listOfIngredients, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            ListOfIngredients = listOfIngredients;
            Price = price;
        }

    }
}
