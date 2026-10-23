using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Application.DTOs.Usuarios;

public class LoginDto
{
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
