using System;
using Xunit;
using ACM.BL;
using ACM.BL.repo;
using System.Collections.Generic;
using System.Linq;

namespace ACM.BLTest
{
    public class CustomerRepoTest
    {
    
        [Fact(Skip = "specific CustomerRepo")]
        public void RetrieveTest()
        {
            var custRepo = new CustomerRepository();
            var expected = new Customer();
            expected.EmailAddress = "Chlam2003@gmail.com";
            expected.FirstName = "Nick";
            expected.LastName = "Chlam";
            expected.AddressList = new List<Address>()
                {
                    new Address()
                    {
                        AddressType = 1,
                        Street1 = "1560 Boulder Ave",
                        Street2 = "Apt 310",
                        City = "Denver",
                        State = "Colorado",
                        Country = "USA",
                        PostalCode = "80211"
                    },
                    new Address()
                    {
                        AddressType = 2,
                        Street1 = "1561 Boulder Ave",
                        Street2 = "Apt 999",
                        City = "Denver",
                        State = "Colorado",
                        Country = "USA",
                        PostalCode = "80211"
                    }
                };
            
            var actual = custRepo.Retrieve(1);

            Assert.Equal(expected.FirstName, actual.FirstName);
            

            for (int i = 0 ; i < actual.AddressList.Count() - 1 ; i++)
            {
                expected.AddressList.ElementAt(1);
                Assert.Equal(expected.AddressList.ElementAt(i).AddressId, actual.AddressList.ElementAt(i).AddressId);
                Assert.Equal(expected.AddressList.ElementAt(i).City, actual.AddressList.ElementAt(i).City);
                Assert.Equal(expected.AddressList.ElementAt(i).AddressType, actual.AddressList.ElementAt(i).AddressType);
                Assert.Equal(expected.AddressList.ElementAt(i).Country, actual.AddressList.ElementAt(i).Country);
                Assert.Equal(expected.AddressList.ElementAt(i).PostalCode, actual.AddressList.ElementAt(i).PostalCode);
            }
        }

        [Fact (Skip = "Skip Retrieve")]
        public void RetriveAllTest()
        {
        //Given
            var custRepo = new CustomerRepository();
            List<Customer> list = new List<Customer>()
                    {
                        new Customer(){ FirstName = "Nick", LastName = "Chlam"},
                        new Customer(){ FirstName = "Jack", LastName = "Smith"},
                        new Customer(){ FirstName = "Sarah", LastName = "Rose"}
                    };

        //When
        var actual = custRepo.RetrieveAll(list);

      
        //Then

        Assert.Equal("Nick", actual[0].FirstName);
        
        }
    }
}