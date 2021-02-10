using Coravel;
using Masny.DotNet.TransactionSystem.WebApi.Contexts;
using Masny.DotNet.TransactionSystem.WebApi.Interfaces;
using Masny.DotNet.TransactionSystem.WebApi.Jobs;
using Masny.DotNet.TransactionSystem.WebApi.Managers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Masny.DotNet.TransactionSystem.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITransactionManager, TransactionManager>();

            services.AddQueue();
            services.AddScoped<ProcessTransactionJob>();

            services.AddDbContext<TransactionContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TransactionContextConnection")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Masny.DotNet.TransactionSystem.WebApi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Masny.DotNet.TransactionSystem.WebApi v1"));
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