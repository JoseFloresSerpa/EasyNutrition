﻿using EasyNutrition.API.Domain.Models;
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


        public DbSet<Session> Sessions { get; set; }

        public DbSet<SessionDetail> SessionDetails { get; set; }



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



            // Entidad Session

            builder.Entity<Session>().ToTable("Session");
            builder.Entity<Session>().HasKey(p => p.Id);
            builder.Entity<Session>().Property(p => p.Id)
                  .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Session>().Property(p => p.StartAt)
                .IsRequired();
            builder.Entity<Session>().Property(p => p.EndAt)
                  .IsRequired();
            builder.Entity<Session>().Property(p => p.Link)
                  .IsRequired().HasMaxLength(100);



            builder.Entity<Session>()
             .HasOne(pt => pt.User)
             .WithMany(p => p.Sessions)
             .HasForeignKey(pt => pt.UserId);

            // Agregar data a Session
            builder.Entity<Session>().HasData
                (
                    new Session { Id = 1, StartAt = "Monday, March 24,2019 17:00:00 PM", EndAt = "Monday, March 24 ,2019 18:00:00 PM", Link = "https" , UserId = 1 },
                    new Session { Id = 2, StartAt = "Thursday, March 26,2019 20:00:00 PM", EndAt = "Thurday, March 26 ,2019 21:00:00 PM", Link = "https" , UserId = 2 }

                );
             

            //Entidad SessionDetails

            builder.Entity<SessionDetail>().ToTable("SessionDetail");
            builder.Entity<SessionDetail>().HasKey(p => p.Id);
            builder.Entity<SessionDetail>().Property(p => p.Id)
                 .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SessionDetail>().Property(p => p.State)
               .IsRequired().HasMaxLength(100);


            builder.Entity<SessionDetail>()
             .HasOne(pt => pt.User)
             .WithMany(p => p.SessionDetails)
             .HasForeignKey(pt => pt.UserId);

            builder.Entity<SessionDetail>()
            .HasOne(pt => pt.Session)
            .WithMany(p => p.SessionDetails)
            .HasForeignKey(pt => pt.SessionId);

            // Agregar data a SessionDetail
            builder.Entity<SessionDetail>().HasData
                (
                    new SessionDetail { Id = 1, State = "Disponible", UserId = 1, SessionId = 1 },
                    new SessionDetail { Id = 2, State = "Disponible", UserId = 2, SessionId = 2 }

                );


            // Apply Naming Conventions Policy

            builder.ApplySnakeCaseNamingConvention();

        }



    }
}
