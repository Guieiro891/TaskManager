using TaskManager.Application.DTOs.Tarefas;
using TaskManager.Domain;

namespace TaskManager.Application.Interfaces;

public interface ITarefaService
{
    Task<List<TarefaDto>> Listar();
    Task<TarefaDto?> Buscar(int id);
    Task<TarefaDto> Criar(CriarTarefaDto dto);
    Task Atualizar(int id, AtualizarTarefaDto dto);
    Task Deletar(int id);
}
