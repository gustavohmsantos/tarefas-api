using TarefasWebApi.Dtos.Tarefa;
using TarefasWebApi.Models;

namespace TarefasWebApi.Services.Tarefa
{
    public interface ITarefaService
    {
        public Task<ApiResponseModel<List<TarefaModel>>> ListarTarefas();

        public Task<ApiResponseModel<TarefaModel>> ListarTarefaPorIdTarefa(int idTarefa);

        public Task<ApiResponseModel<List<TarefaModel>>> ListarTarefasPorIdUsuario(int idUsuario);

        public Task<ApiResponseModel<List<TarefaModel>>> CriarTarefa(CriarTarefaDto criarTarefaDto);

        public Task<ApiResponseModel<List<TarefaModel>>> EditarTarefa(EditarTarefaDto editarTarefaDto);

        public Task<ApiResponseModel<List<TarefaModel>>> DeletarTarefa(int idTarefa);
    }
}
