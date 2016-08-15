using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood_DotNetCore.Entities
{
    public class OdeToFoodDbContext : IdentityDbContext<User>
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyTestOdeToFood;Trusted_Connection=True;");
            //builder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = OdeToFood; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            base.OnConfiguring(builder);
        }


        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
