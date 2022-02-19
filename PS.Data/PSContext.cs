using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PS.Domain;


namespace PS.Data
{
    public class PSContext: DbContext
    {
        //Tables BD
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //test commit
            optionsBuilder.UseSqlServer(@"data source=(localdb)\mssqllocaldb;initial catalog= PsProductDb; integrated security= true");
        }
        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(25)
                .IsRequired().HasDefaultValue("name").HasColumnName("nomProduit");
            modelBuilder.Entity<Product>().HasKey(p=>p.ProductId);
            modelBuilder.Entity<Product>().Ignore(p => p.DateCreated);
            base.OnModelCreating(modelBuilder);
        }*/


    }
}
