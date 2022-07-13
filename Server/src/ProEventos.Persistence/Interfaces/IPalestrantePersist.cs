using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interfaces
{
    public interface IPalestrantePersist
    {
        Task<Palestrante[]> GetAllPalestranteByNameAsync(string nome, bool includeEventos = false);
        Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos = false);
        Task<Palestrante> GetPalestranteByIdAsync(int id, bool includeEventos = false);
    }
}