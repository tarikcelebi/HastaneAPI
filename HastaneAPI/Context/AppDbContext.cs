using HastaneAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HastaneAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext)
        {
            
        }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hospital>().HasData(
                new Hospital
                {
                    ID=1,
                    HospitalName="Şişli Eftal",
                    Address="Şişli,İstanbul",

                },
                new Hospital
                {
                    ID = 2,
                    HospitalName = "Bakırköy Sadi Konuk",
                    Address = "Bakırköy,Istanbul",
                }
                );

            modelBuilder.Entity<Patient>().HasData(
                                new Patient()
                                {
                                    ID=1,
                                    FirstName = "John",
                                    LastName = "Doe",
                                    Klinik = "deri ve zührevi hastlıkları",
                                    ControlDate = new DateTime(2023, 3, 12),
                                    HastaneID = 1

                                },
                new Patient()
                {
                    ID=2,
                    FirstName = "Jeyn",
                    LastName = "Doe",
                    Klinik = "Üroloji ve zührevi hastlıkları",
                    ControlDate = new DateTime(2023, 12, 3),
                    HastaneID = 2

                }


                );

        }

    }
}
