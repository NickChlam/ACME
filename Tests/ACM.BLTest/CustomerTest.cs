using System;
using Xunit;
using ACM.BL;

namespace ACM.BLTest
{
    
    
    public class CustomerTest
    {
        [Theory (Skip = "Testing APIs")]
        [InlineData("Nick", "Chlam")]
        [InlineData("Sarah", "Rose")]
        [InlineData("Dudley", "Dog")]
        public void FullNameTest(string first, string last)
        {
           // arrange 
            Customer cust = new Customer();
            cust.FirstName = first;
            cust.LastName = last;
            string expected = $"{last},{first}";
            // act 
            string actual = cust.FullName;
            // assert 
            Assert.Equal(expected, actual);
        }
        
        // [Fact]
        // public void InstanceCounntTest()
        // {
        //     Customer cust1 = new Customer(1);
          
        //     int count = Customer.InstanceCount;

        //     Assert.Equal(3, count);

        // }
    
    }
}