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
    public class ReminderService : IReminderService
    {

        private readonly IReminderRepository _reminderRepository;

        public ReminderService(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }




        public void Create(ReminderFormDTO reminderformDTO)
        {
            if(reminderformDTO == null)
            {
                throw new Exception("Incomplete data!");
            }
            try
            {
                _reminderRepository.Create(reminderformDTO.ToDAL());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ReminderDTO> GetAll()
        {
            try
            {
                return _reminderRepository.GetAll().ToBLL();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ReminderDTO GetById(Guid Reminder_id)
        {
            try
            {
                return _reminderRepository.GetById(Reminder_id).ToBLL();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(ReminderDTO reminderDTO)
        {
            if(reminderDTO.Reminder_title == null || reminderDTO.Reminder_time == null)
            {
                throw new Exception("Incomplete data!!");
            }
            try
            {
                _reminderRepository.Update(reminderDTO.ToDAL());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Guid Reminder_id)
        {
            try
            {
                _reminderRepository.Delete(Reminder_id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
