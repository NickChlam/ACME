using System;
using System.Collections.Generic;
using Acme.Common;

namespace ACM.BL
{
    
    public class Customer
    {
       
        public Customer()
        {
            AddressList = new List<Address>();
        }
        public int CustomerId { get; private set; }
        public int CustomerType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public ICollection<Address> AddressList { get; set; }
        public string FullName 
        {
            get { return $"{LastName},{FirstName}"; }
        }

       

        public override string ToString()
        {
            return FullName;
        }

      
    }
}