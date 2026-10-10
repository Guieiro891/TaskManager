namespace TaskManager.Domain;
using System;

public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool Concluida { get; set; }
    public DateTime DataCriacao { get; set; }
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
}