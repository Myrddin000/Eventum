using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void Create(UserFormDTO userformDTO);

        IEnumerable<UserDTO> GetAll();

        void Update(UserFormDTO userformDTO);

        void Delete(Guid User_id);

        UserFormDTO GetById(Guid User_id);
    }
}
