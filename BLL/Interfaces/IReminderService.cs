using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IReminderService
    {

        void Create(ReminderFormDTO reminderformDTO);

        IEnumerable<ReminderDTO> GetAll();

        void Update(ReminderDTO reminderDTO);

        void Delete(Guid Reminder_id);

        ReminderDTO GetById(Guid Reminder_id);
    }
}
