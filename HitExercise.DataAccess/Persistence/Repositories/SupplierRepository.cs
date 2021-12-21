using HitExercise.DataAccess.Core.Entities;
using HitExercise.DataAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.Persistence.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException(nameof(supplier));

            _context.Suppliers.Add(supplier);
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var supplier = GetById(id);

            if (supplier == null)
                throw new Exception("Employee not found");

            _context.Suppliers.Remove(supplier);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _context.Suppliers
                            .Include(s=>s.Category)
                            .Include(s=>s.Country);
        }

        public Supplier GetById(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return _context.Suppliers
                            .Include(s => s.Category)
                            .Include(s => s.Country)
                            .SingleOrDefault(supplier => supplier.Id == id);
        }

        public void Update(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException(nameof(supplier));

            _context.Entry(supplier).State = EntityState.Modified;
        }
    }
}
