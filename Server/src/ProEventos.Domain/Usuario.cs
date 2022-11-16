using System;

namespace ProEventos.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string User { get; set; }
        public string Senha { get; set; }
        public DateTime dataCriacao { get; set; }
    }
}