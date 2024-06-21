using TarefasWebApi.Dtos.Usuario;
using TarefasWebApi.Dtos.Vinculo;
using TarefasWebApi.Enums;
using TarefasWebApi.Models;

namespace TarefasWebApi.Dtos.Tarefa
{
    public class CriarTarefaDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TarefaStatusEnum Status { get; set; }
        public UsuarioVinculoDto Usuario { get; set; }
    }
}
