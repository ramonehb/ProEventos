using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public interface IProEventosPersistence
    {
        //Geral
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         void DeleteRange<T>(T entity) where T : class;
        Task<bool> SaveChangeAsync();

        //Eventos
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int id, bool includePalestrantes);

        //Palestrantes
        Task<Palestrante[]> GetAllPalestranteByNameAsync(string nome, bool includePalestrantes);
        Task<Palestrante[]> GetAllPalestranteAsync(bool includePalestrantes);
        Task<Palestrante> GetPalestranteByIdAsync(int id, bool includePalestrantes);
    }
}