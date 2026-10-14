using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces;
using TaskManager.Domain;


namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _service;
    public CategoriasController(ICategoriaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var categorias = await _service.Listar();
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Categoria>> Buscar (int id)
    {
        using Microsoft.AspNetCore.Mvc;
        using TaskManager.Application.Interfaces;
        using TaskManager.Domain;


namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _service;
    public CategoriasController(ICategoriaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var categorias = await _service.Listar();
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Categoria>> Buscar(int id)
    {
        var catergoriaBuscar = await _service.Buscar( id);
        if (catergoriaBuscar == null)
            return NotFound();

        return Ok(catergoriaBuscar);
    }

    [HttpPost]
    public async Task<ActionResult<Categoria>> Criar([FromBody] Categoria categoria)
    {
        var categoriaCriada = await _service.Criar(categoria);
        return CreatedAtAction(nameof(Listar), new { id = categoria.Id }, categoria);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Categoria categoria)
    {
        var categoriaExiste = await _service.Buscar(id);
        if (categoriaExiste == null)
            return NotFound();

        categoriaExiste.Nome = categoria.Nome;

        await _service.Atualizar(categoriaExiste);
        return Ok(categoriaExiste);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var categoriaExiste = await _service.Buscar(id);
        if (categoriaExiste == null)
            return NotFound();

        await _service.Deletar(id);
        return NoContent();
    }
}
   
