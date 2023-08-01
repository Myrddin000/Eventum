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
    public class EventService : IEventService
    {

        private readonly IEventRepository _eventRepository;   // Liaison avec la DAL (Son Interface 'IUserRepos' + Le nom '_userRepos')

        public EventService(IEventRepository eventRepository)
        {                                                       // Construction de l'appel (Son Services 'UserServie' avec comme params Interface 'IUserRepos' et son nom et dans ce constructeur faire l'appel de liaison DAL '_userRepos')            
            _eventRepository = eventRepository;
        }



        public void Create(EventFormDTO eventformDTO)
        {
            if (eventformDTO == null)
            {
                throw new Exception("incomplete data");
            }
            try
            {
                _eventRepository.Create(eventformDTO.ToDAL());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<EventDTO> GetAll()
        {
            try
            {
                return _eventRepository.GetAll().ToBLL();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public EventDTO GetById(Guid Event_id)
        {
            try
            {
                return _eventRepository.GetById(Event_id).ToBLL();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void Update(EventDTO eventDTO)
        {
            if(eventDTO.Event_title == null || eventDTO.Event_start_time == null || eventDTO.Event_end_time == null || eventDTO.Event_note == null)
            {
                throw new Exception("Incomplete data");
            }
            try
            {
                _eventRepository.Update(eventDTO.ToDAL());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Delete(Guid Event_id)
        {
            try
            {
                _eventRepository.Delete(Event_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
