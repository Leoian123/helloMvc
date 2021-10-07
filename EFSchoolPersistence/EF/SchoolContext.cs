using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSchoolPersistence.EF
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public SchoolContext()
        {

        }
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(new Student()
            {
                Id = -1,
                Firstname = "Gianni",
                Lastname = "Ciccio",
                Address = "Via bella",
                IsEmployee = true,
                StudentCode = "kbsd912",
                Email = "gianni@email.com",
                PhoneNumber = "34567812",
                SSN = "CSHEJKSI12678912"
            },
            new Student()
            {
                Id = -2,
                Firstname = "Riccardo",
                Lastname = "Bellardelli",
                Address = "Via brutta",
                IsEmployee = false,
                StudentCode = "adysbun213",
                Email = "riccardo@email.com",
                PhoneNumber = "5678213231",
                SSN = "SCVDBSIV2782dds"
            });
        }
    }
}

