using HitExercise.DataAccess.Core.Entities;
using HitExercise.DataAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(User user)
        {
            _context.Users.Add(user);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<User> GetAll()
        {


            return _context.Users;
        }
    }
}
