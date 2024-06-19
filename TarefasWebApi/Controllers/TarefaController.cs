using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarefasWebApi.Dtos.Tarefa;
using TarefasWebApi.Models;
using TarefasWebApi.Services.Tarefa;

namespace TarefasWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        readonly private ITarefaService _iTarefaService;

        public TarefaController(ITarefaService iTarefaService)
        {
            _iTarefaService = iTarefaService;
        }

        public async Task<ActionResult<ApiResponseModel<List<TarefaModel>>>> ListarTarefas()
        {
            var tarefas = await _iTarefaService.ListarTarefas();
            return Ok(tarefas);
        }

        [HttpGet("ListarTarefaPorIdTarefa/{idTarefa}")]
        public async Task<ActionResult<ApiResponseModel<TarefaModel>>> ListarTarefaPorIdTarefa(int idTarefa)
        {
            var tarefa = await _iTarefaService.ListarTarefaPorIdTarefa(idTarefa);
            return Ok(tarefa);
        }

        [HttpGet("ListarTarefasPorIdUsuario/{idUsuario}")]
        public async Task<ActionResult<ApiResponseModel<List<TarefaModel>>>> ListarTarefasPorIdUsuario(int idUsuario)
        {
            var tarefas = await _iTarefaService.ListarTarefaPorIdTarefa(idUsuario);
            return Ok(tarefas);
        }

        [HttpGet("CriarTarefa")]
        public async Task<ActionResult<ApiResponseModel<List<TarefaModel>>>> CriarTarefa(CriarTarefaDto criarTarefaDto)
        {
            var tarefas = await _iTarefaService.CriarTarefa(criarTarefaDto);
            return Ok(tarefas);
        }

        [HttpGet("EditarTarefa")]
        public async Task<ActionResult<ApiResponseModel<List<TarefaModel>>>> EditarTarefa(EditarTarefaDto editarTarefaDto)
        {
            var tarefas = await _iTarefaService.EditarTarefa(editarTarefaDto);
            return Ok(tarefas);
        }

        [HttpGet("DeletarTarefa/{idTarefa}")]
        public async Task<ActionResult<ApiResponseModel<List<TarefaModel>>>> DeletarTarefa(int idTarefa)
        {
            var tarefas = await _iTarefaService.DeletarTarefa(idTarefa);
            return Ok(tarefas);
        }
    }
}
