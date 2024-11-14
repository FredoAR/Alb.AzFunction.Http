using Alb.Function.Infraestructure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;


/* Indica a AzFunction utilice este archivo Startup como punto de inicio para configurar servicios */
[assembly: FunctionsStartup(typeof(Alb.Function.Http.Startup))]
namespace Alb.Function.Http
{
    public class Startup : FunctionsStartup
    {
        
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var context = builder.GetContext();
            
            builder.Services.AddInfrastructureModule(context.Configuration);
            ConfigureMapper(builder.Services);


        }

        
        public void ConfigureMapper(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<AlbAutoMapper>();
            });
        }


    }
}
