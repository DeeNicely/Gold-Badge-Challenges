using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01_Repository
{
    public class Menu_Repository
    {
        private List<MenuOrder> _listOfContent = new List<MenuOrder>();

        public void AddToList(MenuOrder content)
        {

            _listOfContent.Add(content);
        }
        public List<MenuOrder> GetMenuOrdersList()
        {
            return _listOfContent;
        }


        public void RemoveMeal(MenuOrder content)
        {
            _listOfContent.Remove(content);
        }

        public bool RemoveFromList(int mealNumber)
        {
            bool removed = false;
            foreach (MenuOrder content in _listOfContent)
            {
                if (content.MealNumber == mealNumber)
                {
                    RemoveMeal(content);
                    removed = true;
                    break;
                }
            }
            return true;
        }
    }
}






