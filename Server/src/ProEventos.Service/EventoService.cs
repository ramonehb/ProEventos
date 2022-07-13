using System;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        public Task<Evento> AddEventos(Evento model)
        {
            throw new NotImplementedException();
        }

        public Task<Evento> DeleteEvento(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Evento[]> GetAllEventosAsync(bool includePalestrantes)
        {
            throw new NotImplementedException();
        }

        public Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            throw new NotImplementedException();
        }

        public Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes)
        {
            throw new NotImplementedException();
        }

        public Task<Evento> Update(int id, Evento model)
        {
            throw new NotImplementedException();
        }
    }
}
