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
        DataCadastro = DateTime.UtcNow;
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

    [JsonIgnore]
    public int ClienteId { get; set; }
    [JsonIgnore]
    public ClienteModel Cliente { get; set; }
}

public class CidadeModel
{
    public CidadeModel(string nome)
    {
        Nome = nome;
    }
    public int Id { get; init; }
    public string Nome { get; set; }

    public int EstadoId { get; set; }
    public EstadoModel Estado { get; set; }

    [JsonIgnore]
    public ICollection<EnderecoModel> Enderecos { get; } =
        new List<EnderecoModel>();
}

public class EstadoModel
{
    public EstadoModel(string sigla, string nome)
    {
        Sigla = sigla;
        Nome = nome;
    }

    public int Id { get; init; }
    public string Sigla { get; set; }
    public string Nome { get; set; }

    [JsonIgnore]
    public ICollection<CidadeModel> Cidades { get; } =
        new List<CidadeModel>();
}