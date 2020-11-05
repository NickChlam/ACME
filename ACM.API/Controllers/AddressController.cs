using Microsoft.AspNetCore.Mvc;
using ACM.API.Data;
using System.Threading.Tasks;
using ACM.BL;
using ACM.API.DTO;
using AutoMapper;
using System;

namespace ACM.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly AddressRepository _repo;

        private readonly CustomerRepository _custRepo;
        private readonly IMapper _mapper;

        public AddressController(AddressRepository repo, CustomerRepository custRepo, IMapper mapper)
        {
            _mapper = mapper;
            _custRepo = custRepo;
            _repo = repo;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getAdressesOfCustomer(int id)
        {
            var addresses = await _repo.GetAddresses(id);

            if(addresses == null)
            {
               throw new System.InvalidOperationException($"id {id} is not valid");
            }

            return Ok(addresses);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddAddress( AddressForCreationDTO address, int id)
        {
            // does user exist 
            var customer = await _custRepo.getCustomer(id);
            Console.WriteLine(ModelState.IsValid);
            if (customer != null && ModelState.IsValid )
            {
               
                var addToSave = _mapper.Map<Address>(address);
                
                customer.AddressList.Add(addToSave);

                if(await _repo.SaveAll())
                {
                    return Ok(customer);
                }
            }

            return BadRequest(ModelState);
        }

        // queryable - gets an address by 
        // /api/Address/?addressId=36
        [HttpGet]
        public async Task<IActionResult> GetAddressById(int addressId)
        {
            var address = await _repo.GetAddress(addressId);
            return Ok(address);
        }

        // delete - deletes an address by address id. 
        // /api/address/id 
        [HttpDelete("{addressId}")]
        public async Task<IActionResult> DeleteAddress(int addressId)
        {
            var address = await _repo.GetAddress(addressId);
            _repo.Delete(address);

            if(await _repo.SaveAll())
            {
                return NoContent();
            }
            
            return BadRequest();
        }



    }
}