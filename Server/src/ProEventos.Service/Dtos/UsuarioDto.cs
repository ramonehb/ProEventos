using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Service.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório."),
        StringLength(50, MinimumLength = 3, ErrorMessage = "O nome deve ter no mínimo 3 ou no máximo 50 carecteres.")]
        public string Nome { get; set; }


        [EmailAddress(ErrorMessage = "Informe um e-mail válido."),
        StringLength(100, MinimumLength = 3, ErrorMessage = "O e-mail deve ter no mínimo 5 ou no máximo 100 carecteres.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "O campo usuário é obrigatório."),
        StringLength(25, MinimumLength = 3, ErrorMessage = "O usuário deve ter no mínimo 3 ou no máximo 25 carecteres.")]
        public string User { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório."),
        StringLength(25, MinimumLength = 3, ErrorMessage = "O campo senha deve ter no mínimo 3 ou no máximo 25 carecteres.")]
        public string senha { get; set; }
    }
}