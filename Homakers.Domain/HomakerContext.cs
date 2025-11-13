using Homakers.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Domain
{
    public class HomakerContext : DbContext
    {
        public HomakerContext(DbContextOptions<HomakerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships, indexes, etc.
        }

        public DbSet<Profession> Profession { get; set; }
        public DbSet<Professionals> Professionals { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Districts> Districts { get; set; }
        public DbSet<BookService> BookService { get; set; }

    }
}

