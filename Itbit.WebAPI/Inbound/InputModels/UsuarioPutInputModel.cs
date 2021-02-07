using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Itbit.WebAPI.Inbound.InputModels
{
    public class UsuarioPutInputModel
    {
        [MinLength(3)]
        [MaxLength(200)]
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(30)]
        public string Senha { get; set; }

        public bool Ativo { get; set; } = true;

        public int SexoId { get; set; }
    }
}
