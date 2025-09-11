using System.Text.Json.Serialization;

namespace Models;

public class PedidoModel
{
    public PedidoModel(float valorTotal, PedidoStatus statusAtual)
    {
        DataCadastro = DateTime.Now;
        ValorTotal = valorTotal;
        StatusAtual = statusAtual;
    }
    public int Id { get; init; }
    public DateTime DataCadastro { get; init; }
    public float ValorTotal { get; set; }
    public PedidoStatus StatusAtual { get; set; }
    public int ClienteId { get; set; }
    [JsonIgnore]
    public ClienteModel Cliente { get; set; }
}

public enum PedidoStatus
{
    AGUARDANDO_PAGAMENTO = 1,
    SEPARANDO_ESTOQUE = 2,
    ENTREGUE_TRANSPORTADORA = 3,
    ENTREGUE_CLIENTE = 4
}