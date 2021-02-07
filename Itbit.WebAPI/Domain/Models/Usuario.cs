using System;
using System.ComponentModel.DataAnnotations;

namespace Itbit.WebAPI.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string Senha { get; set; }

        [Required]
        public bool Ativo { get; set; } = true;

        [Required]
        public int SexoId { get; set; }

        public Sexo Sexo { get; set; }
    }
}
