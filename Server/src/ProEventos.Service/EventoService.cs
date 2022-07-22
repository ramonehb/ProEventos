using System;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Domain;
using ProEventos.Persistence.Interfaces;
using ProEventos.Service.Dtos;

namespace ProEventos.Service
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        private readonly IMapper _mapper;

        public EventoService(IGeralPersist geralPersist, 
                             IEventoPersist eventoPersist, 
                             IMapper mapper)
        {
            _mapper = mapper;
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;

        }

        public async Task<EventoDto> AddEventos(EventoDto model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);
                
                _geralPersist.Add<Evento>(evento);

                if (await _geralPersist.SaveChangeAsync())
                {
                    var eventoRetorno = await _eventoPersist.GetEventoByIdAsync(evento.Id, false);
                    return _mapper.Map<EventoDto>(eventoRetorno);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }

        public async Task<EventoDto> UpdateEvento(int id, EventoDto model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(id);
                if (evento is null) return null;

                model.Id = evento.Id;
                
                _mapper.Map(model, evento);

                _geralPersist.Update<Evento>(evento);

                if (await _geralPersist.SaveChangeAsync())
                {
                    var eventoRetorno = await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                    return  _mapper.Map<EventoDto>(eventoRetorno);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }

        public async Task<bool> DeleteEvento(int id)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(id);
                if (evento is null) throw new Exception("Evento para delete não encontrado.");

                _geralPersist.Delete<Evento>(evento);

                return await _geralPersist.SaveChangeAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }

        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                if (eventos is null) return null;

                return _mapper.Map<EventoDto[]>(eventos);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema);
                if (eventos is null) return null;

                return _mapper.Map<EventoDto[]>(eventos);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }

        public async Task<EventoDto> GetEventoByIdAsync(int id, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(id);
                if (evento is null) return null;

                return _mapper.Map<EventoDto>(evento);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }
    }
}
