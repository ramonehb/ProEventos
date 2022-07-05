using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EventoController : ControllerBase
  {
    public IEnumerable<Evento> _evento = new Evento[]{
      new Evento(){
        EventoId = 1,
        Local = "São Paulo",
        DataEvento = DateTime.Now.AddDays(2),
        Tema = "Angular 10 e .NET 5",
        QtdPessoas = 15,
        Lote = "1º Lote",
        ImagemURL = "www.google.com/photos/humberto.png"
      },
      new Evento(){
        EventoId = 2,
        Local = "Rio de Janeiro",
        DataEvento = DateTime.Now.AddDays(2),
        Tema = "HTML5 CSS3 Javascript",
        QtdPessoas = 15,
        Lote = "3º Lote",
        ImagemURL = "www.google.com/photos/amanda.png"
      }
    };

    public EventoController()
    {
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
      return _evento;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
      return _evento.Where(e => e.EventoId == id);
    }

    [HttpPost]
    public string Post()
    {
      return "Post Method";
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
