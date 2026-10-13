using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces;
using TaskManager.Domain;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly AppDbContext _context;
    public TarefaRepository (AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Tarefa>> Listar()
    {
        return await _context.Tarefas
            .Include(t => t.Categoria)
            .ToListAsync();
    }

    public async Task<Tarefa?> Buscar(int id)
    {
        return await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Tarefa> Criar (Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();
        return tarefa;
    }

    public async Task Atualizar(Tarefa tarefa)
    {
        _context.Tarefas.Update(tarefa);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(int id)
    {
        var tarefa = await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
        if (tarefa == null)
            return;
        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();
    }
}
