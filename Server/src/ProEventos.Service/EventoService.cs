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
        private readonly IMapper mapper;

        public EventoService(IGeralPersist geralPersist, 
                             IEventoPersist eventoPersist, 
                             IMapper mapper)
        {
            this.mapper = mapper;
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;

        }

        public async Task<EventoDto> AddEventos(EventoDto model)
        {
            // try
            // {
            //     _geralPersist.Add<EventoDto>(model);
            //     if (await _geralPersist.SaveChangeAsync())
            //     {
            //         return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
            //     }

            //     return null;
            // }
            // catch (Exception e)
            // {
            //     throw new Exception($"Erro: {e.Message}");
            // }
            return null;
        }

        public async Task<Evento> UpdateEvento(int id, EventoDto model)
        {
            // try
            // {
            //     var evento = await _eventoPersist.GetEventoByIdAsync(id);
            //     if (evento is null) return null;

            //     model.Id = evento.Id;
            //     _geralPersist.Update(model);
            //     if (await _geralPersist.SaveChangeAsync())
            //     {
            //         return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
            //     }

            //     return null;
            // }
            // catch (Exception e)
            // {
            //     throw new Exception($"Erro: {e.Message}");
            // }
            return null;
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

                return mapper.Map<EventoDto[]>(eventos);
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

                return mapper.Map<EventoDto[]>(eventos);
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

                return mapper.Map<EventoDto>(evento);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }

        Task<EventoDto> IEventoService.UpdateEvento(int id, EventoDto model)
        {
            throw new NotImplementedException();
        }
    }
}
