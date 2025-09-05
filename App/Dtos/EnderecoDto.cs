using Models;

namespace Dtos;

public class CreateEnderecoDto
{
    public string Rua { get; set; }
    public int Numero { get; set; }
    public string Cep { get; set; }
    public string Complemento { get; set; }
    public string Telefone { get; set; }
    public string Bairro { get; set; }
    public int CidadeId { get; set; }
}

public class GetEnderecoByIdDto
{
    public int Id { get; set; }
}