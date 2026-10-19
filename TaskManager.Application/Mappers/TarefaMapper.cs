
using TaskManager.Application.DTOs.Tarefas;
using TaskManager.Domain;
namespace TaskManager.Application.DTOs.Mappers;

public static class TarefaMapper
{
    public static TarefaDto ToDto(Tarefa tarefa)
    {
        return new TarefaDto
        {
            Id = tarefa.Id,
            Titulo = tarefa.Titulo,
            Descricao = tarefa.Descricao,
            Concluida = tarefa.Concluida,
            DataCriacao = tarefa.DataCriacao,
            CategoriaId = tarefa.CategoriaId,
            NomeCategoria = tarefa.Categoria?.Nome ?? string.Empty
        };
    }
    
    public static Tarefa ToEntity(CriarTarefaDto dto)
    {
        return new Tarefa
        {
            Titulo = dto.Titulo,
            Descricao = dto.Descricao,
            CategoriaId = dto.CategoriaId,
            DataCriacao = DateTime.Now
        };
    }

    public static Tarefa ToEntity(AtualizarTarefaDto dto)
    {
        return new Tarefa
        {
            Titulo = dto.Titulo,
            Descricao = dto.Descricao,
            CategoriaId = dto.CategoriaId,
            Concluida = dto.Concluida
        };
    }
}