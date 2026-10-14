using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces;
using TaskManager.Domain;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _context;
    public CategoriaRepository (AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Categoria>> Listar()
    {
        return await _context.Categorias.ToListAsync();
    }

    public async Task<Categoria?> Buscar(int id)
    {
        return await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Categoria> Criar (Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }

    public async Task Atualizar (Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar (int id)
    {
        var deletar = await _context.Categorias.FirstOrDefaultAsync(d => d.Id == id);
        if (deletar == null)
            return;

        _context.Categorias.Remove(deletar);
        await  _context.SaveChangesAsync();
            
    }
}
