﻿// <auto-generated />
using System;
using ComplaintApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ComplaintApi.Migrations
{
    [DbContext(typeof(ComplaintContext))]
    [Migration("20190921054106_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ComplaintApi.Entities.CompanyMaster", b =>
                {
                    b.Property<string>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100);

                    b.Property<string>("COMPCODE")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("CompanyName")
                        .HasMaxLength(150);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.HasKey("CompanyID");

                    b.ToTable("CompanyMasters");
                });

            modelBuilder.Entity("ComplaintApi.Entities.ComplainsHistory", b =>
                {
                    b.Property<string>("HistoryID")
                        .HasMaxLength(100);

                    b.Property<string>("ComplainID")
                        .HasMaxLength(50);

                    b.Property<string>("COMPCODE")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<string>("Status")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdateAt");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.HasKey("HistoryID", "ComplainID");

                    b.ToTable("ComplainsHistories");
                });

            modelBuilder.Entity("ComplaintApi.Entities.ComplainsMaster", b =>
                {
                    b.Property<string>("CompanyID")
                        .HasMaxLength(100);

                    b.Property<string>("ModuleID")
                        .HasMaxLength(50);

                    b.Property<string>("EmpID")
                        .HasMaxLength(50);

                    b.Property<string>("PriorityID")
                        .HasMaxLength(50);

                    b.Property<string>("COMPCODE")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<string>("Status")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("CompanyID", "ModuleID", "EmpID", "PriorityID");

                    b.ToTable("ComplainsMasters");
                });

            modelBuilder.Entity("ComplaintApi.Entities.ModuleMaster", b =>
                {
                    b.Property<string>("ModuleID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("COMPCODE")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ModuleName")
                        .HasMaxLength(50);

                    b.HasKey("ModuleID");

                    b.ToTable("ModuleMasters");
                });

            modelBuilder.Entity("ComplaintApi.Entities.PriorityMaster", b =>
                {
                    b.Property<string>("PriorityID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100);

                    b.Property<string>("COMPCODE")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasMaxLength(100);

                    b.HasKey("PriorityID");

                    b.ToTable("PriorityMasters");
                });

            modelBuilder.Entity("ComplaintApi.Entities.UserCompany", b =>
                {
                    b.Property<string>("EmpID")
                        .HasMaxLength(50);

                    b.Property<string>("CompanyID")
                        .HasMaxLength(100);

                    b.Property<string>("COMPCODE")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("EmpID", "CompanyID");

                    b.ToTable("UserCompanies");
                });

            modelBuilder.Entity("ComplaintApi.Entities.UserMaster", b =>
                {
                    b.Property<string>("EmpID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("COMPCODE")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasMaxLength(40);

                    b.Property<int>("IsAdmin");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasMaxLength(20);

                    b.HasKey("EmpID");

                    b.ToTable("UserMasters");
                });

            modelBuilder.Entity("ComplaintApi.Entities.UserModule", b =>
                {
                    b.Property<string>("EmpID")
                        .HasMaxLength(50);

                    b.Property<string>("ModuleID")
                        .HasMaxLength(50);

                    b.Property<string>("COMPCODE")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("EmpID", "ModuleID");

                    b.ToTable("UserModules");
                });
#pragma warning restore 612, 618
        }
    }
}
