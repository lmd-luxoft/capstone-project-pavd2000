using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.EF.ApplicationLogic
{
    public class DomainContext: DbContext
    {

        private string _connectionString = "Server=localhost;Database=EducationEF;User Id=test;Password=test;";
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bank> Banks { get; set; }

        public DbSet<Cash> Cashes { get; set; }

        public DbSet<Operation> Operations { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<PropertyPriceChange> PriceChanges { get; set; }

        public DbSet<Deposit> Deposites { get; set; }

        public DomainContext()
        {
            //Database.EnsureDeleted();
        }
        public DomainContext(DbContextOptions<DomainContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           base.OnConfiguring(optionsBuilder);
           optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().HasKey(x=>x.Id);
            modelBuilder.Entity<Bank>().HasKey(x => x.Id);
            modelBuilder.Entity<Deposit>().ToTable("Deposites");
            modelBuilder.Entity<Cash>().ToTable("Cashes");
            modelBuilder.Entity<Operation>().HasMany<Account>(x=>x.Accounts);
            modelBuilder.Entity<Property>().ToTable("Properties").HasMany<PropertyPriceChange>(x => x.PropertyPriceChanges); 
            modelBuilder.Entity<PropertyPriceChange>();
            
        }
    }
}
