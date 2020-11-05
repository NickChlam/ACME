using System;
using Xunit;
using ACM.BL;
using ACM.BL.repo;

namespace ACM.BLTest
{
    public class OrderRepoTests
    {
        [Fact (Skip = "specific reason")]
        public void RetriveOrderTest()
        {
        //Given
        var orderRepo = new OrderRepository();
        var expected = new Order()
        {
            OrderDate = DateTime.Now
        };
        //When
        
        //Then
        Assert.Equal(expected.OrderDate, DateTime.Now);
        }

        [Fact (Skip = "specific reason")]
        public void SaveValidTest()
        {
        //Given
            var orderRepo = new OrderRepository();
            var order = new Order();
        //When
            var actual = orderRepo.Save(order);
            var expected = true;

        
        //Then

            Assert.Equal(expected, actual);
        }
    }
}