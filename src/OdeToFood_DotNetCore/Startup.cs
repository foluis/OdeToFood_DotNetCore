using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;
using OdeToFood_DotNetCore.Services;
using System;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using OdeToFood_DotNetCore.Entities;


namespace OdeToFood_DotNetCore
{
    public class Startup
    {
        //public static IConfigurationBuilder myConfig { get; set; }

        public Startup()
        {
            //myConfig = new ConfigurationBuilder().AddJsonFile("").AddEnvironmentVariables();

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSetings.json")
            .AddJsonFile("modSetings.json");

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted;Trusted_Connection=True;";
            //var connection = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = OdeToFood; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            var connectionString = Configuration["database:connection"];
            services.AddDbContext<OdeToFoodDbContext>(options => 
                options.UseSqlServer(connectionString));


            //var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted;Trusted_Connection=True;";
            ////var connection = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = OdeToFood; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            //var connectionString = Configuration["database:connection"];
            //services.AddEntityFrameworkSqlServer().AddDbContext<OdeToFoodDbContext>(options => options.UseSqlServer(connection));

                        
            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IGreeter, Greeter>();

            //services.AddScoped<IRestaurantData, InMemoryRestaurantData>();
            services.AddScoped<IRestaurantData, SqlRestaurantData>();


        }

        // This method gets called by the runtime. 
        // Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            IGreeter greeter)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            //Same than two above
            app.UseFileServer();

            //app.UseMvcWithDefaultRoute();

            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                //throw new Exception("Error");

                var greeting = Configuration["greating"];

                await context.Response.WriteAsync(greeting);
                await context.Response.WriteAsync("<br>");
                await context.Response.WriteAsync(Configuration["greating2"]);
                await context.Response.WriteAsync("<br>");
                await context.Response.WriteAsync(greeter.GetGreeting());
            });
        }

        private void ConfigureRoutes(IRouteBuilder routBuilder)
        {
            // /Home/Index/
            // /Home/Index/1

            routBuilder.MapRoute("Default",
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
