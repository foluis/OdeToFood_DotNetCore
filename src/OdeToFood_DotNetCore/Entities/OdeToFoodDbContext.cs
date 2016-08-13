using Microsoft.EntityFrameworkCore;

namespace OdeToFood_DotNetCore.Entities
{
    public class OdeToFoodDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyTest;Trusted_Connection=True;");
        }


        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
