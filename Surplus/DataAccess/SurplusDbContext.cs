using Surplus.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Surplus.DataAccess
{
    public class SurplusDbContext : DbContext
    {
        public SurplusDbContext() : base("SurplusDbContext") { }

        public DbSet<FixedAsset> FixedAssets { get; set; }
        public DbSet<ItemCondition> ItemConditions { get; set; }
        public DbSet<QuantityDescription> QuantityDescriptions { get; set; }
        public DbSet<SurplusRequest> SurplusRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}