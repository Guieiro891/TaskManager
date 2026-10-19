
namespace TaskManager.Application.DTOs.Tarefas;

public class TarefaDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool Concluida { get; set; }
    public DateTime DataCriacao { get; set; }
    public int CategoriaId { get; set; }
    public string NomeCategoria { get; set; } = string.Empty;
}
