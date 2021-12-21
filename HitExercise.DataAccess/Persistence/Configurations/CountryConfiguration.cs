using HitExercise.DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.Persistence.Configurations
{
    internal class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            //Properties

            Property(c => c.Id)
                .IsRequired();

            Property(c => c.Name)
                .IsRequired();

            Property(c => c.Code)
                .IsRequired();


            //Relationships

            HasMany(c => c.Suppliers)
                .WithRequired(s => s.Country);

           
                
        }
    }
}
