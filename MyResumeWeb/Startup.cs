using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence.Interfaces;
using Persistence.Repository;
using Repository;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyResumeWeb
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
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IMyProfileRepository, MyProfileRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();       
            services.AddDbContext<MyResumeContext>(options =>
            options.UseSqlServer("Server = localhost\\SQLEXPRESS; Database =MyResumeDB; Trusted_Connection = True; MultipleActiveResultSets = true"));
           

            //services.AddDbContext<MyResumeContext>(options => options.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MyResumeDB;User Id =DESKTOP-COQ9A3E\asus;Password="));
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                            .AllowAnyMethod()
                                                             .AllowAnyHeader()));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAll");
            app.UseAuthentication();
            //app.UseMvc();
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
