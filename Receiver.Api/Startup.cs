using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Receiver.Api.Contexts;
using Receiver.Api.Services;

namespace Receiver.Api
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
            // Add XML Serializers to interface with Geocall
            services.AddControllers(setupAction =>
            {
                // Since we are using XML formatters instead of JSON, we want to know 
                // if the reason a failure ocurrs is due to a bad format instead of a
                // bad request.  This makes for easier troubleshooting.
                setupAction.ReturnHttpNotAcceptable = true;

                // This is required to properly deserialize incoming XML
                setupAction.InputFormatters.Add(new XmlSerializerInputFormatter(new MvcOptions()));

            }).AddXmlDataContractSerializerFormatters();
                        

            // Get the connection string from the appsettings.json file
            var connectionString = Configuration["ConnectionStrings:TicketDb"];
            // Add the EFCore dbcontext, using the connection string
            services.AddDbContext<TicketContext>(options => options.UseSqlServer(connectionString));

            // Adds in SqlServer health checks, configured in Configure()
            // requires the nuget package AspNetCore.HealthChecks.SqlServer for AddSqlServer()
            // other health check providers are available as well
            services.AddHealthChecks().AddSqlServer(connectionString);

            // Dependency Injection, anytime we need an ITicketRepository, use a TicketRepository
            services.AddScoped<ITicketRepository, TicketRepositorySql>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // This is for easier troubleshooting...remove for production
                // or change the project's Debug ASPNETCORE_ENVIRONMENT variable to "Production"
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Use exception handling middleware to return a problem report
                app.UseExceptionHandler("/error");
            }

            app.UseRouting();

            app.UseAuthorization();

            // GET /api/status will return "Healthy" or "Unhealthy" in the response body
            // based on the responsiveness of the services added in services.AddHealthChecks() above
            app.UseHealthChecks("/api/status");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
