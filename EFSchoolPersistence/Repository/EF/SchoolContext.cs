using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSchoolPersistence.Repository.EF
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; User Id=sa; Password=1Secure*Password; Database = School")
                .LogTo(Console.WriteLine,
                new[] { 
                         DbLoggerCategory.Database.Command.Name
                      },
                       LogLevel.Information)
                       .EnableSensitiveDataLogging();

        }
    }
}
