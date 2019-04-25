using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_05_Repository
{
    class EmailRepository
    {
        public List<Email> _listOfCustomers = new List<Email>();

        public void AddCustomerToEmailList(Email newCustomerInformation)
        {
            _listOfCustomers.Add(newCustomerInformation);
        }
        public List<Email> GetListOfCustomersByType()
        {
            return _listOfCustomers;
        }

        public void RemoveCustomer(Email newCustomerInformation)
        {
            _listOfCustomers.Remove(newCustomerInformation);
        }
        public bool RemoveCustomer(string lastName)
        {
            bool removed = false;
            foreach (Email newCustomerInformation in _listOfCustomers)
            {
                if (newCustomerInformation.LastName == lastName)
                {
                    RemoveCustomer(newCustomerInformation);
                    removed = true;
                    break;
                }
            }
            return removed;
        }
        
    }
}

