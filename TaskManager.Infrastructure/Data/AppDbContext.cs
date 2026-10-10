using Microsoft.EntityFrameworkCore;
using TaskManager.Domain;

namespace TaskManager.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
}