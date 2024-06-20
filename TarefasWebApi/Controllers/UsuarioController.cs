using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarefasWebApi.Dtos.Usuario;
using TarefasWebApi.Models;
using TarefasWebApi.Services.Usuario;

namespace TarefasWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _iUsuarioService;

        public UsuarioController(IUsuarioService iUsuarioService)
        {
            _iUsuarioService = iUsuarioService;
        }

        [HttpGet("ListarUsuarios")]
        public async Task<ActionResult<ApiResponseModel<List<UsuarioModel>>>> ListarUsuarios()
        {
            var usuarios = await _iUsuarioService.ListarUsuarios();
            return Ok(usuarios);    
        }

        [HttpGet("ListarUsuarioPorIdUsuario/{idUsuario}")]
        public async Task<ActionResult<ApiResponseModel<UsuarioModel>>> ListarUsuarioPorIdUsuario(int idUsuario)
        {
            var usuario = await _iUsuarioService.ListarUsuarioPorIdUsuario(idUsuario);
            return Ok(usuario);
        }

        [HttpGet("ListarUsuarioPorIdTarefa/{idTarefa}")]
        public async Task<ActionResult<ApiResponseModel<UsuarioModel>>> ListarUsuarioPorIdTarefa(int idTarefa)
        {
            var usuario = await _iUsuarioService.ListarUsuarioPorIdTarefa(idTarefa);
            return Ok(usuario);
        }

        [HttpPost("CriarUsuario")]
        public async Task<ActionResult<ApiResponseModel<List<UsuarioModel>>>> CriarUsuario(CriarUsuarioDto criarUsuarioDto)
        {
            var usuarios = await _iUsuarioService.CriarUsuario(criarUsuarioDto);
            return Ok(usuarios);
        }

        [HttpPut("EditarUsuario")]
        public async Task<ActionResult<ApiResponseModel<List<UsuarioModel>>>> EditarUsuario(EditarUsuarioDto editarUsuarioDto)
        {
            var usuarios = await _iUsuarioService.EditarUsuario(editarUsuarioDto);
            return Ok(usuarios);
        }

        [HttpDelete("DeletarUsuario/{idUsuario}")]
        public async Task<ActionResult<ApiResponseModel<List<UsuarioModel>>>> DeletarUsuario(int idUsuario)
        {
            var usuarios = await _iUsuarioService.DeletarUsuario(idUsuario);
            return Ok(usuarios);
        }


    }
}
