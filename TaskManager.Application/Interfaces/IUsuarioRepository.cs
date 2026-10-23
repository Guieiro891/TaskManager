using TaskManager.Domain;

namespace TaskManager.Application.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> BuscarPorEmail(string email);
}
