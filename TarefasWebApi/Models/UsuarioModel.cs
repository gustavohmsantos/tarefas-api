using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TarefasWebApi.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        [JsonIgnore]
        public ICollection<TarefaModel> Tarefas { get; set; }

    }
}
