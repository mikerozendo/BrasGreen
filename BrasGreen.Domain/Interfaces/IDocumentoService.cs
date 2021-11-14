namespace BrasGreen.Domain.Interfaces
{
    public interface IDocumentoService
    {
        bool ValidarRG(string rg);
        string FormatarValor(string valorFormatacao);
        int CalcularDv(int soma, int subtraendo);
        bool ValidarCPF(string cpf);
    }
}
