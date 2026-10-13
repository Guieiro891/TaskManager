using TaskManager.Domain;

namespace TaskManager.Application.Interfaces;

public interface ITarefaService
{
    Task<List<Tarefa>> Listar();
    Task<Tarefa?> Buscar(int id);
    Task<Tarefa> Criar(Tarefa tarefa);
    Task Atualizar(Tarefa tarefa);
    Task Deletar(int id);
}
