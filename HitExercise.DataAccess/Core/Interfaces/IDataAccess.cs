using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.Core.Interfaces
{
    public interface IDataAccess : IDisposable
    {
        ICountryRepository Countries { get; }

        ISupplierCategoryRepository Categories { get; }

        ISupplierRepository Suppliers { get; }

        IUserRepository Users { get; }

        void Complete();
    }
}
