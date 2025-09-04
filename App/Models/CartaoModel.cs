namespace Models;

public class CartaoModel
{
    public CartaoModel(TipoCartao tipo)
    {
        Id = Guid.NewGuid();
        DataCriacao = DateTime.UtcNow;
        Excluido = false;
        Tipo = tipo;
    }

    public Guid Id { get; init; }
    public DateTime DataCriacao { get; init; }
    public bool Excluido { get; init; }
    public TipoCartao Tipo { get; set; }

    public Guid TitularId { get; set; }
    public ClienteModel Titular { get; set; }
}

public enum TipoCartao
{
    Debito = 1,
    Credito = 2
}