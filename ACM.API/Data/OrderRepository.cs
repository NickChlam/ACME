using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.BL;
using Microsoft.EntityFrameworkCore;

namespace ACM.API.Data
{
    public class OrderRepository : RepoBase
    {
        public OrderRepository(DataContext context) : base(context)
        {
        }
        
        public async Task<Order> GetOrderById(int id)
        {
            var order = await _context.Orders.Include(items => items.OrderItems).FirstOrDefaultAsync(x => x.OrderId == id);
            return order;
            
        }
        public async Task<List<Order>> GetOrderByCustomer(int id)
        {
            var order = await _context.Orders.Include(items => items.OrderItems).Where(x => x.CustomerId == id).ToListAsync();
            return order;
            
        }
    }
}