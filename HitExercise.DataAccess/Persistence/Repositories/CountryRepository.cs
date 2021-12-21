using HitExercise.DataAccess.Core.Entities;
using HitExercise.DataAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.Persistence.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<Country> GetAll()
        {
            return _context.Countries;
        }

        public Country GetById(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return _context.Countries.FirstOrDefault(c => c.Id == id);
        }

        
    }
}
