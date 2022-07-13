using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly Context _context;
        public PalestrantePersist(Context context)
        {
            _context = context;
        }
        
        public async Task<Palestrante[]> GetAllPalestranteByNameAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(e => e.Evento);
            }
            query = query.OrderBy(p => p.Id)
                         .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query.
                    Include(p => p.PalestrantesEventos)
                    .ThenInclude(e => e.Evento);
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante> GetPalestranteByIdAsync(int id, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(e => e.Evento);
            }

            query = query.OrderBy(p => p.Id)
                         .Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}