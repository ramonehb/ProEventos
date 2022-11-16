using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain;
using ProEventos.Service;
using ProEventos.Service.Dtos;
using ProEventos.Service.Interfaces;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuariosAsync();
                if (usuarios is null) return NoContent();

                return Ok(usuarios);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar recuperar usuários. Erro: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetById(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
                if (usuario is null) return NoContent();

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                  $"Erro ao tentar recuperar Usuário por Id.\nErro: {e.Message}");
            }
        }


        [HttpPost("{Usuario}")]
        public async Task<ActionResult<Usuario>> Post(UsuarioDto model)
        {
            try
            {
                var usuario = await _usuarioService.AddUsuario(model);
                if (usuario is null) return NoContent();

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar adicionar o usuário.\nErro: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Evento>> Put(int id, UsuarioDto model)
        {
            try
            {
                var usuario = await _usuarioService.UpdateUsuario(id, model);
                if (usuario is null) return NoContent();

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar o usuário.\nErro: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuarioByIdAsync(id);

                if (usuario is null) return NoContent();

                return await _usuarioService.DeleteUsuario(id) ? Ok(new {mensagem = "Deletado"}) : throw new Exception("Ocorreu um erro ao deletar o usuário.");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                 $"Erro ao tentar deletar o usuário.\nErro: {e.Message}");
            }
        }
    }
}
