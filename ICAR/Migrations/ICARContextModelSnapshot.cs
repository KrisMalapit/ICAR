﻿// <auto-generated />
using System;
using ICAR.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ICAR.Migrations
{
    [DbContext(typeof(ICARContext))]
    partial class ICARContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ICAR.Models.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Status");

                    b.HasKey("ID");

                    b.ToTable("Companies");

                    b.HasData(
                        new { ID = 1, Code = "SLPGC", Name = "Southwest Luzon Power Gen Corporation", Status = "Active" },
                        new { ID = 2, Code = "SCPC", Name = "Sem-Calaca Power Corporation", Status = "Active" }
                    );
                });

            modelBuilder.Entity("ICAR.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Status");

                    b.HasKey("ID");

                    b.ToTable("Departments");

                    b.HasData(
                        new { ID = 1, Code = "NA", Name = "NOTSET", Status = "Deleted" }
                    );
                });

            modelBuilder.Entity("ICAR.Models.EquipmentType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("CompanyId");

                    b.Property<string>("DimensionCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Status");

                    b.HasKey("ID");

                    b.HasIndex("CompanyId");

                    b.ToTable("EquipmentTypes");
                });

            modelBuilder.Entity("ICAR.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Descriptions");

                    b.Property<string>("Status");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("ICAR.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new { Id = 1, Name = "Admin", Status = "Active" },
                        new { Id = 2, Name = "User", Status = "Active" },
                        new { Id = 3, Name = "MCD Head", Status = "Active" },
                        new { Id = 4, Name = "Dept Head", Status = "Active" },
                        new { Id = 5, Name = "Inspector", Status = "Active" }
                    );
                });

            modelBuilder.Entity("ICAR.Models.UOM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("UOMs");
                });

            modelBuilder.Entity("ICAR.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyAccess");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Domain");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.Property<string>("Status");

                    b.Property<string>("Username")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoleId");

                    b.HasIndex("Username", "Status")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL AND [Status] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, CompanyAccess = "1", DepartmentId = 1, Domain = "SMCDACON", Email = "kcmalapit@semirarampc.com", FirstName = "Kristoffer", LastName = "Malapit", Name = "Kristoffer Malapit", Password = "", RoleId = 1, Status = "1", Username = "kcmalapit" }
                    );
                });

            modelBuilder.Entity("ICAR.Models.EquipmentType", b =>
                {
                    b.HasOne("ICAR.Models.Company", "Companies")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ICAR.Models.User", b =>
                {
                    b.HasOne("ICAR.Models.Department", "Departments")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ICAR.Models.Role", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
