using System.Threading.Tasks;
using ProEventos.Domain;
using ProEventos.Service.Dtos;

namespace ProEventos.Service
{
    public interface ILoteService
    {
        Task AddLote(int eventoId, LoteDto model);
        Task<LoteDto[]> SaveLotes(int eventoId, LoteDto[] models);
        Task<bool> DeleteLote(int eventoId, int loteId);

        Task<LoteDto[]> GetLotesByEventoIdAsync(int eventoId);
        Task<LoteDto> GetLoteByIdsAsync(int eventoId, int loteId);
    }
}