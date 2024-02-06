using System;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
	public class AppDbContext: DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
		}

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Registration> Users { get; set; }
        public DbSet<ProgressNote> ProgressNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed Organization Data
            modelBuilder.Entity<Organization>().HasData(new Organization
            {
                Id = 11111,
                Name= "Asian"
            });
            modelBuilder.Entity<Organization>().HasData(new Organization
            {
                Id = 22222,
                Name = "Appollo"
            });

            //Seed Patients data
            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                Id = 1,
                FirstName = "John",
                LastName = "Wick",
                OrganizationId = 11111,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                Id = 2,
                FirstName = "John",
                LastName = "Cena",
                OrganizationId = 11111,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                Id = 3,
                FirstName = "Iron",
                LastName = "Man",
                OrganizationId = 22222,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
            //Seed Users data
            modelBuilder.Entity<Registration>().HasData(new Registration
            {
                Id = 1111,
                Password = "1111@abc",
                Name = "john1111",
                Email = "john1111@abc.com"
            });
            modelBuilder.Entity<Registration>().HasData(new Registration
            {
                Id = 2222,
                Password = "2222@abc",
                Name = "john2222",
                Email = "john2222@abc.com"
            });
            modelBuilder.Entity<Registration>().HasData(new Registration
            {
                Id = 3333,
                Password = "3333@abc",
                Name = "john3333",
                Email = "john3333@abc.com"
            });
        }
    }
    
}

