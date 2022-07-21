using System.Threading.Tasks;
using ProEventos.Domain;
using ProEventos.Service.Dtos;

namespace ProEventos.Service
{
    public interface IEventoService
    {
        Task<EventoDto> AddEventos(EventoDto model);
        Task<EventoDto> UpdateEvento(int id, EventoDto model);
        Task<bool> DeleteEvento(int id);

        Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<EventoDto> GetEventoByIdAsync(int id, bool includePalestrantes = false);
    }
}