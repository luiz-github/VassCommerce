using System.ComponentModel.DataAnnotations;
using Models;
namespace Dtos;

public class CartaoDto
{
    [Required(ErrorMessage = "Tipo do cartão é obrigatório")]
    [EnumDataType(typeof(TipoCartao), ErrorMessage = "Tipo de cartão inválido")]
    public TipoCartao Tipo { get; set; }
}
