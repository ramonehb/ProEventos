using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> Update(int id, Evento model);
        Task<Evento> DeleteEvento(int id);

        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes);
    }
}