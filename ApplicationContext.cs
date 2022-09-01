using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_posgrest
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Students> Student { get; set; }
        public DbSet<DateOfVisit> Visiting { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Username=postgres;Password=admin;Database=info");
        }
    }
}
