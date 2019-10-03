using EventWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EventWeb.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet <Event> Events { get; set; }
        public DbSet <Category> Categories { get; set; }
        public AppDbContext()
            : base("EventDb")
        {

        }

        
    }
}