using System.ComponentModel.DataAnnotations;

namespace Models;

public class CategoriaModel
{
    public CategoriaModel(string imagemSimboloUrl, string nome, string descricao)
    {
        ImagemSimboloUrl = imagemSimboloUrl;
        Nome = nome;
        Descricao = descricao;
    }
    public int Id { get; init; }
    [MaxLength(100)]
    public string ImagemSimboloUrl { get; set; }
    [MaxLength(100)]
    public string Nome { get; set; }
    [MaxLength(100)]
    public string Descricao { get; set; }
}