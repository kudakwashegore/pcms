using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.Entity;

namespace RueEngine.Entities
{
    public class DatabaseContext : DbContext
    {        
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Refill> Refills { get; set; }
        public DbSet<Trip> Trips { get; set; }
        
    }
}