namespace HitExercise.DataAccess.Migrations
{
using HitExercise.DataAccess.Core.Entities;

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HitExercise.DataAccess.Persistence.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HitExercise.DataAccess.Persistence.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var categories = new List<SupplierCategory>()
            {
                new SupplierCategory()
                {
                    Id = 1,
                    Title = "Προμηθευτής Τροφίμων"
                },
                new SupplierCategory()
                {
                    Id=2,
                    Title = "Εξοπλισμός Δωματίου"
                },
                new SupplierCategory()
                {
                    Id= 3,
                    Title = "Ηλεκτρονικός Εξοπλισμός"
                }
            };            
            
            var countries = new List<Country>()
            {
                new Country()
                {
                    Id = 1,
                    Name = "Greece",
                    Code = "GRE"
                },
                new Country()
                {
                    Id = 2,
                    Name = "Italy",
                    Code = "ITA"
                },
                new Country()
                {
                    Id = 3,
                    Name = "France",
                    Code = "FRA"
                },
                new Country()
                {
                    Id = 4,
                    Name = "United States",
                    Code = "USA"
                }
            };

            var user = new User()
            {
                Id=1,
                UserName = "admin",
                Password = "admin"
            };
            
            categories.ForEach(category => context.SupplierCategories.AddOrUpdate(category));
            countries.ForEach(country => context.Countries.AddOrUpdate(country));
            context.Users.AddOrUpdate(user);

            context.SaveChanges();
        }

        
    }
}
