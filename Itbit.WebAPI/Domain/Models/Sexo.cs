using System.ComponentModel.DataAnnotations;

namespace Itbit.WebAPI.Domain.Models
{
    public class Sexo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Descricao { get; set; }
    }
}
