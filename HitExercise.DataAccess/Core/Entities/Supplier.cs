using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.Core.Entities
{
    public class Supplier
    {
        
        public int Id { get; set; }

        
        public string Name { get; set; }

        public SupplierCategory Category { get; set; }
        
        public int CategoryId { get; set; }
        
        public string Afm { get; set; }

        
        public string Address { get; set; }

        public string Telephone { get; set; }
        
        public string Email { get; set; }

        public Country Country { get; set; }
        
        public int CountryId { get; set; }

        public bool Inactive { get; set; }
    }
}
