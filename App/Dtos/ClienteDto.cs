using System.ComponentModel.DataAnnotations;

namespace Dtos;

public class CreateClienteDto
{    
    public string FotoUrl { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
}

public class UpdateClienteDto
{    
    public string? FotoUrl { get; set; }
    public DateTime? DataNascimento { get; set; }
}