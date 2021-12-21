using HitExercise.DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.Core.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetAll();

        void Create(User user);
    }
}
