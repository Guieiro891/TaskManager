
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Application.DTOs.Tarefas;


public class CriarTarefaDto
{
    [Required(ErrorMessage = "O título é obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O título deve ter entre 3 e 100 caracteres")]
    public string Titulo { get; set; } = string.Empty;

    [StringLength(200, ErrorMessage = "A descrição deve ter no máximo 200 caracteres")]
    public string Descricao { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "O ID da categoria deve ser maior que zero")]
    public int CategoriaId { get; set; }
}
