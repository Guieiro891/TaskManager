
using TaskManager.Application.Interfaces;
using TaskManager.Domain;


namespace TaskManager.Application.Services;

public class TarefaService : ITarefaService
{
    private readonly ITarefaRepository _repository;
    public TarefaService (ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Tarefa>> Listar()
    {
        return await _repository.Listar();
    }

    public async Task<Tarefa?> Buscar(int id)
    {
        return await _repository.Buscar(id);
    } 

    public async Task<Tarefa> Criar(Tarefa tarefa)
    {
        return await _repository.Criar(tarefa);
    }

    public async Task Atualizar(Tarefa tarefa)
    {
        await _repository.Atualizar(tarefa);
    }

    public async Task Deletar (int id)
    {
        await _repository.Deletar(id);
    }
}
