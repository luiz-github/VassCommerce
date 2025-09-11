using System.Text.Json.Serialization;

namespace Models;
public class CartaoModel
{
    public CartaoModel(TipoCartao tipo)
    {
        DataCriacao = DateTime.Now;
        Excluido = false;
        Tipo = tipo;
    }

    public int Id { get; init; }
    public DateTime DataCriacao { get; init; }
    public TipoCartao Tipo { get; set; }
    public int TitularId { get; set; }

    [JsonIgnore]
    public bool Excluido { get; set; }
    [JsonIgnore]
    public ClienteModel Titular { get; set; }
}

public enum TipoCartao
{
    Debito = 1,
    Credito = 2
}