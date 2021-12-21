using HitExercise.DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.Core.Interfaces
{
    public interface ICountryRepository : IDisposable
    {
         IEnumerable<Country> GetAll();

         Country GetById(int? id);
    }
}
