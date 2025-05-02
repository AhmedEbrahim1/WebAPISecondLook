using Microsoft.EntityFrameworkCore;

namespace WebAPISecondLook.Models.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext()
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("data source=.;initial catalog=DEPI_DB_5_API;integrated security=true;trustservercertificate=true;");
        //    base.OnConfiguring(optionsBuilder);
        //}
        public virtual DbSet<Employee> Employees { get; set; }
        public ApplicationContext(DbContextOptions options):base(options)
        {
            
        }

    }
}
