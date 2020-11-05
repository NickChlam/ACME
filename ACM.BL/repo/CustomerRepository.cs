using System;
using System.Collections.Generic;
using System.Linq;

namespace ACM.BL.repo
{
    public class CustomerRepository : RepoBase
    {
        private AddressRepository addressRepository {get; set;}
        public CustomerRepository()
        {
            addressRepository =  new AddressRepository();
        }

        public Customer Retrieve(int customerId)
        {
            Customer customer = new Customer();

            if(customerId == 1)
            {
                customer.EmailAddress = "Chlam2003@gmail.com";
                customer.FirstName  = "Nick";
                customer.LastName = "Chlam";
                customer.AddressList = addressRepository.RetrieveByCustomerId(customerId).ToList();
                
            }

            return customer;
        }

        public List<Customer> RetrieveAll(List<Customer> list)
        {
            return list;
        }

        
    }
}