using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.Core.Entities
{
    public class SupplierCategory
    {
        public int Id { get; set; }

        
        public string Title { get; set; }

        public ICollection<Supplier> Suppliers { get; set; }
    }
}
