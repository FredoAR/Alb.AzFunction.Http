using Microsoft.EntityFrameworkCore;

namespace Alb.Function.Infraestructure.PostgreSql
{
    public class AppFunctionDbContext : DbContext
    {


        public AppFunctionDbContext(DbContextOptions<AppFunctionDbContext> options) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



        }


    }
}
