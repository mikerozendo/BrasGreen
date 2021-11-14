namespace BrasGreen.Domain.Interfaces
{
    public interface IDocumentoService
    {
        bool ValidarRG(string rg);
        string FormatarValor(string valorFormatacao);
        bool ValidarCPF(string cpf);
        bool ValidarCnpj(string cnpj);
        string FormatarCnpj(string cnpj);
    }
}
