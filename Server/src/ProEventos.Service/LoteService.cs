using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Domain;
using ProEventos.Persistence.Interfaces;
using ProEventos.Service.Dtos;

namespace ProEventos.Service
{
    public class LoteService : ILoteService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly ILotePersist _lotePersist;
        private readonly IMapper _mapper;

        public LoteService(IGeralPersist geralPersist,
                             ILotePersist lotePersist,
                             IMapper mapper)
        {
            _mapper = mapper;
            _geralPersist = geralPersist;
            _lotePersist = lotePersist;

        }
        public async Task AddLote(int eventoId, LoteDto model)
        {
            try
            {
                var lote = _mapper.Map<Lote>(model);
                lote.EventoId = eventoId;

                _geralPersist.Add<Lote>(lote);

                await _geralPersist.SaveChangeAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }
        public async Task<LoteDto[]> SaveLotes(int eventoId, LoteDto[] models)
        {
            try
            {
                var lotes = await _lotePersist.GetLotesByEventoIdAsync(eventoId);
                if (lotes is null) return null;

                foreach (var model in models)
                {
                    if (model.EventoId == 0)
                    {
                        await AddLote(eventoId, model);
                    }
                    else
                    {
                        var lote = lotes.FirstOrDefault(lote => lote.Id == model.Id);
                        model.EventoId = eventoId;

                        _mapper.Map(model, lote);

                        _geralPersist.Update<Lote>(lote);

                        await _geralPersist.SaveChangeAsync();
                    }
                }

                var loteRetorno = await _lotePersist.GetLotesByEventoIdAsync(eventoId);
                return _mapper.Map<LoteDto[]>(loteRetorno);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }

        public async Task<bool> DeleteLote(int eventoId, int loteId)
        {
            try
            {
                var lote = await _lotePersist.GetLoteByIdsAsync(eventoId, loteId);
                if (lote is null) throw new Exception("Lote para delete não encontrado.");

                _geralPersist.Delete<Lote>(lote);

                return await _geralPersist.SaveChangeAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }

        public async Task<LoteDto[]> GetLotesByEventoIdAsync(int eventoId)
        {
            try
            {
                var lotes = await _lotePersist.GetLotesByEventoIdAsync(eventoId);
                if (lotes is null) return null;

                return _mapper.Map<LoteDto[]>(lotes);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }

        public async Task<LoteDto> GetLoteByIdsAsync(int eventoId, int loteId)
        {
            try
            {
                var lote = await _lotePersist.GetLoteByIdsAsync(eventoId, loteId);
                if (lote is null) return null;

                return _mapper.Map<LoteDto>(lote);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }
    }
}
