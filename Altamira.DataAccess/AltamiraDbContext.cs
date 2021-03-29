using Altamira.Entities;
using Altamira.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Altamira.DataAccess
{
    public class AltamiraDbContext : DbContext
    {
        public AltamiraDbContext(DbContextOptions<AltamiraDbContext> options) : base(options)
        {
        }

        public AltamiraDbContext()
        {

        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //       .AddJsonFile("appsettings.json")
        //       .Build();
        //      optionsBuilder.UseSqlServer(configuration.GetConnectionString("AltamiraDbContext"));
        //    base.OnConfiguring(optionsBuilder);
        //}
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Geo> geos { get; set; }

    }
}
