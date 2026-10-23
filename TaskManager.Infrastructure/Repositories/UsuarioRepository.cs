using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces;
using TaskManager.Domain;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;
    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Usuario?> BuscarPorEmail(string email)
    {
        return await _context.Usuarios.FirtOrDefaultAsync(u => u.Email == email);
    }
}
