﻿using Microsoft.AspNetCore.Http;
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
        private readonly ITarefaService _iTarefaService;

        public TarefaController(ITarefaService iTarefaService)
        {
            _iTarefaService = iTarefaService;
        }

        [HttpGet("ListarTarefas")]
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
            var tarefas = await _iTarefaService.ListarTarefasPorIdUsuario(idUsuario);
            return Ok(tarefas);
        }

        [HttpPost("CriarTarefa")]
        public async Task<ActionResult<ApiResponseModel<List<TarefaModel>>>> CriarTarefa(CriarTarefaDto criarTarefaDto)
        {
            var tarefas = await _iTarefaService.CriarTarefa(criarTarefaDto);
            return Ok(tarefas);
        }

        [HttpPut("EditarTarefa")]
        public async Task<ActionResult<ApiResponseModel<List<TarefaModel>>>> EditarTarefa(EditarTarefaDto editarTarefaDto)
        {
            var tarefas = await _iTarefaService.EditarTarefa(editarTarefaDto);
            return Ok(tarefas);
        }

        [HttpDelete("DeletarTarefa/{idTarefa}")]
        public async Task<ActionResult<ApiResponseModel<List<TarefaModel>>>> DeletarTarefa(int idTarefa)
        {
            var tarefas = await _iTarefaService.DeletarTarefa(idTarefa);
            return Ok(tarefas);
        }
    }
}
