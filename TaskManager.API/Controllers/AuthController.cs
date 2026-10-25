using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization.Metadata;
using TaskManager.Application.DTOs.Usuarios;
using TaskManager.Application.Interfaces;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var login = await _authService.Login(dto);
        if (login == null)
            return Unauthorized("Email ou Senha inválidos.");
        return Ok(new { token = login });

    }

    [HttpPost("gerar-hash")]
    public IActionResult GerarHash([FromBody] LoginDto dto)
    {
        var hash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);
        return Ok(new { hash });
    }
}