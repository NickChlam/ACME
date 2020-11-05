using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.BL;
using Microsoft.EntityFrameworkCore;


namespace ACM.API.Data
{
    public class CustomerRepository : RepoBase
    {
        public CustomerRepository(DataContext context) : base(context)
        {   
        }

        
        public async Task<Customer> getCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(u => u.CustomerId == id);
            
            return customer;
        }
        public async Task<List<Customer>> getAllCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

     
    }
}