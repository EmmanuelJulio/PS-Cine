using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PS.DATE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SqlKata.Compilers;
using System.Data;
using Microsoft.Data.SqlClient;
using PS.DOMAIN.Comands;
using PS.DATE.Command;
using PS.APLICATION.Services;
//using SqlKata.Compilers;

namespace PS.API.CINE
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

            services.AddControllers();
            var connectionString = Configuration.GetSection("ConnectionString").Value;
            services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer(connectionString));
             services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b => {
                return new SqlConnection(connectionString);
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PS.API.CINE", Version = "v1" });
            });
            services.AddTransient<IGenericsRepository, GenericRepository>();
            services.AddTransient<IFuncionService, FuncionService>();
            services.AddTransient<IpeliculaService, PeliculaService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<ISalaService, SalaService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PS.API.CINE v1"));
            }

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
