using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEventRepository
    {
        public void Create(EventEntities even);

        public IEnumerable<EventEntities> GetAll();

        public void Update(EventEntities even);

        public void Delete(Guid Event_id);

        EventEntities GetById(Guid Event_id);
    }
}
