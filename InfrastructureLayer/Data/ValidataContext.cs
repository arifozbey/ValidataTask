using InfrastructureLayer.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidataTask.Entity;

namespace ValidataTask.Data
{
    public class ValidataContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ValidataMap());

        }
  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ValidataDemo2;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ValidataEntity> Validata { get; set; }
        public DbSet<OrderEntity> Order { get; set; }
    }
}
