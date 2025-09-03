namespace Dtos.ClienteDto;

public class CreateClienteDto
{
    public CreateClienteDto(string fotoUrl, DateTime dataNascimento)
    {
        FotoUrl = fotoUrl;
        DataNascimento = dataNascimento;
    }
    
    public string FotoUrl { get; set; }
    public DateTime DataNascimento { get; set; }
}