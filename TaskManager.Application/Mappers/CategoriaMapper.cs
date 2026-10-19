using TaskManager.Application.DTOs.Categorias;
using TaskManager.Domain;
namespace TaskManager.Application.DTOs.Mappers;

public static class CategoriaMapper
{
    public static CategoriaDto ToDto(Categoria categoria)
    {
        return new CategoriaDto
        {
            Id = categoria.Id,
            Nome = categoria.Nome
        };
    }

    public static Categoria ToEntity(CriarCategoriaDto dto)
    {
        return new Categoria
        {
            Nome = dto.Nome
        }; 
    }

    public static Categoria ToEntity(AtualizarCategoriaDto dto)
    {
        return new Categoria
        {
            Nome = dto.Nome
        };
    }
}
