using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Interfaces;
using TaskManager.Domain;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefasController : ControllerBase
{
    private readonly ITarefaService _service;

    public TarefasController(ITarefaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var tarefaLista = await _service.Listar();
        return Ok(tarefaLista);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tarefa>> Buscar(int id)
    {
        var tarefa = await _service.Buscar(id);
        if (tarefa == null)
            return NotFound();
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<ActionResult<Tarefa>> Criar([FromBody] Tarefa tarefa)
    {
        var tarefaCriada = await _service.Criar(tarefa);
        return CreatedAtAction(nameof(Listar), new { id = tarefaCriada.Id }, tarefaCriada);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Tarefa tarefa)
    {
        var tarefaExiste = await _service.Buscar(id);
        if (tarefaExiste == null)
            return NotFound();

        tarefaExiste.Titulo = tarefa.Titulo;
        tarefaExiste.Descricao = tarefa.Descricao;
        tarefaExiste.Concluida = tarefa.Concluida;
        tarefaExiste.CategoriaId = tarefa.CategoriaId;

        await _service.Atualizar(tarefaExiste);
        return Ok(tarefaExiste);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var tarefaExiste = await _service.Buscar(id);
        if (tarefaExiste == null)
            return NotFound();

        await _service.Deletar(id);
        return NoContent();
    }
}