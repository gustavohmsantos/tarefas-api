using Microsoft.EntityFrameworkCore;
using TarefasWebApi.Data;
using TarefasWebApi.Dtos.Usuario;
using TarefasWebApi.Models;

namespace TarefasWebApi.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        AppDbContext _appDbContext;

        public UsuarioService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ApiResponseModel<List<UsuarioModel>>> CriarUsuario(CriarUsuarioDto criarUsuarioDto)
        {
            ApiResponseModel<List<UsuarioModel>> apiResponse = new ApiResponseModel<List<UsuarioModel>>();

            try
            {
                var usuario = new UsuarioModel()
                {
                    Nome = criarUsuarioDto.Nome,
                    Email = criarUsuarioDto.Email
                };

                _appDbContext.Add(usuario);
                await _appDbContext.SaveChangesAsync();

                apiResponse.Dados = await _appDbContext.Usuarios.ToListAsync();
                apiResponse.Mensagem = "Usuario criado com sucesso!";

                return apiResponse;

            }catch(Exception ex)
            {
                apiResponse.Mensagem = ex.Message;
                apiResponse.Status = false;

                return apiResponse;
            }
        }

        public async Task<ApiResponseModel<List<UsuarioModel>>> DeletarUsuario(int idUsuario)
        {
            ApiResponseModel<List<UsuarioModel>> apiResponse = new ApiResponseModel<List<UsuarioModel>>();

            try
            {
                var usuario = await _appDbContext.Usuarios
                    .FirstOrDefaultAsync(dbUsuario => dbUsuario.Id == idUsuario);

                if(usuario == null)
                {
                    apiResponse.Mensagem = "Nenhum usuário encontrado!";
                    return apiResponse;
                }

                _appDbContext.Remove(usuario);
                await _appDbContext.SaveChangesAsync();

                apiResponse.Dados = await _appDbContext.Usuarios.ToListAsync();
                apiResponse.Mensagem = "Usuário deletado com sucesso!";

                return apiResponse;

            }catch(Exception ex)
            {
                apiResponse.Mensagem = ex.Message;
                apiResponse.Status = false;

                return apiResponse;
            }
        }

        public async Task<ApiResponseModel<List<UsuarioModel>>> EditarUsuario(EditarUsuarioDto editarUsuarioDto)
        {
            ApiResponseModel<List<UsuarioModel>> apiResponse = new ApiResponseModel<List<UsuarioModel>>();
            try
            {
                var usuario = await _appDbContext.Usuarios
                    .FirstOrDefaultAsync(dbUsuario => dbUsuario.Id == editarUsuarioDto.Id);

                if( usuario == null)
                {
                    apiResponse.Mensagem = "Nenhum usuário encontrado!";

                    return apiResponse;
                }

                usuario.Nome = editarUsuarioDto.Nome;
                usuario.Email = editarUsuarioDto.Email;

                _appDbContext.Update(usuario);
                await _appDbContext.SaveChangesAsync();

                apiResponse.Dados = await _appDbContext.Usuarios.ToListAsync();
                apiResponse.Mensagem = "Usuário atualizado com sucesso!";

                return apiResponse;

            }catch(Exception ex)
            {
                apiResponse.Mensagem = ex.Message;
                apiResponse.Status = false;

                return apiResponse;
            }
        }

        public async Task<ApiResponseModel<UsuarioModel>> ListarUsuarioPorIdTarefa(int idTarefa)
        {
            ApiResponseModel<UsuarioModel> apiResponse = new ApiResponseModel<UsuarioModel>();
            try
            {
                var tarefa = await _appDbContext.Tarefas
                    .Include(db => db.Usuario)
                    .FirstOrDefaultAsync(dbTarefa => dbTarefa.Id == idTarefa);

                if(tarefa  == null)
                {
                    apiResponse.Mensagem = "Nenhuma tarefa encontrada!";

                    return apiResponse;
                }

                apiResponse.Dados = tarefa.Usuario;
                apiResponse.Mensagem = "Usuário encontrado com sucesso!";

                return apiResponse;

            }catch(Exception ex)
            {
                apiResponse.Mensagem=ex.Message;
                apiResponse.Status = false;

                return apiResponse;
            }
        }

        public async Task<ApiResponseModel<UsuarioModel>> ListarUsuarioPorIdUsuario(int idUsuario)
        {
            ApiResponseModel<UsuarioModel> apiResponse = new ApiResponseModel<UsuarioModel>();

            try
            {
                var usuario = await _appDbContext.Usuarios
                    .FirstOrDefaultAsync(dbUsuario => dbUsuario.Id == idUsuario);

                if(usuario == null)
                {
                    apiResponse.Mensagem = "Usuário não encontrado!";
                    return apiResponse;
                }

                apiResponse.Dados = usuario;
                apiResponse.Mensagem = "Usuário encontrado com sucesso!";

                return apiResponse;

            } catch(Exception ex)
            {
                apiResponse.Mensagem = ex.Message;
                apiResponse.Status = false;
                return apiResponse;
            }

        }

        public async Task<ApiResponseModel<List<UsuarioModel>>> ListarUsuarios()
        {
            ApiResponseModel<List<UsuarioModel>> apiResponse = new ApiResponseModel<List<UsuarioModel>>();

            try
            {
                var usuarios = await _appDbContext.Usuarios.ToListAsync();

                apiResponse.Dados = usuarios;
                apiResponse.Mensagem = "Usuários listados com sucesso!";

                return apiResponse;

            } catch(Exception ex)
            {
                apiResponse.Mensagem = ex.Message;
                apiResponse.Status = false;

                return apiResponse;
            }
        }
    }
}
