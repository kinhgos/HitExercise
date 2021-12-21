using HitExercise.DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.Persistence.Configurations
{
    internal class SupplierCategoryConfiguration : EntityTypeConfiguration<SupplierCategory>
    {
        public SupplierCategoryConfiguration()
        {
            //Properties

            Property(c => c.Id)
                .IsRequired();

            Property(c => c.Title)
                .IsRequired();

            //Relationships

            HasMany(c => c.Suppliers)
                .WithRequired(s => s.Category);
        }
    }
}
