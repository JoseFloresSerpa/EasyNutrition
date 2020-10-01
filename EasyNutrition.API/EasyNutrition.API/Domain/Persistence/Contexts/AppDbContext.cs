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

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<AvailableSchedule> AvailableSchedules { get; set; }

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
                    new Role { Id = 2, Name = "Cliente" },
                    new Role { Id = 3, Name = "Administrador" },
                    new Role { Id = 4, Name = "Invitado" }


                );

            // Entidad User

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id);
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

            builder.Entity<User>()
             .HasMany(pt => pt.Subscriptions)
             .WithOne(p => p.User)
             .HasForeignKey(pt => pt.UserId);

              builder.Entity<User>()
            .HasMany(pt => pt.AvailableSchedules)
            .WithOne(p => p.User)
            .HasForeignKey(pt => pt.UserId);



            builder.Entity<User>().HasData
                (
                    new User { Id = 1, Username = "AlfredoGomez", Password = "Gomez", Name= "Alfredo", Lastname="Gomez",Birthday="10/10/1980",Email="alfredito@gmail.com", Phone="97531546",Address="Las Malvinas 123",Active=true, Linkedin="https:\\afjaowjfiawj.com" , RoleId=1},
                     new User { Id = 2, Username = "AlfredoGomez", Password = "Gomez", Name = "Alfredo", Lastname = "Gomez", Birthday = "10/10/1980", Email = "alfredito@gmail.com", Phone = "97531546", Address = "Las Malvinas 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 1 }


                );
            // Entidad Subscription

            builder.Entity<Subscription>().ToTable("Subscriptions");
            builder.Entity<Subscription>().HasKey(p => p.Id);
            builder.Entity<Subscription>().Property(p => p.Id);
            builder.Entity<Subscription>().Property(p => p.maxSessions)
                .IsRequired();
            builder.Entity<Subscription>().Property(p => p.price)
                  .IsRequired();
            builder.Entity<Subscription>().Property(p => p.active)
                .IsRequired();


            builder.Entity<Subscription>()
             .HasOne(pt => pt.User)
             .WithMany(p => p.Subscriptions)
             .HasForeignKey(pt => pt.UserId);

            // Agregar data a Subscription
            builder.Entity<Subscription>().HasData
                (
                    new Subscription { Id = 1, maxSessions = 4, price = 10, active= true , UserId= 1},
                    new Subscription { Id = 2, maxSessions = 1, price = 13, active = true, UserId = 2 }

                );

            // Entidad AvailableSchedule

            builder.Entity<AvailableSchedule>().ToTable("AvailableSchedules");
            builder.Entity<AvailableSchedule>().HasKey(p => p.Id);
            builder.Entity<AvailableSchedule>().Property(p => p.Id);
            builder.Entity<AvailableSchedule>().Property(p => p.startAt)
                .IsRequired();
            builder.Entity<AvailableSchedule>().Property(p => p.endAt)
                  .IsRequired();
            builder.Entity<AvailableSchedule>().Property(p => p.state)
                .IsRequired();


            builder.Entity<AvailableSchedule>()
             .HasOne(pt => pt.User)
             .WithMany(p => p.AvailableSchedules)
             .HasForeignKey(pt => pt.UserId);

            // Agregar data a AvailableSchedule
            builder.Entity<AvailableSchedule>().HasData
                (
                    new AvailableSchedule { Id = 1, startAt = "Friday, February 22, 2019 2:00:55 PM", endAt = "Friday, February 22, 2019 2:40:55 PM", state = true, UserId = 1 },
                    new AvailableSchedule { Id = 2, startAt = "Friday, February 22, 2019 5:00:55 PM", endAt = "Friday, February 22, 2019 6:40:55 PM", state = true, UserId = 2 }

                );






            // Apply Naming Conventions Policy

            builder.ApplySnakeCaseNamingConvention();

        }



    }
}
