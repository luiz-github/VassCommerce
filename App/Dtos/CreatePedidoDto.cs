using System.ComponentModel.DataAnnotations;
using Models;

namespace Dtos;
public class CreatePedidoDto
{
    [Required(ErrorMessage = "Valor Total é obrigatório")]
    public float ValorTotal { get; set; }
    [Required(ErrorMessage = "Status Atual é obrigatório")]
    [EnumDataType(typeof(PedidoStatus), ErrorMessage = "Status inválido")]
    public PedidoStatus StatusAtual { get; set; }
}