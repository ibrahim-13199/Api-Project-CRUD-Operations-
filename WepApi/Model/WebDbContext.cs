using Microsoft.EntityFrameworkCore;
using Shared;

namespace WepApi.Model
{
    public class WebDbContext:DbContext
    {
        public WebDbContext()
        {

        }
        public WebDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> prouducts { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
