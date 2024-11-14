using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Alb.Function.Infraestructure.PostgreSql
{
    public class AppFunctionDbContextFactory : IDesignTimeDbContextFactory<AppFunctionDbContext>
    {
        public AppFunctionDbContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("PostgreSqlConnection");

            if(string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException($"{nameof(connectionString)} es nulo o vacio, verifica cadena de conexión.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<AppFunctionDbContext>();
            optionsBuilder.UseNpgsql(connectionString, m => m.MigrationsAssembly("Alb.Function.Infraestructure"));
            
            
            return new AppFunctionDbContext(optionsBuilder.Options);
        }
    }
}
