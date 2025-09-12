using System.ComponentModel.DataAnnotations;

namespace Dtos;

public class UpdateProdutoDto
{
    [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
    public string? Nome { get; set; }

    [StringLength(500, ErrorMessage = "A descrição não pode ter mais de 500 caracteres.")]
    public string? Descricao { get; set; }

    [Url(ErrorMessage = "A fotoUrl deve ser uma URL válida.")]
    public string? FotoUrl { get; set; }

    [Range(0, float.MaxValue, ErrorMessage = "O valor unitário deve ser maior ou igual a zero.")]
    public float? ValorUnitario { get; set; }

    public List<int>? CategoriasId { get; set; }
}
