using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class UsuarioPersist :IUsuarioPersist
    {
        private readonly Context _context;

        public UsuarioPersist (Context context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
             IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking()
                         .Where(u => u.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Usuario[]> GetUsuariosAsync()
        {
            var usuarios = _context.Usuarios.ToArrayAsync();

            return await usuarios;
        }
    }
}