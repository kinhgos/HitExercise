using HitExercise.DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.Core.Interfaces
{
    public interface ISupplierRepository : IDisposable
    {
        IEnumerable<Supplier> GetAll();

        Supplier GetById(int? id);

        void Create(Supplier supplier);

        void Update(Supplier supplier);

        void Delete(int? id);


    }
}
