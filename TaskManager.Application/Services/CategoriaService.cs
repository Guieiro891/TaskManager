using TaskManager.Application.DTOs.Categorias;
using TaskManager.Application.DTOs.Mappers;
using TaskManager.Application.Interfaces;


namespace TaskManager.Application.Services;
public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _repository;
    public CategoriaService (ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CategoriaDto>> Listar()
    {
        var categorias =  await _repository.Listar();
        return categorias.Select(c => CategoriaMapper.ToDto(c)).ToList();
    }

    public async Task<CategoriaDto?> Buscar(int id)
    {
        var categoria = await _repository.Buscar(id);
        return categoria == null ? null : CategoriaMapper.ToDto(categoria);
    }

    public async Task<CategoriaDto> Criar(CriarCategoriaDto dto)
    {
        var categoria = CategoriaMapper.ToEntity(dto);
        var categoriaCriada = await _repository.Criar(categoria);
        return CategoriaMapper.ToDto(categoriaCriada);
    }

    public async Task Atualizar(int id, AtualizarCategoriaDto dto)
    {
        var categoria = await _repository.Buscar(id);
        if (categoria == null) return;

        categoria.Nome = dto.Nome;
        await _repository.Atualizar(categoria);

    }

    public async Task Deletar(int id)
    {
        await _repository.Deletar(id);
    }
}

