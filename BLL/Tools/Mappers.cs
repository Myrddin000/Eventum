using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tools
{

    // User Mappers

    public static class Mappers
    {
        public static UserEntities ToDAL(this UserDTO user)
        {
            return new UserEntities
            {
                User_id = user.User_id,
                User_pseudo = user.User_pseudo,
                User_email = user.User_email,
                User_password = user.User_password,
            };
        }
      

        public static UserEntities ToDAL(this UserFormDTO user)
        {
            return new UserEntities
            {
                User_pseudo = user.User_pseudo,
                User_email = user.User_email,
                User_password = user.User_password,
            };
        }

        public static UserDTO ToBLL(this UserEntities user)
        {
            return new UserDTO
            {
                User_id = user.User_id,
                User_pseudo = user.User_pseudo,
                User_email = user.User_email,
                User_password = user.User_password,
            };
            
        }

        public static UserFormDTO ToFormBLL(this UserEntities user)
        {
            return new UserFormDTO
            {
                User_pseudo = user.User_pseudo,
                User_email = user.User_email,
                User_password = user.User_password,
            };
        }

        public static IEnumerable<UserDTO> ToBLL(this IEnumerable<UserEntities> user)
        {
            foreach (UserEntities item in user)
            {
                yield return new UserDTO
                {
                    User_id = item.User_id,
                    User_pseudo = item.User_pseudo,
                    User_email = item.User_email,
                    User_password = item.User_password,

                };
            }
        }

        public static RegisteredDTO RegisteredToBLL(this UserDTO user)
        {
            return new RegisteredDTO
            {
                User_id = user.User_id,
                User_pseudo = user.User_pseudo,
                User_email = user.User_email,
            };
        }

        
    }
}
