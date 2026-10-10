namespace TaskManager.Domain;
using System;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public List<Tarefa> Tarefas = new List<Tarefa>();
}