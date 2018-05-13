using Microsoft.EntityFrameworkCore;
using Names.Domain.Entities;
using System.Collections.Generic;

namespace Names.Infrastructure.Context
{
    public class NamesContext : DbContext
    {
        public DbSet<Name> Names { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Quantity> Quantities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../nombres.db");
        }
    }
}
