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
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _repo;
        private readonly CustomerRepository _custRepo;
        private readonly IMapper _mapper;
        private readonly ProductRepository _prodRepo;

        public OrderController(OrderRepository repo, CustomerRepository custRepo, IMapper mapper, ProductRepository prodRepo)
        {
            _prodRepo = prodRepo;
            _custRepo = custRepo;
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getOrderById(int id)
        {
            var orders = await _repo.GetOrderById(id);
            return Ok(orders);
        }
        [HttpGet("Customer/{id}")]
        public async Task<IActionResult> getOrderByCustomerId(int id)
        {
            var orders = await _repo.GetOrderByCustomer(id);
            return Ok(orders);
        }
        [HttpPost]
        public async Task<IActionResult> createOrder(OrderForCreationDTO orderDTO, int custId)
        {
            Console.WriteLine(orderDTO.OrderItems[0]);
            // valdiate customer 
            var customer = await _custRepo.getCustomer(orderDTO.CustomerId);

            if (customer != null)
            {
                
                var prodToSave = _mapper.Map<Order>(orderDTO);
                // TODO : create custom model state to check products 
                var IsValid = valdidateItems(prodToSave.OrderItems);

                if(IsValid.Result == false)
                {
                    return BadRequest("Products were invalid");
                }

                prodToSave.OrderDate = DateTime.Now;

                _repo.add(prodToSave);

                if (await _repo.SaveAll())
                {
                    return Ok(prodToSave);
                }

            }

            return BadRequest();

        }

        // basic validation checkin gif product exists 
        public async Task<bool> valdidateItems(List<OrderItem> orders)
        {
            if(orders.Count > 0)
            {
                
                // loop through each item and ensure product exisits
                foreach (var item in orders)
                {
                    // get product 
                    var product =  await _prodRepo.GetProduct(item.ProductId);
                    if(product == null)
                    {
                        return await Task.FromResult(false);
                    }
                }
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }



    }
}