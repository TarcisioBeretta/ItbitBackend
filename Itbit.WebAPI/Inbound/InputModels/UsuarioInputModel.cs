using System;
using System.ComponentModel.DataAnnotations;

namespace Itbit.WebAPI.Inbound.InputModels
{
    public class UsuarioInputModel
    {
        [Required(ErrorMessage = "O campo \"Nome\" é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo \"Nome\" pode ter no mínimo 3 caracteres")]
        [MaxLength(200, ErrorMessage = "O campo \"Nome\" pode ter no máximo 200 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo \"Data de nascimento\" é obrigatório")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo \"Email\" é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo \"Email\" pode ter no máximo 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo \"Senha\" é obrigatório")]
        [MaxLength(30, ErrorMessage = "O campo \"Senha\" pode ter no máximo 30 caracteres")]
        public string Senha { get; set; }

        [Required]
        public bool Ativo { get; set; } = true;

        [Required(ErrorMessage = "O campo \"Sexo\" é obrigatório")]
        public int? SexoId { get; set; }
    }
}
