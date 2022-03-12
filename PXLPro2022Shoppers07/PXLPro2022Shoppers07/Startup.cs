using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PXLPro2022Shoppers07.Data;
using PXLPro2022Shoppers07.Models;
using PXLPro2022Shoppers07.Services;
using Stripe;


namespace PXLPro2022Shoppers07
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddIdentity<UserDetails, IdentityRole>()
                .AddEntityFrameworkStores<appDbContext>();
            services.AddDbContext<appDbContext>(x =>
                x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddRazorPages();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IFavoriteProductRepository, FavoriteProductRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StripeConfiguration.ApiKey = "sk_test_51KcReEKdbdHTzt4uJjBlOP76Ej7t0jmQs00BE1NZWJFxiqqihJAMvesTOfe4loVS7fgNAuH23wjyHwOi9S1iKhvI00n6CmJ3Qu";

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
             app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Products}/{id?}");
            });
            SeedData.MigrateAndPopulate(app);
        }
    }
}
