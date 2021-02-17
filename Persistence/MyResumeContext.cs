using DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Repository
{
    public class MyResumeContext : DbContext
    {
        public DbSet<MyProfile> MyProfile { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Experience> Experiences { get; set; }

        public MyResumeContext(DbContextOptions<MyResumeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Skill>()
             .HasKey(p => new {  p.SkillID });

            modelBuilder.Entity<Experience>()
            .HasKey(p => new { p.ExperienceID });

            modelBuilder.Entity<MyProfile>()
           .HasKey(p => new { p.MyProfileID });

            modelBuilder.Entity<MyProfile>().HasData(
            new { MyProfileID = 1, Firstname = "Myriam", LastName = "SOUILEM",
                BirthDate = DateTime.Now, Address = "Tunis,Tunisie", Email = "myriam.souilem25@gmail.com",
                Function = "Ingénieur Développement .Net"
            });


        }

    }
}
