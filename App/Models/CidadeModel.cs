using System.ComponentModel.DataAnnotations;

namespace Models;
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
    public ICollection<EnderecoModel> Enderecos { get; } =
        new List<EnderecoModel>();
}