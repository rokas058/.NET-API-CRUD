using CRUD_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Data
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
