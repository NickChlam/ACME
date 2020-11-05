using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.API.DTO;
using ACM.BL;
using Microsoft.EntityFrameworkCore;

namespace ACM.API.Data
{
    public class AddressRepository : RepoBase
    {
        public AddressRepository(DataContext context) : base(context)
        {
        }

        public async Task<Customer> GetAddresses(int CustomerId)
        {
            // get customer Id 
            var address = await _context.Customers.Include(x => x.AddressList).FirstOrDefaultAsync(x => x.CustomerId == CustomerId);

            return address;

        }
        public async Task<Address> GetAddress(int addressId)
        {
            var address = await _context.Address.FirstOrDefaultAsync(x => x.AddressId == addressId);
           

            return address;


        }

        
    }
}