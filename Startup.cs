using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieApp.Data;
using MovieApp.Repository;
using MovieApp.Repository.Interface;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp
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
            
            var connectionString = Configuration.GetConnectionString("MoviesAppCon");
            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(connectionString));
            
            //services.AddCors(c =>
            //{ 
            //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //});
            //services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.
            //ReferenceLoopHandling = Newtonsoft
            //.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(options => options.SerializerSettings.
            //ContractResolver
            //= new DefaultContractResolver());

            services.AddControllers().AddNewtonsoftJson(options=>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IFilterRepository, FilterRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
