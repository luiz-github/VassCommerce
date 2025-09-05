using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models;
public class EnderecoModel
{
    public EnderecoModel(string rua, int numero, string cep, string complemento, string telefone, string bairro, DateTime dataUltimaAtualizacao)
    {
        Id = Guid.NewGuid();
        Rua = rua;
        Numero = numero;
        Cep = cep;
        Complemento = complemento;
        Telefone = telefone;
        Bairro = bairro;
        DataUltimaAtualizacao = dataUltimaAtualizacao;
        DataCadastro = DateTime.UtcNow;
    }
    public Guid Id { get; init; }
    [MaxLength(100)]
    public string Rua { get; set; }
    public int Numero { get; set; }
    [MaxLength(9)]
    public string Cep { get; set; }
    [MaxLength(8)]
    public string Complemento { get; set; }
    [MaxLength(14)]
    public string Telefone { get; set; }
    [MaxLength(100)]
    public string Bairro { get; set; }
    public DateTime DataCadastro { get; init; }
    public DateTime DataUltimaAtualizacao { get; set; }
    public Guid ClienteId { get; set; }
    [JsonIgnore]
    public ClienteModel Cliente { get; set; }
}