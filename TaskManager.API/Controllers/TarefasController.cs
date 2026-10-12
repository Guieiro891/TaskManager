using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain;
using TaskManager.Infrastructure.Data;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TarefasController : ControllerBase
{
    private readonly AppDbContext _context;
    public TarefasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var tarefaLista = await _context.Tarefas.Include(t => t.Categoria).ToListAsync();
        return Ok(tarefaLista);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tarefa>> Buscar(int id)
    {
        var buscaLista = await _context.Tarefas.FirstOrDefaultAsync(b => b.Id == id);
        if (buscaLista == null)
            return NotFound();
        return Ok(buscaLista);
    }

    [HttpPost]
    public async Task<ActionResult<Tarefa>> Criar([FromBody] Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Listar), new {id = tarefa.Id}, tarefa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Tarefa tarefa)
    {
        var tarefaAtualizada = await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
        if (tarefaAtualizada == null)
            return NotFound();

        tarefaAtualizada.Titulo = tarefa.Titulo;
        tarefaAtualizada.CategoriaId = tarefa.CategoriaId;
        tarefaAtualizada.Concluida = tarefa.Concluida;
        tarefaAtualizada.Descricao = tarefa.Descricao;

        await _context.SaveChangesAsync();
        return Ok(tarefaAtualizada);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar (int id)
    {
        var tarefaDeletada = await _context.Tarefas.FirstOrDefaultAsync(d => d.Id == id);
        if (tarefaDeletada == null)
            return NotFound();
        _context.Tarefas.Remove(tarefaDeletada);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
