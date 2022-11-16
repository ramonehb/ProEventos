using System.Threading.Tasks;
using ProEventos.Domain;
using ProEventos.Service.Dtos;

namespace ProEventos.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> AddUsuario(UsuarioDto model);

        Task<UsuarioDto> UpdateUsuario(int id, UsuarioDto model);

        Task<bool> DeleteUsuario(int id);

        Task<UsuarioDto[]> GetUsuariosAsync();

        Task<UsuarioDto> GetUsuarioByIdAsync(int id);
    }
}