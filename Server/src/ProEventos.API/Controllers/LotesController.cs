﻿using System;
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
    public class LotesController : ControllerBase
    {
        private readonly ILoteService _loteService;
        public LotesController(ILoteService loteService)
        {
            _loteService = loteService;
        }

        /// <summary>
        /// Retorna todos os lotes do determinado evento passado como parâmetro.
        /// </summary>
        /// <param name="eventoId">Código unico do evento.</param>
        /// <returns></returns>
        [HttpGet("{eventoId}")]
        public async Task<ActionResult> Get(int eventoId)
        {
            try
            {
                var lotes = await _loteService.GetLotesByEventoIdAsync(eventoId);
                if (lotes is null) return NoContent();

                return Ok(lotes);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar recuperar lotes. Erro: {e.Message}");
            }
        }

        /// <summary>
        /// Salvar e atualiza os lotes.
        /// </summary>
        /// <param name="eventoId">Código unico do evento.</param>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPut("{eventoId}")]
        public async Task<ActionResult<Evento>> SaveLotes(int eventoId, LoteDto[] models)
        {
            try
            {
                var lote = await _loteService.SaveLotes(eventoId, models);
                if (lote is null) return NoContent();

                return Ok(lote);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar o lotes.\nErro: {e.Message}");
            }
        }

        /// <summary>
        /// Deleta um lote do evento.
        /// </summary>
        /// <param name="eventoId">Código unico do evento.</param>
        /// <param name="loteId"></param>
        /// <returns></returns>
        [HttpDelete("{eventoId}/{loteId}")]
        public async Task<ActionResult> Delete(int eventoId, int loteId)
        {
            try
            {
                var lote = await _loteService.GetLoteByIdsAsync(eventoId, loteId);

                if (lote is null) return NoContent();

                return await _loteService.DeleteLote(lote.EventoId, lote.Id) 
                    ? Ok(new {mensagem = "Lote Deletado"}) 
                    : throw new Exception("Ocorreu um erro ao deletar o lote.");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar deletar o evento.\nErro: {e.Message}");
            }
        }
    }
}
