using System;
using Xunit;
using ACM.BL;
using ACM.BL.repo;
using System.Collections.Generic;


namespace ACM.BLTest
{
    public class ProductRepositoryTest
    {
        [Fact (Skip = "specific reason")]
        public void SaveTestValid()
        {
        //Given
        var prodRepo = new ProductRepository();
        var updateProduct = new Product()
        {
            Description = "This is a description",
            ProductName = "Product1",
            CurrentPrice = 18M
            
        };
        //When
        var actual = prodRepo.Save(updateProduct);
        var expected = true;

        //Then

        Assert.Equal(expected, actual);
        }

        [Fact (Skip = "specific reason")]
        public void SaveTestInValid()
        {
             //Given
            var prodRepo = new ProductRepository();
            var updateProduct = new Product()
            {
                Description = "This is a description",
                ProductName = "ProductName",
                CurrentPrice = null,
            };
            //When
            var actual = prodRepo.Save(updateProduct);
            var expected = false;

            //Then

            Assert.Equal(expected, actual);
        }
    }
}