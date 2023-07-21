using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IReminderRepository
    {
        public void Create(ReminderEntities remind);

        IEnumerable<ReminderEntities> GetAll();

        public void Update(ReminderEntities remind);

        public void Delete(Guid Reminder_id);

        ReminderEntities GetById(Guid Reminder_id);
    }
}
