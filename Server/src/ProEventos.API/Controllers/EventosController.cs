using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;

namespace ProEventos.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EventosController : ControllerBase
  {
    private readonly DataContext _context;
    public EventosController(DataContext context)
    {
      _context = context;
    }

    // [HttpGet]
    // public IEnumerable<Evento> Get()
    // {
    //   return _context.Eventos;
    // }

    // [HttpGet("{id}")]
    // public Evento GetById(int id)
    // {
    //   return _context.Eventos.SingleOrDefault(e => e.EventoId == id);
    // }

    // [HttpPost("{Evento}")]
    // public string Post(Evento evento)
    // {
    //   var retorno = new EventoRetornoModel();
    //   try
    //   {
    //     _context.Eventos.Add(evento);
    //     _context.SaveChanges();
    //     retorno.Mensagem = "Evento criado";
    //     retorno.Sucesso = true;
    //   }
    //   catch (Exception e)
    //   {
    //     retorno.Mensagem = $"Erro ao gravar Evento: {e.Message}";
    //     retorno.Sucesso = false;
    //   }

    //   return retorno;
    // }

    [HttpPut("{id}")]
    public string Put(int id)
    {
      return "Put Method";
    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
      return "Delete Method";
    }
  }
}
