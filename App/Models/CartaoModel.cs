namespace Models;

public class CartaoModel
{
    public CartaoModel(TipoCartao tipo)
    {
        DataCriacao = DateTime.UtcNow;
        Excluido = false;
        Tipo = tipo;
    }

    public int Id { get; init; }
    public DateTime DataCriacao { get; init; }
    public bool Excluido { get; init; }
    public TipoCartao Tipo { get; set; }
}

public enum TipoCartao
{
    Debito = 1,
    Credito = 2
}