using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_05_Repository
{
    public enum CustomerType
    {
        Current = 1,
        Past = 2,
        Potential
    }
    public class Email
    {
        public CustomerType TypeOfCustomer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailMessage { get; set; }

        public Email()
        {
            
        }
        public Email(CustomerType typeOfCustomer, string firstName, string lastNmae, string emailMessage)
        {
            TypeOfCustomer = typeOfCustomer;
            FirstName = firstName;
            LastName = LastName;
            EmailMessage = emailMessage;
        }
    }
}
