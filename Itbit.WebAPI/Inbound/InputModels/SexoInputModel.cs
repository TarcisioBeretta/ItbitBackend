using System.ComponentModel.DataAnnotations;

namespace Itbit.WebAPI.Inbound.InputModels
{
    public class SexoInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo \"Descrição\" é obrigatório")]
        [MaxLength(15, ErrorMessage = "O campo \"Descrição\" pode ter no máximo 15 caracteres")]
        public string Descricao { get; set; }
    }
}
