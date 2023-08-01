using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEventService
    {

        void Create(EventFormDTO eventformDTO);
        
        IEnumerable<EventDTO> GetAll();

        void Update(EventDTO eventDTO);

        void Delete(Guid Event_id);

        EventDTO GetById(Guid Event_id);

    }
}
