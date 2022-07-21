using AutoMapper;
using ProEventos.Domain;
using ProEventos.Service.Dtos;

namespace ProEventos.Service.Helpers
{
    public class ProEventosProfile : Profile
    {
        public ProEventosProfile()
        {
            CreateMap<Evento, EventoDto>();
        }
    }
}