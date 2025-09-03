public class EnderecoModel
{
    public EnderecoModel(string rua, int numero, string cep, string complemento, int telefone, string bairro, DateTime dataUltimaAtualizacao)
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
    public string Rua { get; set; }
    public int Numero { get; set; }
    public string Cep { get; set; }
    public string Complemento { get; set; }
    public int Telefone { get; set; }
    public string Bairro { get; set; }
    public DateTime DataCadastro { get; init; }
    public DateTime DataUltimaAtualizacao { get; set; }
}