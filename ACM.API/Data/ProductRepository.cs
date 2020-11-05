using System.Collections.Generic;
using System.Threading.Tasks;
using ACM.BL;
using Microsoft.EntityFrameworkCore;

namespace ACM.API.Data
{
    public class ProductRepository : RepoBase
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }

        public async Task<Product> GetProduct(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
            return product;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            var product = await _context.Products.ToListAsync();
            return product;
        }
        
    }
}