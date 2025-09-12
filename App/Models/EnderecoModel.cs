using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models;

public class EnderecoModel
{
    public EnderecoModel(string rua, int numero, string cep, string complemento, string telefone, string bairro, DateTime dataUltimaAtualizacao)
    {
        Rua = rua;
        Numero = numero;
        Cep = cep;
        Complemento = complemento;
        Telefone = telefone;
        Bairro = bairro;
        DataUltimaAtualizacao = dataUltimaAtualizacao;
        DataCadastro = DateTime.Now;
    }

    public int Id { get; init; }
    [MaxLength(100)]
    public string Rua { get; set; }
    public int Numero { get; set; }
    [MaxLength(8)]
    public string Cep { get; set; }
    [MaxLength(8)]
    public string Complemento { get; set; }
    [MaxLength(11)]
    public string Telefone { get; set; }
    [MaxLength(100)]
    public string Bairro { get; set; }
    public DateTime DataCadastro { get; init; }
    public DateTime DataUltimaAtualizacao { get; set; }
    public int CidadeId { get; set; }
    public CidadeModel Cidade { get; set; } = null!;
    public int ClienteId { get; set; }
    public ClienteModel Cliente { get; set; }
}