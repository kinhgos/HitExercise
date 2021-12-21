using HitExercise.DataAccess.Core.Interfaces;
using HitExercise.DataAccess.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.Persistence
{
    public class DataAccess : IDataAccess
    {
        private readonly ApplicationDbContext _context;

        public ISupplierRepository Suppliers { get; private set; }

        public ISupplierCategoryRepository Categories { get; private set; }

        public ICountryRepository Countries { get; private set; }

        public IUserRepository Users { get; private set; }

        public DataAccess(ApplicationDbContext context)
        {
            _context = context;
            Suppliers = new SupplierRepository(_context);
            Categories = new SupplierCategoryRepository(_context);
            Countries = new CountryRepository(_context);
            Users = new UserRepository(_context);

        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
