using Models;
using System.ComponentModel.DataAnnotations;
namespace Dtos;

public class CreateEnderecoDto
{
    [Required(ErrorMessage = "Rua é obrigatório")]
    [StringLength(100, ErrorMessage = "Limite de caractéres excedido")]
    public string Rua { get; set; }

    [Required(ErrorMessage = "Numero é obrigatório")]
    public int Numero { get; set; }

    [Required(ErrorMessage = "CEP é obrigatório")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "Limites de caracter não atendidos")]
    [RegularExpression(@"^\d{8}$", ErrorMessage = "CEP deve conter apenas números")]
    public string Cep { get; set; }

    [Required(ErrorMessage = "Complemento é obrigatório")]
    [StringLength(10, ErrorMessage = "Limite de caractéres excedido")]
    public string Complemento { get; set; }

    [Required(ErrorMessage = "Telefone é obrigatório")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "Limites de caracter não atendidos")]
    [RegularExpression(@"^\d{8}$", ErrorMessage = "Telefone deve conter apenas números")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "Bairro é obrigatório")]
    [StringLength(100, ErrorMessage = "Limite de caractéres excedido")]
    public string Bairro { get; set; }

    [Required(ErrorMessage = "CidadeId é obrigatório")]
    public int CidadeId { get; set; }
}