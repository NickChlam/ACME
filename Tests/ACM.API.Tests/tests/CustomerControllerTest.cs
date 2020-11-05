using Xunit;
using System;
using Microsoft.AspNetCore;
using System.Threading.Tasks;
using ACM.API.Controllers;
using ACM.BL;
using AutoMapper;
using ACM.API.Helpers;
using ACM.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ACM.API.DTO;
using System.Net;

namespace ACM.API.Tests.tests
{
    public class CustomerControllerTest
    {
        private IMapper _mapper;

        public CustomerControllerTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfiles>();
                cfg.AddMaps(typeof(CustomerRepository).Assembly);
            });

            var mapper = config.CreateMapper();
            _mapper = mapper;
        }

        [Fact]
        public async Task GetAllCustomersTest()
        {
            //Arrange

            // Generate a database named GetAllCustomersTest in mem
            var dbContext = DbContextMock.getDataContext(nameof(GetAllCustomersTest));

            // get a repo 
            var _repo = new CustomerRepository(dbContext);
            //var _mapper = CreateMapper();
            var controller = new CustomerController(_repo, _mapper);

            //Act
            var response = await controller.GetAllCustomers() as ObjectResult;
            //var result = response as ObjectResult;
            var value = response.Value as List<CustomerToReturn>;

            // Dispose context
            dbContext.Dispose();


            //Assert

            // should return three items from the seeding
            Assert.Equal(3, value.Count);


        }

        [Fact]
        public async Task GetOneCustomerTest()
        {
            //Arrange 

            // Generate a database names GetOneCustomerTest in mem
            var dbContext = DbContextMock.getDataContext(nameof(GetOneCustomerTest));


            // get a repo 
            var _repo = new CustomerRepository(dbContext);
            var controller = new CustomerController(_repo, _mapper);

            // Act

            var response = await controller.GetCustomer(1) as ObjectResult;
            var result = response.Value as Customer;

            var expected = "Chlam,Nick";

            // Dispose context
            dbContext.Dispose();

            //Assert

            Assert.Equal(expected, result.FullName);


        }

        [Fact]
        public async Task UpdateCustomerTest()
        {
            //Given
            // Generate a database names UpdateCsutomerTest in mem
            var dbContext = DbContextMock.getDataContext(nameof(UpdateCustomerTest));

            // get a repo 
            var _repo = new CustomerRepository(dbContext);
            var controller = new CustomerController(_repo, _mapper);

            // create customer for update 
            var customerUpdate = new CustomerForUpdateDTO()
            {
                CustomerType = 1,
                FirstName = "John",
                LastName = "Simpson",
                EmailAddress = "chlam2003@gmail.com"
            };


            //When
            var response = await controller.UpdateCustomer(customerUpdate, 1) as ObjectResult;

            var customer = await _repo.getCustomer(1);

            dbContext.Dispose();
            //Then
            // should return a 202 accpeted response. 
            Assert.Equal(202, response.StatusCode);
            Assert.Equal("Simpson,John", customer.FullName);
        }

        [Fact]
        public async Task UpdateCustomerDoesNotExistTest()
        {
            //Given
            // Generate a database names GetAllCustomersTest in mem
            var dbContext = DbContextMock.getDataContext(nameof(UpdateCustomerDoesNotExistTest));

            // get a repo 
            var _repo = new CustomerRepository(dbContext);
            var controller = new CustomerController(_repo, _mapper);
            // create a customerForoUpdate bject 
            var customerUpdate = new CustomerForUpdateDTO()
            {
                CustomerType = 1,
                FirstName = "John",
                LastName = "Simpson",
                EmailAddress = "chlam2003@gmail.com"
            };
            //When
            var result = await controller.UpdateCustomer(customerUpdate, 4) as ObjectResult;
            // Dispose context
            dbContext.Dispose();
            //Then
            Assert.Equal(404, result.StatusCode);


        }

        [Fact]
        public async Task AddCustomerTest()
        {
            //Given
            // Generate a database names AddCustomerTest in mem
            var dbContext = DbContextMock.getDataContext(nameof(AddCustomerTest));

            // get a repo 
            var _repo = new CustomerRepository(dbContext);
            var controller = new CustomerController(_repo, _mapper);

            // customer to Add
            var createdCustomer = new CustomerForCreationDTO()
            {
                CustomerType = 1,
                FirstName = "Johannes",
                LastName = "Bach",
                EmailAddress = "jb@gmail.com"
            };

            //When
            var result = await controller.AddCustomer(createdCustomer) as ObjectResult;
            var customerFromRepo = await _repo.getCustomer(4);

            // Dispose context
            dbContext.Dispose();
            //Then

            Assert.Equal(201, result.StatusCode);
            Assert.Equal(createdCustomer.FirstName, customerFromRepo.FirstName);
        }

        [Fact]
        public async Task DeleteCustomerTest()
        {
            //Given
            // Generate a database names DeleteCustomerTest in mem
            var dbContext = DbContextMock.getDataContext(nameof(DeleteCustomerTest));

            // get a repo 
            var _repo = new CustomerRepository(dbContext);
            var controller = new CustomerController(_repo, _mapper);

            //When
            var result = await controller.DeleteCustomer(1) as ObjectResult;
            var customers = await _repo.getAllCustomers();
            // Dispose context
            dbContext.Dispose();
            //Then
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(2, customers.Count);
        }


    }
}