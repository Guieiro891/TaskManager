# 🗂️ TaskManager API

Uma API RESTful completa para gerenciamento de tarefas, construída com **C# e .NET 10**, seguindo os princípios da **Arquitetura em Camadas** (Clean Architecture) e as melhores práticas do mercado.

## 🚀 Tecnologias Utilizadas

- **C# / .NET 10**
- **ASP.NET Core Web API**
- **Entity Framework Core** (Code-First)
- **SQL Server**
- **JWT (JSON Web Tokens)** para autenticação
- **BCrypt.Net** para hash de senhas
- **xUnit & Moq** para Testes Unitários
- **Data Annotations** para validação de dados

## 🏗️ Arquitetura do Projeto

O projeto foi estruturado para separar as responsabilidades, facilitando a manutenção e os testes:

- **TaskManager.Domain**: O coração do projeto. Contém as entidades (`Tarefa`, `Categoria`, `Usuario`) e enums, sem dependência de frameworks.
- **TaskManager.Application**: Contém as regras de negócio (Services), as interfaces (Repositories), os DTOs (Data Transfer Objects) e os Mappers.
- **TaskManager.Infrastructure**: Responsável pelo acesso a dados (Entity Framework, `AppDbContext`, Repositórios) e integrações externas.
- **TaskManager.API**: A porta de entrada. Contém os Controllers, configurações de injeção de dependência e middlewares.
- **TaskManager.Tests**: Projeto dedicado aos testes unitários das regras de negócio.

## ⚙️ Funcionalidades

- [x] CRUD completo de Tarefas e Categorias.
- [x] Relacionamento 1:N (Uma categoria possui várias tarefas).
- [x] Cadastro de usuários com criptografia de senha (BCrypt).
- [x] Autenticação via JWT (Login).
- [x] Validação de dados de entrada com Data Annotations.
- [x] Tratamento global de exceções (Middleware).
- [x] Testes unitários para as regras de cadastro de usuário.

## 🔌 Principais Endpoints

| Método | Rota | Descrição | Autenticação |
|--------|------|-----------|--------------|
| POST | `/api/Auth/registrar` | Cadastra um novo usuário | Pública |
| POST | `/api/Auth/login` | Autentica e retorna o Token JWT | Pública |
| GET | `/api/Tarefas` | Lista todas as tarefas | Pública* |
| POST | `/api/Tarefas` | Cria uma nova tarefa | Pública* |
| GET | `/api/Categorias` | Lista todas as categorias | Pública* |

*(Nota: Os endpoints de Tarefas e Categorias estão abertos para facilitar os testes. Em produção, seriam protegidos com `[Authorize]`).*

## 🛠️ Como Rodar o Projeto

### Pré-requisitos
- .NET 10 SDK
- SQL Server (LocalDB ou Express)
- Visual Studio 2022 ou VS Code

### Passo a Passo

1. Clone o repositório:
```bash
git clone https://github.com/Guieiro891/TaskManager.git