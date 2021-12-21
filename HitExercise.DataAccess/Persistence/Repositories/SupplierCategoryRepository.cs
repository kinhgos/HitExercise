using HitExercise.DataAccess.Core.Entities;
using HitExercise.DataAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.Persistence.Repositories
{
    public class SupplierCategoryRepository : ISupplierCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public SupplierCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<SupplierCategory> GetAll()
        {
            return _context.SupplierCategories;
        }

        public SupplierCategory GetById(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return _context.SupplierCategories.SingleOrDefault(s=>s.Id == id);
        }
    }
}
