﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using products_and_categories.Models;

#nullable disable

namespace Bug_Tracker.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240219204957_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("products_and_categories.Models.Bug", b =>
                {
                    b.Property<string>("BugId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BugName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HostProjectId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("BugId");

                    b.HasIndex("HostProjectId");

                    b.ToTable("Bug");
                });

            modelBuilder.Entity("products_and_categories.Models.JoinTable", b =>
                {
                    b.Property<int>("JoinTableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectId1")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("JoinTableId");

                    b.HasIndex("ProjectId1");

                    b.HasIndex("UserId");

                    b.ToTable("Joins");
                });

            modelBuilder.Entity("products_and_categories.Models.Project", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("products_and_categories.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("products_and_categories.Models.Bug", b =>
                {
                    b.HasOne("products_and_categories.Models.Project", "Host")
                        .WithMany("AllBugs")
                        .HasForeignKey("HostProjectId");

                    b.Navigation("Host");
                });

            modelBuilder.Entity("products_and_categories.Models.JoinTable", b =>
                {
                    b.HasOne("products_and_categories.Models.Project", "Project")
                        .WithMany("Users")
                        .HasForeignKey("ProjectId1");

                    b.HasOne("products_and_categories.Models.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("products_and_categories.Models.Project", b =>
                {
                    b.Navigation("AllBugs");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("products_and_categories.Models.User", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
