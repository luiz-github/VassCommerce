using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models;

public class ClienteModel
{
    public ClienteModel(string fotoUrl, string cpf, DateTime dataNascimento)
    {
        Id = Guid.NewGuid();
        FotoUrl = fotoUrl;
        Cpf = cpf;
        DataNascimento = dataNascimento;
    }

    public Guid Id { get; init; }
    [MaxLength(100)]
    public string FotoUrl { get; set; }
    public DateTime DataNascimento { get; set; }
    [MaxLength(11)]
    public string Cpf { get; set; }
    public EnderecoModel? Endereco { get; set; }
}