namespace Surplus.Migrations
{
    using Surplus.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Surplus.DataAccess.SurplusDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SurplusPrototype.DataAccess.SurplusDbContext";
        }

        protected override void Seed(Surplus.DataAccess.SurplusDbContext context)
        {
            //var fixedAssets = new List<FixedAsset>
            //{
            //    new FixedAsset { Id = 111111, AssetNumber = "AAA111111" },
            //    new FixedAsset { Id = 222222, AssetNumber = "BBB222222" }
            //};
            //fixedAssets.ForEach(c => context.FixedAssets.AddOrUpdate(x => x.AssetNumber, c));
            //context.SaveChanges();

            var itemConditions = new List<ItemCondition>
            {
                new ItemCondition { Name = "Good" },
                new ItemCondition { Name = "Poor" },
                new ItemCondition { Name = "Needs repair" }
            };
            itemConditions.ForEach(c => context.ItemConditions.AddOrUpdate(x => x.Name, c));
            context.SaveChanges();

            var quantityDescriptions = new List<QuantityDescription>
            {
                new QuantityDescription { Name = "Each" },
                new QuantityDescription { Name = "Small lot" },
                new QuantityDescription { Name = "Large lot" }
            };
            quantityDescriptions.ForEach(d => context.QuantityDescriptions.AddOrUpdate(x => x.Name, d));
            context.SaveChanges();
        }
    }
}
