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
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredUniqueChars = 1;
                    options.User.RequireUniqueEmail = true;

                }) //more password options available. Dont change after launch or users will get confused
                .AddEntityFrameworkStores<AppIdentityDBContext>()
                .AddDefaultTokenProviders();


            services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(Configuration["Data:Northwind:ConnectionString"]));

            //services.AddTransient<IProductRepository, EFNorthwindRepository>()
            services.AddTransient<INorthwindRepository, EFNorthwindRepository>();


            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info(){Title = "My Api", Version = "v1"});

            });
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

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"); });
        }
    }
}
