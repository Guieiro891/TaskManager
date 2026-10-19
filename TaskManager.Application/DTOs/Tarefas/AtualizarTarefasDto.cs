
namespace TaskManager.Application.DTOs.Tarefas;

public class AtualizarTarefaDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int CategoriaId { get; set; }
    public bool Concluida { get; set; }
}
