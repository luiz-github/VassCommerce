using System.ComponentModel.DataAnnotations;

namespace Models;

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
    public ICollection<CidadeModel> Cidades { get; } =
        new List<CidadeModel>();
}