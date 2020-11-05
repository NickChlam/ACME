using Microsoft.EntityFrameworkCore;
using ACM.API.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace ACM.API.Tests
{
    public class DbContextMock
    {
        public static DataContext getDataContext(string dbName)
        {
            // create options for context instance
             var options = new DbContextOptionsBuilder<DataContext>()
                // , new InMemoryDatabaseRoot() 
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // create instance of context
            var dbContext = new DataContext(options);
            

            // add entities in memory db 
            dbContext.Seed();

            return dbContext;
        }
        
    }
}