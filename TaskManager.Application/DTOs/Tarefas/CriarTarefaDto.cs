
namespace TaskManager.Application.DTOs.Tarefas;


public class CriarTarefaDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int CategoriaId { get; set; }
}
