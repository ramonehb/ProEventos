using System.Threading.Tasks;
using ProEventos.Persistence.Interfaces;
using ProEventos.Persistence.Contextos;

namespace ProEventos.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly Context _context;
        public GeralPersist(Context context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void DeleteRange<T>(T entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}