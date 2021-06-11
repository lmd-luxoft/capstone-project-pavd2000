﻿// <auto-generated />
using System;
using HomeAccounting.BusinesLogic.EF.ApplicationLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeAccounting.BusinesLogic.EF.Migrations
{
    [DbContext(typeof(DomainContext))]
    [Migration("20210611135054_ChangeBank")]
    partial class ChangeBank
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeAccounting.BusinesLogic.EF.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OperationId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("HomeAccounting.BusinesLogic.EF.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BIK")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("HomeAccounting.BusinesLogic.EF.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ExecutionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("HomeAccounting.BusinesLogic.EF.PropertyPriceChange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Delta")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("PriceChanges");
                });

            modelBuilder.Entity("HomeAccounting.BusinesLogic.EF.Cash", b =>
                {
                    b.HasBaseType("HomeAccounting.BusinesLogic.EF.Account");

                    b.Property<int>("Banknotes")
                        .HasColumnType("int");

                    b.Property<int>("Monets")
                        .HasColumnType("int");

                    b.ToTable("Cashes");
                });

            modelBuilder.Entity("HomeAccounting.BusinesLogic.EF.Deposit", b =>
                {
                    b.HasBaseType("HomeAccounting.BusinesLogic.EF.Account");

                    b.Property<int?>("BankId")
                        .HasColumnType("int");

                    b.Property<string>("NumberOfBankAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Percent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasIndex("BankId");

                    b.ToTable("Deposites");
                });

            modelBuilder.Entity("HomeAccounting.BusinesLogic.EF.Property", b =>
                {
                    b.HasBaseType("HomeAccounting.BusinesLogic.EF.Account");

                    b.Property<int>("BasePrice")
                        .HasColumnType("int");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("HomeAccounting.BusinesLogic.EF.Account", b =>
                {
                    b.HasOne("HomeAccounting.BusinesLogic.EF.Operation", null)
                        .WithMany("Accounts")
                        .HasForeignKey("OperationId");
                });

            modelBuilder.Entity("HomeAccounting.BusinesLogic.EF.PropertyPriceChange", b =>
                {
                    b.HasOne("HomeAccounting.BusinesLogic.EF.Property", null)
                        .WithMany("PropertyPriceChanges")
                        .HasForeignKey("PropertyId");
                });

            modelBuilder.Entity("HomeAccounting.BusinesLogic.EF.Cash", b =>
                {
                    b.HasOne("HomeAccounting.BusinesLogic.EF.Account", null)
                        .WithOne()
                        .HasForeignKey("HomeAccounting.BusinesLogic.EF.Cash", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomeAccounting.BusinesLogic.EF.Deposit", b =>
                {
                    b.HasOne("HomeAccounting.BusinesLogic.EF.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId");

                    b.HasOne("HomeAccounting.BusinesLogic.EF.Account", null)
                        .WithOne()
                        .HasForeignKey("HomeAccounting.BusinesLogic.EF.Deposit", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("HomeAccounting.BusinesLogic.EF.Property", b =>
                {
                    b.HasOne("HomeAccounting.BusinesLogic.EF.Account", null)
                        .WithOne()
                        .HasForeignKey("HomeAccounting.BusinesLogic.EF.Property", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomeAccounting.BusinesLogic.EF.Operation", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("HomeAccounting.BusinesLogic.EF.Property", b =>
                {
                    b.Navigation("PropertyPriceChanges");
                });
#pragma warning restore 612, 618
        }
    }
}
