﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.models.PersonaDAL", b =>
                {
                    b.Property<int>("IdPersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersona"));

                    b.Property<string>("TravelScore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersona");

                    b.ToTable("Personas", (string)null);
                });

            modelBuilder.Entity("DAL.models.UniversityDAL", b =>
                {
                    b.Property<int>("IdUniversity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUniversity"));

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUniversity");

                    b.ToTable("Universities", (string)null);
                });

            modelBuilder.Entity("DAL.models.UserDAL", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<string>("JsonContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonaIdPersona")
                        .HasColumnType("int");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("TravelMode")
                        .HasColumnType("int");

                    b.Property<int>("UniversityIdUniversity")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdUser");

                    b.HasIndex("PersonaIdPersona");

                    b.HasIndex("UniversityIdUniversity");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("UserDALUserDAL", b =>
                {
                    b.Property<int>("FriendsIdUser")
                        .HasColumnType("int");

                    b.Property<int>("UserDALIdUser")
                        .HasColumnType("int");

                    b.HasKey("FriendsIdUser", "UserDALIdUser");

                    b.HasIndex("UserDALIdUser");

                    b.ToTable("UserDALUserDAL");
                });

            modelBuilder.Entity("DAL.models.UserDAL", b =>
                {
                    b.HasOne("DAL.models.PersonaDAL", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaIdPersona")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DAL.models.UniversityDAL", "University")
                        .WithMany()
                        .HasForeignKey("UniversityIdUniversity")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Persona");

                    b.Navigation("University");
                });

            modelBuilder.Entity("UserDALUserDAL", b =>
                {
                    b.HasOne("DAL.models.UserDAL", null)
                        .WithMany()
                        .HasForeignKey("FriendsIdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.models.UserDAL", null)
                        .WithMany()
                        .HasForeignKey("UserDALIdUser")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
