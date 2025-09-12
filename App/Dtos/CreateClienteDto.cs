using System.ComponentModel.DataAnnotations;

namespace Dtos;

public class CreateClienteDto
{    
    public string FotoUrl { get; set; }

    [Required(ErrorMessage = "CPF é obrigatório")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "Tamanho de string incorreto")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter apenas números")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "Data de nascimento é obrigatório")]
    public DateTime DataNascimento { get; set; }
}