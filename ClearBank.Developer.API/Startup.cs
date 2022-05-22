using ClearBank.Developer.Repository;
using ClearBank.DeveloperTest.Domain.IRepository;
using ClearBank.DeveloperTest.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClearBank.Developer.API
{
    public class Startup
    {
        private string DataStoreTypeKey = "DataStoreType";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Register services
            services.AddScoped<IPaymentService, PaymentService>();
            
            //Register repositories
            services.AddScoped<IAccountDataStore>((ctx) =>
            {
                IConfiguration configuration = ctx.GetRequiredService<IConfiguration>();

                return configuration[DataStoreTypeKey] == "Backup" ?
                                new BackupAccountDataStore() : 
                                (IAccountDataStore)new AccountDataStore();
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
