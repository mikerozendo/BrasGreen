namespace BrasGreen.Domain.Interfaces
{
    public interface IDocumentoService
    {
        bool ValidarRG(string rg);
        string FormatarRG(string rg);
    }
}
