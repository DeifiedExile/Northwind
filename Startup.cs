using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Models;

namespace Northwind
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {


            //Identity framework services
            services.AddDbContext<AppIdentityDBContext>(options =>
                options.UseSqlServer(Configuration["Data:Northwind:ConnectionString"]));

            services.AddIdentity<AppUser, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = true;
                    options.User.RequireUniqueEmail = true;
                }) //more password options available. Dont change after launch or users will get confused
                .AddEntityFrameworkStores<AppIdentityDBContext>()
                .AddDefaultTokenProviders();






            // services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration["Data:NWIdentity:ConnectionString"]));
            //services.AddIdentity<AppUser, IdentityRole>(opts =>
            //{
            //    opts.User.RequireUniqueEmail = true;
            //    opts.Password.RequiredLength = 6;
            //    opts.Password.RequireNonAlphanumeric = false;
            //    opts.Password.RequireLowercase = false;
            //    opts.Password.RequireUppercase = false;
            //    opts.Password.RequireDigit = false;
            //    opts.Password.RequiredUniqueChars = 1;
            //}).AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

            services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(Configuration["Data:Northwind:ConnectionString"]));

            //services.AddTransient<IProductRepository, EFNorthwindRepository>()
            services.AddTransient<INorthwindRepository, EFNorthwindRepository>();


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //set up authentication
            app.UseAuthentication();
            //use static files
            app.UseStaticFiles();
            //set up routing
            app.UseMvcWithDefaultRoute();
        }
    }
}
