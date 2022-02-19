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
            optionsBuilder.UseSqlServer(@"data source=(localdb)\mssqllocaldb;initial catalog= PsProductDb; integrated security= true");
        }


    }
}
