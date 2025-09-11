using System.ComponentModel.DataAnnotations;

namespace Models;

public class ClienteModel
{
    public ClienteModel(string fotoUrl, string cpf, DateTime dataNascimento)
    {
        FotoUrl = fotoUrl;
        Cpf = cpf;
        DataNascimento = dataNascimento;
    }

    public int Id { get; init; }
    [MaxLength(100)]
    public string FotoUrl { get; set; }
    public DateTime DataNascimento { get; set; }
    [MaxLength(11)]
    public string Cpf { get; set; }
    public EnderecoModel? Endereco { get; set; }
    public ICollection<CartaoModel> FormasDePagamento { get; set; } =
        new List<CartaoModel>();
    public ICollection<PedidoModel> Pedidos { get; set; } =
        new List<PedidoModel>();
}