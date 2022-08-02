using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Service.Dtos
{
    public class EventoDto
    {
        public int Id {get; set;}

        [Required(ErrorMessage = "O campo local é obrigatório."),
        StringLength(50, MinimumLength = 3, ErrorMessage = "O local deve ter no mínimo 3 ou no máximo 50 carecteres.")]
        public string Local { get; set; }
        
        public DateTime DataEvento { get; set; }

        [Required(ErrorMessage = "O campo tema é obrigatório."),
        StringLength(50, MinimumLength = 3, ErrorMessage = "O tema deve ter no mínimo 3 ou no máximo 50 carecteres.")]
        public string Tema { get; set; }

        [Range(1, 120000, ErrorMessage = "A quantidade de pessoas deve ter no mínimo 1 ou no máximo 120000.")]
        public int QtdPessoas { get; set; }
        
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Não é uma imagem válida. (gif, jpg, jpeg, bmp ou png).")]
        public string ImagemURL { get; set; }
        
        [Phone(ErrorMessage = "O campo telefone está com número inválido.")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Informe um e-mail válido."),
        StringLength(100, MinimumLength = 3, ErrorMessage = "O e-mail deve ter no mínimo 5 ou no máximo 100 carecteres.")]
        public string Email { get; set; }        

        public IEnumerable<LoteDto> Lotes { get; set; }

        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }

        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }
}