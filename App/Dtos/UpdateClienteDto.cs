using System.ComponentModel.DataAnnotations;
using Models;

namespace Dtos;
public class UpdateClienteDto
{
    public string? FotoUrl { get; set; }

    [StringLength(8, MinimumLength = 8, ErrorMessage = "Tamanho de string incorreto")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "Data de nascimento deve conter apenas números")]
    public DateTime? DataNascimento { get; set; }
}