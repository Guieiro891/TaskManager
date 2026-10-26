using TaskManager.Domain;

namespace TaskManager.Application.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> BuscarPorEmail(string email);
    Task<Usuario> Criar(Usuario usuario);
}