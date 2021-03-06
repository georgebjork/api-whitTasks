using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;



namespace api_whitTasks
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);

             services.AddCors(options => options.AddPolicy("api-CORS", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            
            var connStrings = Configuration.GetSection("ConnectionStrings");
           // Database.DatabaseConnection.ConnectionString = connStrings["Database"];
            //This is using user secrects
           Database.DatabaseConnection.ConnectionString = connStrings["whitTasksDB"];

            services.AddRazorPages().AddNewtonsoftJson();//this is important
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            else
            {
                app.UseHsts();
            }
            app.UseCors("api-CORS");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
