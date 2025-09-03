namespace Models;

public class ClienteModel
{
    public ClienteModel(string fotoUrl, DateTime dataNascimento)
    {
        Id = Guid.NewGuid();
        FotoUrl = fotoUrl;
        DataNascimento = dataNascimento;
    }

    public Guid Id { get; init; }
    public string FotoUrl { get; set; }
    public DateTime DataNascimento { get; set; }

    public EnderecoModel Endereco { get; set; }
}