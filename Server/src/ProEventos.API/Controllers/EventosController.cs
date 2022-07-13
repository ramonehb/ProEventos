using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence.Contexto;
using ProEventos.Domain;

namespace ProEventos.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EventosController : ControllerBase
  {
    private readonly ProEventosContext _context;
    public EventosController(ProEventosContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
      return _context.Eventos;
    }

    [HttpGet("{id}")]
    public Evento GetById(int id)
    {
      return _context.Eventos.SingleOrDefault(e => e.Id == id);
    }

    [HttpPost("{Evento}")]
    public string Post(Evento evento)
    {
      try
      {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
      }
      catch (Exception e)
      {
        var msg = e.Message;
      }

      return "Sucesso";
    }

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
