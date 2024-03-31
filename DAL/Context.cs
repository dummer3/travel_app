using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
using System.Numerics;
using System.Reflection.Emit;
using DAL.models;
using System.Reflection.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Identity.Client;

namespace DAL
{
    public class Context : DbContext
        {
            public Context(DbContextOptions<Context> op) : base(op) { }
            public DbSet<UserDAL> Users { get; set; }
            public DbSet<PersonaDAL> Personas { get; set; }
            public DbSet<UniversityDAL> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDAL>().ToTable("Users");
            modelBuilder.Entity<PersonaDAL>().ToTable("Personas");
            modelBuilder.Entity<UniversityDAL>().ToTable("Universities");

            modelBuilder.Entity<UserDAL>()
            .HasOne(user => user.Persona)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserDAL>()
            .HasOne(user => user.University)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserDAL>()
            .HasMany(user => user.Friends)
            .WithMany();

            modelBuilder.Entity<UserDAL>()
            .HasIndex(user => user.UserName)
            .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }


}

