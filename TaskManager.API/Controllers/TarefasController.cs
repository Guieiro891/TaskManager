using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Interfaces;
using TaskManager.Application.DTOs.Tarefas;

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
    public async Task<ActionResult<TarefaDto>> Buscar(int id)
    {
        var tarefa = await _service.Buscar(id);
        if (tarefa == null)
            return NotFound();
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<ActionResult<TarefaDto>> Criar([FromBody] CriarTarefaDto dto)
    {
        var tarefaCriada = await _service.Criar(dto);
        return CreatedAtAction(nameof(Listar), new { id = tarefaCriada.Id }, tarefaCriada);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarTarefaDto dto)
    {
        var tarefaExiste = await _service.Buscar(id);
        if (tarefaExiste == null)
            return NotFound();

        await _service.Atualizar(id, dto);
        return NoContent();
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