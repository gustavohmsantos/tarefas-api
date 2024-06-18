using TarefasWebApi.Enums;
using TarefasWebApi.Models;

namespace TarefasWebApi.Dtos.Tarefa
{
    public class EditarTarefaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TarefaStatusEnum Status { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}
