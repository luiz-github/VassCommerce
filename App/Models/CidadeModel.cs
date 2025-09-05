namespace Models;

public class CidadeModel
{
    public CidadeModel(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
    }

    public Guid Id { get; init; }
    public string Nome { get; set; }
}