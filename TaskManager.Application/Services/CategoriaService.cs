using TaskManager.Application.Interfaces;
using TaskManager.Domain;

namespace TaskManager.Application.Services;
public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _repository;
    public CategoriaService (ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Categoria>> Listar()
    {
        return await _repository.Listar();
    }

    public async Task<Categoria?> Buscar(int id)
    {
        return await _repository.Buscar(id);
    }

    public async Task<Categoria> Criar(Categoria categoria)
    {
        return await _repository.Criar(categoria);
    }

    public async Task Atualizar(Categoria categoria)
    {
        await _repository.Atualizar(categoria);
    }

    public async Task Deletar(int id)
    {
        await _repository.Deletar(id);
    }
}

