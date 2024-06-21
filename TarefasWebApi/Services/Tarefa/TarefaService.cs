using Microsoft.EntityFrameworkCore;
using TarefasWebApi.Data;
using TarefasWebApi.Dtos.Tarefa;
using TarefasWebApi.Models;

namespace TarefasWebApi.Services.Tarefa
{
    public class TarefaService : ITarefaService
    {
        private readonly AppDbContext _appDbContext;

        public TarefaService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ApiResponseModel<List<TarefaModel>>> CriarTarefa(CriarTarefaDto criarTarefaDto)
        {
            ApiResponseModel<List<TarefaModel>> apiResponse = new ApiResponseModel<List<TarefaModel>>();

            try
            {

                var usuario = await _appDbContext.Usuarios
                     .FirstOrDefaultAsync(dbUsuario => dbUsuario.Id == criarTarefaDto.Usuario.Id);

                if (usuario == null)
                {
                    apiResponse.Mensagem = "Nenhum usuário encontrado!";
                    return apiResponse;
                }

                var tarefa = new TarefaModel()
                {
                    Nome = criarTarefaDto.Nome,
                    Descricao = criarTarefaDto.Descricao,
                    Status = criarTarefaDto.Status,
                    Usuario = usuario,
                };

                _appDbContext.Add(tarefa);
                await _appDbContext.SaveChangesAsync();

                apiResponse.Dados = await _appDbContext.Tarefas.ToListAsync();
                apiResponse.Mensagem = "Tarefa criada com sucesso!";

                return apiResponse;

            } catch(Exception ex)
            {
                apiResponse.Mensagem = ex.Message;
                apiResponse.Status = false;

                return apiResponse;
            }
        }

        public async Task<ApiResponseModel<List<TarefaModel>>> DeletarTarefa(int idTarefa)
        {
            ApiResponseModel<List<TarefaModel>> apiResponse = new ApiResponseModel<List<TarefaModel>>();

            try
            {
                var tarefa = await _appDbContext.Tarefas.FirstOrDefaultAsync(dbTarefa => dbTarefa.Id == idTarefa);

                if(tarefa == null)
                {
                    apiResponse.Mensagem = "Tarefa não encontrada!";

                    return apiResponse;
                }

                _appDbContext.Tarefas.Remove(tarefa);
                await _appDbContext.SaveChangesAsync();

                apiResponse.Dados = await _appDbContext.Tarefas.
                    Include(db => db.Usuario).ToListAsync();
                apiResponse.Mensagem = "Tarefa deletada com sucesso!";

                return apiResponse;

            } catch( Exception ex )
            {
                apiResponse.Mensagem = ex.Message;
                apiResponse.Status = false;

                return apiResponse;
            }
        }

        public async Task<ApiResponseModel<List<TarefaModel>>> EditarTarefa(EditarTarefaDto editarTarefaDto)
        {
            ApiResponseModel<List<TarefaModel>> apiResponse = new ApiResponseModel<List<TarefaModel>>();
            try
            {
                var tarefa = await _appDbContext.Tarefas
                    .Include(db => db.Usuario)
                    .FirstOrDefaultAsync(dbTarefa => dbTarefa.Id == editarTarefaDto.Id);

                var usuario = await _appDbContext.Usuarios
                    .FirstOrDefaultAsync(dbTarefa => dbTarefa.Id == editarTarefaDto.Usuario.Id);

                if(tarefa == null)
                {
                    apiResponse.Mensagem = "Tarefa não encontrada!";

                    return apiResponse;
                }

                if (usuario == null)
                {
                    apiResponse.Mensagem = "Usuário não encontrado!";

                    return apiResponse;
                }

                tarefa.Nome = editarTarefaDto.Nome;
                tarefa.Descricao = editarTarefaDto.Descricao;
                tarefa.Status = editarTarefaDto.Status;
                tarefa.Usuario = usuario;

                _appDbContext.Update(tarefa);
                await _appDbContext.SaveChangesAsync();

                apiResponse.Dados = await _appDbContext.Tarefas
                    .Include(db => db.Usuario).ToListAsync();
                apiResponse.Mensagem = "Tarefa editada com sucesso!";

                return apiResponse;

            }catch( Exception ex )
            {
                apiResponse.Mensagem=ex.Message;
                apiResponse.Status = false;

                return apiResponse;
            }

        }

        public async Task<ApiResponseModel<TarefaModel>> ListarTarefaPorIdTarefa(int idTarefa)
        {
            ApiResponseModel<TarefaModel> apiResponse = new ApiResponseModel<TarefaModel>();

            try
            {
                var tarefa = await _appDbContext.Tarefas.Include(db => db.Usuario).FirstOrDefaultAsync(dbTarefa => dbTarefa.Id == idTarefa);

                if(tarefa == null)
                {
                    apiResponse.Mensagem = "Tarefa não encontrada!";

                    return apiResponse;
                }

                apiResponse.Dados = tarefa;
                apiResponse.Mensagem = "Usuário encontrado com sucesso!";

                return apiResponse;

            } catch(Exception ex)
            {
                apiResponse.Mensagem = ex.Message;
                apiResponse.Status = false;

                return apiResponse;
            }
        }

        public async Task<ApiResponseModel<List<TarefaModel>>> ListarTarefas()
        {
            ApiResponseModel<List<TarefaModel>> apiResponse = new ApiResponseModel<List<TarefaModel>>();

            try
            {

                var tarefas = await _appDbContext.Tarefas.Include(db => db.Usuario).ToListAsync();

                apiResponse.Dados = tarefas;
                apiResponse.Mensagem = "Tarefas listadas com sucesso!";

                return apiResponse;

            } catch( Exception ex)
            {
                apiResponse.Mensagem = ex.Message;
                apiResponse.Status = false;

                return apiResponse;
            }
        }

        public async Task<ApiResponseModel<List<TarefaModel>>> ListarTarefasPorIdUsuario(int idUsuario)
        {
            ApiResponseModel<List<TarefaModel>> apiResponse = new ApiResponseModel<List<TarefaModel>>();

            try
            {
                var tarefas = await _appDbContext.Tarefas
                    .Include(db => db.Usuario)
                    .Where(dbTarefa => dbTarefa.Usuario.Id == idUsuario)
                    .ToListAsync();

                apiResponse.Dados = tarefas;
                apiResponse.Mensagem = "Tarefas listadas com sucesso!";

                return apiResponse;
                
            } catch(Exception ex)
            {
                apiResponse.Mensagem =ex.Message;
                apiResponse.Status = false;

                return apiResponse;
            }
        }
    }
}
