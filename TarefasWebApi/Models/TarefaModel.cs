using System.ComponentModel.DataAnnotations;
using TarefasWebApi.Enums;

namespace TarefasWebApi.Models
{
    public class TarefaModel
    {
        [Key]
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public TarefaSatusEnum Status { get; set; }

        public UsuarioModel Usuario { get; set; }

    }
}
