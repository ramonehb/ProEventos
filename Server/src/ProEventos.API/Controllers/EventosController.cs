using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

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

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
      return _context.Eventos;
    }

    [HttpGet("{id}")]
    public Evento GetById(int id)
    {
      return _context.Eventos.SingleOrDefault(e => e.EventoId == id);
    }

    [HttpPost("{Evento}")]
    public string Post(Evento evento)
    {
      return JsonSerializer.Serialize(evento);
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
