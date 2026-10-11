using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain;
using TaskManager.Infrastructure.Data;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CategoriasController : ControllerBase
{
    private readonly AppDbContext _context;
    public CategoriasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var catergorias = await _context.Categorias.ToListAsync();
        return Ok(catergorias);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Categoria>> Buscar (int id)
    {
        var catergoriaBuscar = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        if (catergoriaBuscar == null)
            return NotFound();
       
        return Ok(catergoriaBuscar);
    }

    [HttpPost]
    public async Task<ActionResult<Categoria>> Criar([FromBody] Categoria categoria)
    {
        
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Listar), new { id = categoria.Id }, categoria);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Categoria categoria)
    {
        var categoriaExiste = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        if (categoriaExiste == null)
            return NotFound();

        
        categoriaExiste.Nome = categoria.Nome;

        await _context.SaveChangesAsync();
        return Ok(categoriaExiste);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar (int id)
    {
        var categoriaDeletar = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        if (categoriaDeletar == null)
            return NotFound();

        _context.Categorias.Remove(categoriaDeletar);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}