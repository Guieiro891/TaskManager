using TaskManager.Application.DTOs.Usuarios;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Services;
using TaskManager.Domain;
using Moq;
using Xunit;
using Microsoft.Extensions.Configuration;


namespace TaskManager.Tests;

public class AuthServiceTests
{
    [Fact]
    public async Task Registrar_EmaislJaExistente_DeveRetornarFalse()
    {
        // arrange Preparação
        var repositoryMock = new Mock<IUsuarioRepository>();
        var configurationMock = new Mock<IConfiguration>();

        var usuarioExistente = new Usuario { Nome = "Teste", Email = "teste@email.com" };
        repositoryMock.Setup(r => r.BuscarPorEmail("teste@email.com"))
                      .ReturnsAsync(usuarioExistente);

        var service = new AuthService(repositoryMock.Object, configurationMock.Object);
        var dto = new RegisterDto { Nome = "Novo", Email = "teste@email.com", Senha = "123456" };

        //Act está agindo
        var resultado = await service.Registrar(dto);

        //Assert verificação
        Assert.False(resultado);
    }

    [Fact]
    public async Task Registrar_EmailNovo_DeveRetornarTrue()
    {
        //Arrange preparação
        var repositoryMock = new Mock<IUsuarioRepository>();
        var configurationMock = new Mock<IConfiguration>();

        //Simulação
        repositoryMock.Setup(r => r.BuscarPorEmail("novo@email.com"))
                      .ReturnsAsync((Usuario?)null);

        var service = new AuthService(repositoryMock.Object, configurationMock.Object);
        var dto = new RegisterDto { Nome = "Novo", Email = "novo@email.com", Senha = "123456" };

        //Act o teste começa a agir
        var resultado = await service.Registrar(dto);

        //Assert verificação 
        Assert.True(resultado); //Espera que o resultado seha verdadeiro ( cadastro com sucesso).
    }
}
