using BLL.Interfaces;
using BLL.Models;
using BLL.Tools;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        // Liaison avec la DAL (Son Interface 'IUserRepos' + Le nom '_userRepos')
        private readonly IUserRepository _userRepository;

        // Construction de l'appel (Son Services 'UserServie' avec comme params Interface 'IUserRepos' et son nom et dans ce constructeur faire l'appel de liaison DAL '_userRepos')
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }






        public void Create(UserFormDTO userform)
        {
            if (userform == null)
            {
                throw new Exception("incomplete data");
            }
            try
            {
                _userRepository.Create(userform.ToDAL()); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<UserDTO> GetAll()
        {
            try
            {
                return _userRepository.GetAll().ToBLL();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Delete(Guid User_id)
        {
            try
            {
                _userRepository.Delete(User_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public UserFormDTO GetById(Guid User_id)
        {
            try
            {
                return _userRepository.GetById(User_id).ToFormBLL();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Update(UserDTO userform)
        {
            if(userform.User_pseudo == null || userform.User_email == null || userform.User_password == null)
            {
                throw new Exception("Incomplete data");
            }
            try
            {
                _userRepository.Update(userform.ToDAL());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
