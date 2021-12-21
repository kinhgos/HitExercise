using HitExercise.DataAccess.Core.Entities;
using HitExercise.DataAccess.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.Persistence
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<SupplierCategory> SupplierCategories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SupplierConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new SupplierCategoryConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
