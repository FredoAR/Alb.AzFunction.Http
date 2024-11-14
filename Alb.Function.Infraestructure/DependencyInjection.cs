using Alb.Function.Infraestructure.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Alb.Function.Infraestructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        {

            ConfigurePostgreSqlDbConnection(services);

            return services;
        }


        public static void ConfigurePostgreSqlDbConnection(IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("PostgreSqlConnection");

            services.AddDbContext<AppFunctionDbContext>(options =>
            {
                options.UseNpgsql(connectionString, m => m.MigrationsAssembly("Alb.Function.Infraestructure"));
                
            });

        }


        //public static void ConfigureDbConnection(IServiceCollection services)
        //{
        //    services.AddScoped<IDbConnection>(sql => new SqlConnection("{connectionString}"));

        //}



    }
}
