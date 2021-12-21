using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.Core.Entities
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public ICollection<Supplier> Suppliers { get; set; }
    }
}
