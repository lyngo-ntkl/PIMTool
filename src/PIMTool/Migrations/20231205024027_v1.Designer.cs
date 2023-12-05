﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PIMTool.Database;

#nullable disable

namespace PIMTool.Migrations
{
    [DbContext(typeof(PimContext))]
    [Migration("20231205024027_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PIMTool.Core.Domain.Entities.Employee", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Version")
                        .HasColumnType("numeric(10,0)");

                    b.Property<string>("Visa")
                        .IsRequired()
                        .HasColumnType("char(3)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PIMTool.Core.Domain.Entities.Group", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<decimal>("GroupLeaderId")
                        .HasColumnType("numeric(19,0)");

                    b.Property<decimal>("Version")
                        .HasColumnType("numeric(10,0)");

                    b.HasKey("Id");

                    b.HasIndex("GroupLeaderId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("PIMTool.Core.Domain.Entities.Project", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<string>("Customer")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<decimal>("GroupId")
                        .HasColumnType("numeric(19,0)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("ProjectNumber")
                        .HasColumnType("numeric(4,0)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("char(3)");

                    b.Property<decimal>("Version")
                        .HasColumnType("numeric(10,0)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("PIMTool.Core.Domain.Entities.ProjectEmployee", b =>
                {
                    b.Property<decimal>("ProjectId")
                        .HasColumnType("numeric(19,0)");

                    b.Property<decimal>("EmployeeId")
                        .HasColumnType("numeric(19,0)");

                    b.HasKey("ProjectId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ProjectEmployees");
                });

            modelBuilder.Entity("PIMTool.Core.Domain.Entities.Group", b =>
                {
                    b.HasOne("PIMTool.Core.Domain.Entities.Employee", "GroupLeader")
                        .WithMany("Groups")
                        .HasForeignKey("GroupLeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroupLeader");
                });

            modelBuilder.Entity("PIMTool.Core.Domain.Entities.Project", b =>
                {
                    b.HasOne("PIMTool.Core.Domain.Entities.Group", "Group")
                        .WithMany("Projects")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("PIMTool.Core.Domain.Entities.ProjectEmployee", b =>
                {
                    b.HasOne("PIMTool.Core.Domain.Entities.Employee", "Employee")
                        .WithMany("ProjectEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PIMTool.Core.Domain.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("PIMTool.Core.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("ProjectEmployees");
                });

            modelBuilder.Entity("PIMTool.Core.Domain.Entities.Group", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
