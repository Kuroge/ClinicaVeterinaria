using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Model;
using Model.Repositories;
using Model.Repositories.Implementation;

namespace ApiClinic
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
            services.AddSingleton<ICollection<Appointment>, Collection<Appointment>>();
            services.AddSingleton<ICollection<Veterinarian>, Collection<Veterinarian>>();
            services.AddSingleton<ICollection<Clinic>, Collection<Clinic>>();
            services.AddSingleton<ICollection<Animal>, Collection<Animal>>();
            services.AddSingleton<ICollection<Client>, Collection<Client>>();
            services.AddSingleton<ICollection<Kind>, Collection<Kind>>();
            services.AddSingleton<ICollection<Disease>, Collection<Disease>>();
            services.AddScoped<ClinicContext>();
            services.AddScoped<IRepository<Kind>, GenericRepository<Kind>>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
