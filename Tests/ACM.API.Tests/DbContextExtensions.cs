using ACM.API.Data;
using ACM.BL;

namespace ACM.API.Tests
{
    public static class DbContextExtensions
    {
        public static void Seed(this DataContext dbContext)
        {

            // add customers
            dbContext.Customers.Add(new Customer 
            {
                FirstName = "Nick",
                LastName = "Chlam",
                EmailAddress = "Nick.Chlam@rht.com",
                CustomerType = 1
            });
            dbContext.Customers.Add(new Customer 
            {
                FirstName = "Sarah",
                LastName = "Rose",
                EmailAddress = "Sarah.Rose@gmail.com",
                CustomerType = 2
            });
            dbContext.Customers.Add(new Customer 
            {
                FirstName = "Dudley",
                LastName = "Rose",
                EmailAddress = "Dudley.Rose@gmail.com",
                CustomerType = 2
            });

            dbContext.SaveChanges();
        }
        
    }
}