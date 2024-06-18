using TarefasWebApi.Enums;
using TarefasWebApi.Models;

namespace TarefasWebApi.Dtos.Tarefa
{
    public class EditarTarefaDto
    {
        public int Id { get; set; }
        public int Nome { get; set; }
        public string Descricao { get; set; }
        public TarefaStatusEnum Status { get; set; }
        public int UsuarioId { get; set; }
    }
}
