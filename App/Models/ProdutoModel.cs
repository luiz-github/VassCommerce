using System.Text.Json.Serialization;

namespace Models;

public class ProdutoModel
{
    public ProdutoModel()
    {
        DataCadastro = DateTime.Now;
    }

    public int Id { get; init; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string FotoUrl { get; set; }
    public DateTime DataCadastro { get; init; }
    public DateTime DataUltimaAtualizacao { get; set; }
    public float ValorUnitario { get; set; }
    [JsonIgnore]
    public ICollection<CategoriaModel> Categorias { get; set; } = null!;
}