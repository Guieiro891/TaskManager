using TaskManager.Application.DTOs.Usuarios;
namespace TaskManager.Application.Interfaces;

public interface IAuthService
{
    Task<string?> Login(LoginDto dto);
}
