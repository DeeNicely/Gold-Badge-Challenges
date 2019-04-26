using System;
using System.Collections.Generic;
using Challenge_05_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_05_Tests
{
    [TestClass]
    public class EmailTests
    {
        
        [TestMethod]

        public void AddCustomerToEmailList()
        {
            private EmailRepository _emailRepo = new emailRepository();
            Email contentOne = new Email(CustomerType.Current, "Pitt", "Brad", "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
            Email contentTwo = new Email();
            emailRepository.AddCustomerToEmailList(contentOne);

            emailRepository.AddCustomerrToList(contentTwo);
            List<Email> newCustomerInformation = emailRepository.GetListOfCustomers();

            int actual = newCustomerInformation.Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(newCustomrInformation.Contains(customerrTwo));
        }

        [TestMethod]
        public void RemoveCustomer()
        {
            EmailRepository _emailRepo = new EmailRepository();
            Email customerr = new Email();

            Email customerOne = new Email(CustomerType.Current, "Pitt", "Brad", "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");

            _emailRepo.AddCustomerToEmailList();
            _emailRepo.AddCustomerToEmailList(contentOne);
            _emailRepo.RemoveCustomer(contentTne);

            int actual = _emailRepo.GetListOfCustomers().Count;
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }
    }
}
