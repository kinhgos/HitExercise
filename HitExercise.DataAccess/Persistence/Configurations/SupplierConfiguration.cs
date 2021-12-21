using HitExercise.DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.Persistence.Configurations
{
    internal class SupplierConfiguration : EntityTypeConfiguration<Supplier>
    {
        public SupplierConfiguration()
        {
            //Properties

            Property(s=>s.Id)                
                .IsRequired();

            Property(s => s.Name)                
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute()))
                .IsRequired()
                .HasMaxLength(80);

            Property(s => s.CategoryId)
                .IsRequired();

            Property(s => s.Afm)
                .IsRequired();

            Property(s => s.Address)
                .HasMaxLength(100)
                .IsOptional();

            Property(s => s.Telephone)
                .IsRequired();

            Property(s => s.Email)
                .HasMaxLength(50)
                .IsRequired();

            Property(s => s.CountryId)
                .IsRequired();

            Property(s => s.Inactive)
                .IsOptional();
                

            //Relationships

            HasRequired(s=>s.Country)
                .WithMany(c=>c.Suppliers)
                .HasForeignKey(s=>s.CountryId)
                .WillCascadeOnDelete(false);

            HasRequired(s => s.Category)
                .WithMany(c => c.Suppliers)
                .HasForeignKey(c => c.CategoryId)
                .WillCascadeOnDelete(false);


        }
    }
}
