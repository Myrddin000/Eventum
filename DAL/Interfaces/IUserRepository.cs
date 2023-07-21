using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        void Create(UserEntities user);

        IEnumerable<UserEntities> GetAll();

        void Update(UserEntities user);

        void Delete(Guid User_id);

        UserEntities GetById(Guid User_id);
    }
}
