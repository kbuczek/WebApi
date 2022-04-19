using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    //context of our data base - represents a session with the database
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
