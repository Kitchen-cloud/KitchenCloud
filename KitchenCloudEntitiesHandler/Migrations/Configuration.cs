using KitchenCloudEntities.Common;
using KitchenCloudEntities.Recipes;
using KitchenCloudEntitiesHandler.Common;
using KitchenCloudEntitiesHandler.Recipes;

namespace KitchenCloudEntitiesHandler.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KitchenCloudEntitiesHandler.KitchenCloudContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KitchenCloudEntitiesHandler.KitchenCloudContext context)
        {
            Country country = new Country
            {
                Id = 1,
                Code = 62,
                Name = "India"
            };
            new CountryHandler().Add(country);
            City city = new City
            {
                Name = "Nagpur",
                Country = country
            };
            context.Cities.AddOrUpdate(city);
            city.Name = "Mumbai";
            city.Country = country;
            context.Cities.AddOrUpdate(city);
            RecipeCategory category = new RecipeCategory
            {
                Id = 1,
                Name = "Pakistani"
            };
            context.RecipeCategories.AddOrUpdate(category);
            RecipeSubCategory sc = new RecipeSubCategory
            {
                Name = "Fast Food",
                RecipeCategory = category
            };
            context.RecipeSubCategories.AddOrUpdate(sc);
            sc.Name = "Soup";
            sc.RecipeCategory = category;
            context.RecipeSubCategories.AddOrUpdate(sc);
            sc.Name = "Desi";
            sc.RecipeCategory = category;
            context.RecipeSubCategories.AddOrUpdate(sc);
            sc.Name = "Lite";
            sc.RecipeCategory = category;
            context.RecipeSubCategories.AddOrUpdate(sc);
            category.Name = "Chinese";
            category.Id = 2;
            context.RecipeCategories.AddOrUpdate(category);
            category.Name = "Italian";
            category.Id = 3;
            context.RecipeCategories.AddOrUpdate(category);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
