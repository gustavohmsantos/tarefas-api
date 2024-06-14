using TarefasWebApi.Dtos.Usuario;
using TarefasWebApi.Models;

namespace TarefasWebApi.Services.Usuario
{
    public interface IUsuarioService
    {
        Task<ApiResponseModel<List<UsuarioModel>>> ListarUsuarios();

        Task<ApiResponseModel<UsuarioModel>> ListarUsuarioPorIdUsuario(int idUsuario);

        Task<ApiResponseModel<UsuarioModel>> ListarUsuarioPorIdTarefa(int idTarefa);

        Task<ApiResponseModel<List<UsuarioModel>>> CriarUsuario(CriarUsuarioDto criarUsuarioDto);

        Task<ApiResponseModel<List<UsuarioModel>>> EditarUsuario(EditarUsuarioDto editarUsuarioDto);

        Task<ApiResponseModel<List<UsuarioModel>>> DeletarUsuario(int idUsuario);

    }
}
