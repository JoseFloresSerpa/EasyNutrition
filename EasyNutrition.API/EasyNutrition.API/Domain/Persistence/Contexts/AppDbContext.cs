using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Complaint> Complaint { get; set; }
        public DbSet<Experience> Experience { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Entidad Role

            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().HasKey(p => p.Id);
            builder.Entity<Role>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Role>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Role>()
                .HasMany(p => p.Users)
                .WithOne(p => p.Role)
                .HasForeignKey(p => p.RoleId);

            // Agregar data a Role
            builder.Entity<Role>().HasData
                (
                    new Role { Id = 1, Name = "Nutricionista" },
                    new Role { Id = 2, Name = "Cliente" }
                );

            // Entidad User

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Username)
                .IsRequired().HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Password)
               .IsRequired().HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Name)
               .IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Lastname)
               .IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Birthday)
               .IsRequired().HasMaxLength(10);
            builder.Entity<User>().Property(p => p.Email)
               .IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Phone)
               .IsRequired().HasMaxLength(10);
            builder.Entity<User>().Property(p => p.Address)
               .IsRequired().HasMaxLength(100);
            builder.Entity<User>().Property(p => p.Active)
              .IsRequired();
            builder.Entity<User>().Property(p => p.Linkedin);

            builder.Entity<User>()
              .HasOne(pt => pt.Role)
              .WithMany(p => p.Users)
              .HasForeignKey(pt => pt.RoleId);

            // Agregar data a User
            builder.Entity<User>().HasData
                (
                    new User { Id = 1, Username = "AlfredoGomez", Password = "Gomez", Name= "Alfredo", Lastname="Gomez",Birthday="10/10/1980",Email="alfredito@gmail.com", Phone="97531546",Address="Las Malvinas 123",Active=true, Linkedin="https:\\afjaowjfiawj.com" , RoleId=1}
                    
                );

            //Entidad Complaint
            builder.Entity<Complaint>().ToTable("Complaint");
            builder.Entity<Complaint>().HasKey(p => p.Id);
            builder.Entity<Complaint>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Complaint>().Property(p => p.Description)
                .IsRequired().HasMaxLength(50);

            builder.Entity<Complaint>()
             .HasOne(pt => pt.Experience)
             .WithMany(p => p.Complaints)
             .HasForeignKey(pt => pt.ExperienceId);

            // Agregar data a Complaint
            builder.Entity<Complaint>().HasData
              (
                  new Complaint { Id = 1, Description = "Descripcion de prueba complaint",ExperienceId = 1}

              );


            //Entidad Experience
            builder.Entity<Experience>().ToTable("Experience");
            builder.Entity<Experience>().HasKey(p => p.Id);
            builder.Entity<Experience>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Experience>().Property(p => p.Name)
                .IsRequired().HasMaxLength(50);
            builder.Entity<Experience>().Property(p => p.Description)
                .IsRequired().HasMaxLength(50);

            builder.Entity<Experience>()
             .HasMany(p => p.Complaints)
             .WithOne(p => p.Experience)
             .HasForeignKey(p => p.ExperienceId);

            // Agregar data a Experience
            builder.Entity<Experience>().HasData
              (
                  new Experience { Id = 1, Name = "Nombre",Description = "Descripcion de prueba experience" }

              );


            // Apply Naming Conventions Policy

            builder.ApplySnakeCaseNamingConvention();

        }



    }
}
