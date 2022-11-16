using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interfaces
{
    public interface IUsuarioPersist
    {
        Task<Usuario[]> GetUsuariosAsync();

        Task<Usuario> GetUsuarioByIdAsync(int id);
    }
}