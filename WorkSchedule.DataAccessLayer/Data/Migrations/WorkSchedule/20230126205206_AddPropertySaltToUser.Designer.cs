﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WorkSchedule.DataAccessLayer.Database;

#nullable disable

namespace WorkSchedule.DataAccessLayer.Data.Migrations.WorkSchedule
{
    [DbContext(typeof(WorkScheduleDbContext))]
    [Migration("20230126205206_AddPropertySaltToUser")]
    partial class AddPropertySaltToUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WorkSchedule.DataAccessLayer.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Lastname")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("WorkObjectId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WorkObjectId");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("WorkSchedule.DataAccessLayer.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique();

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("WorkSchedule.DataAccessLayer.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("ScheduleStart")
                        .HasColumnType("date");

                    b.Property<int>("WorkSchemaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("WorkSchemaId");

                    b.ToTable("Schedules", (string)null);
                });

            modelBuilder.Entity("WorkSchedule.DataAccessLayer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("NormalizedUsername")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Password")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<TimeSpan>("RegistrationDate")
                        .HasColumnType("interval");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("Salt")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .IsUnique();

                    b.HasIndex("NormalizedUsername")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("WorkSchedule.DataAccessLayer.Entities.WorkObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WorkObjects", (string)null);
                });

            modelBuilder.Entity("WorkSchedule.DataAccessLayer.Entities.WorkSchema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int[]>("Scheme")
                        .IsRequired()
                        .HasMaxLength(31)
                        .HasColumnType("integer[]");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time without time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WorkSchemas", (string)null);
                });

            modelBuilder.Entity("WorkSchedule.DataAccessLayer.Entities.Employee", b =>
                {
                    b.HasOne("WorkSchedule.DataAccessLayer.Entities.WorkObject", "WorkObject")
                        .WithMany("Employees")
                        .HasForeignKey("WorkObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkObject");
                });

            modelBuilder.Entity("WorkSchedule.DataAccessLayer.Entities.Schedule", b =>
                {
                    b.HasOne("WorkSchedule.DataAccessLayer.Entities.Employee", "Employee")
                        .WithMany("Schedules")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkSchedule.DataAccessLayer.Entities.WorkSchema", "WorkSchema")
                        .WithMany("Schedules")
                        .HasForeignKey("WorkSchemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("WorkSchema");
                });

            modelBuilder.Entity("WorkSchedule.DataAccessLayer.Entities.User", b =>
                {
                    b.HasOne("WorkSchedule.DataAccessLayer.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WorkSchedule.DataAccessLayer.Entities.WorkObject", b =>
                {
                    b.HasOne("WorkSchedule.DataAccessLayer.Entities.User", "User")
                        .WithMany("WorkObjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WorkSchedule.DataAccessLayer.Entities.WorkSchema", b =>
                {
                    b.HasOne("WorkSchedule.DataAccessLayer.Entities.User", "User")
                        .WithMany("WorkSchemas")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WorkSchedule.DataAccessLayer.Entities.Employee", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("WorkSchedule.DataAccessLayer.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WorkSchedule.DataAccessLayer.Entities.User", b =>
                {
                    b.Navigation("WorkObjects");

                    b.Navigation("WorkSchemas");
                });

            modelBuilder.Entity("WorkSchedule.DataAccessLayer.Entities.WorkObject", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("WorkSchedule.DataAccessLayer.Entities.WorkSchema", b =>
                {
                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}