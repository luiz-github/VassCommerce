namespace Models;

public class EstadoModel
{
    public EstadoModel(string sigla, string nome)
    {
        Id = Guid.NewGuid();
        Sigla = sigla;
        Nome = nome;
    }

    public Guid Id { get; init; }
    public string Sigla { get; set; }
    public string Nome { get; set; }
    
    public ICollection<CidadeModel> Cidades { get; set; }
}