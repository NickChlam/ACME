using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ACM.API.Data;
using ACM.API.DTO;
using ACM.BL;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ACM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository _repo;
        private readonly IMapper _mapper;

        public CustomerController(CustomerRepository repo, IMapper mapper)
        {
            _repo = repo; 
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            
            var customers = await _repo.getAllCustomers();
           
            var customersToReturn = _mapper.Map<IEnumerable<CustomerToReturn>>(customers); // map from source to destination
            
            if( customersToReturn != null  && customers.Count > 0)
            {
                return Ok(customersToReturn);
            }
            
            return NoContent();
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<IActionResult > GetCustomer(int id)
        {
            var customer = await _repo.getCustomer(id);
           
            Console.WriteLine(customer);
            return Ok(customer);
            

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(CustomerForUpdateDTO custUpdate, int id)
        {
            // get customer 
            var customerFromRepo = await _repo.getCustomer(id);

            if(customerFromRepo != null)
            {
                _mapper.Map(custUpdate, customerFromRepo);
                if(await _repo.SaveAll())
                {
                    return Accepted();
                } 
                else {
                    return BadRequest("Failed to save");
                }
            }

            return NotFound(custUpdate);

        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerForCreationDTO custDto)
        {
            var customer = _mapper.Map<Customer>(custDto);
            
            _repo.add(customer);
            
            if(await _repo.SaveAll()){
              
                return CreatedAtRoute("GetCustomer", new {id = customer.CustomerId}, customer);
            }

             throw new Exception("Creating the message failed to save");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            // get customer
            var custFromRepo = await _repo.getCustomer(id);
            
            if(custFromRepo != null)
            {
                _repo.Delete(custFromRepo);

                if( await _repo.SaveAll())
                {
                    return Ok(custFromRepo);
                }
                
            }

            return BadRequest();
        }
    }
}