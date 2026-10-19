using TaskManager.Application.DTOs.Tarefas;
using TaskManager.Application.DTOs.Mappers;
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

    public async Task<List<TarefaDto>> Listar()
    {
        var tarefas = await _repository.Listar();
        return tarefas.Select(t => TarefaMapper.ToDto(t)).ToList();
    }

    public async Task<TarefaDto?> Buscar(int id)
    {
        var tarefa = await _repository.Buscar(id);
        return tarefa == null ? null : TarefaMapper.ToDto(tarefa);
    } 

    public async Task<TarefaDto> Criar(CriarTarefaDto dto)
    {
        var tarefa = TarefaMapper.ToEntity(dto);  // entidade nova pronta
        var tarefaCriada = await _repository.Criar(tarefa); //entidade enviada ao repository para ele salvar 
        return TarefaMapper.ToDto(tarefaCriada); 
    }

    public async Task Atualizar(int id, AtualizarTarefaDto dto)
    {
        var tarefa = await _repository.Buscar(id);
        if (tarefa == null) return;

        tarefa.Titulo = dto.Titulo;
        tarefa.Descricao = dto.Descricao;
        tarefa.CategoriaId = dto.CategoriaId;
        tarefa.Concluida = dto.Concluida;

        await _repository.Atualizar(tarefa);
    }

    public async Task Deletar (int id)
    {
        await _repository.Deletar(id);
    }
}
