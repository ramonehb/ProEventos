using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain;
using ProEventos.Service;
using ProEventos.Service.Dtos;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);
                if (eventos is null) return NoContent();

                return Ok(eventos);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar recuperar eventos. Erro: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetById(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id, true);
                if (evento is null) return NoContent();

                return Ok(evento);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar recuperar Evento por Id.\nErro: {e.Message}");
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<ActionResult<Evento>> GetAllEventosByTema(string tema)
        {
            try
            {
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if (evento is null) return NoContent();

                return Ok(evento);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar recuperar Evento por Id.\nErro: {e.Message}");
            }
        }

        [HttpPost("{Evento}")]
        public async Task<ActionResult<Evento>> Post(EventoDto model)
        {
            try
            {
                var evento = await _eventoService.AddEventos(model);
                if (evento is null) return NoContent();

                return Ok(evento);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar adicionar o evento.\nErro: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Evento>> Put(int id, EventoDto model)
        {
            try
            {
                var evento = await _eventoService.UpdateEvento(id, model);
                if (evento is null) return NoContent();

                return Ok(evento);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar o evento.\nErro: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id);

                if (evento is null) return NoContent();

                return await _eventoService.DeleteEvento(id) ? Ok(new {mensagem = "Deletado"}) : throw new Exception("Ocorreu um erro ao deletar o evento.");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar deletar o evento.\nErro: {e.Message}");
            }
        }
    }
}
