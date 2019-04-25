using System;
using System.Collections.Generic;
using Challenge_01_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_01_Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void AddItemToMenuTest()
        {
            Menu_Repository menuRepo = new Menu_Repository();
            MenuOrder contentOne = new MenuOrder(3, "chicken combo", "combo meal", "bun, chicken pattie, mayo, lettuce", 6.95m);


            menuRepo.AddToList(contentOne);
            List<MenuOrder> content = menuRepo.GetMenuOrdersList();

            int actual = menuRepo.GetMenuOrdersList().Count;
            int expected = 1;

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(menuRepo.GetMenuOrdersList().Contains(contentOne));

        }


        [TestMethod]
        public void RemoveProduct()
        {
            Menu_Repository menuRepo = new Menu_Repository();
            MenuOrder meal = new MenuOrder();

            MenuOrder mealThree = new MenuOrder(3, "chicken combo", "combo meal", "bun, chicken pattie, mayo, lettuce", 6.95m);

            menuRepo.AddToList(meal);

            menuRepo.AddToList(mealThree);
            menuRepo.RemoveMeal(mealThree);

            int actual = menuRepo.GetMenuOrdersList().Count;
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }
    }
}
