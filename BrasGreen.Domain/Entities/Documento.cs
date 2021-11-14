namespace BrasGreen.Domain.Entities
{
    public class Documento
    {
        public int DocumentoID { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string CnpjRaiz { get; set; }
        public string RG { get; set; }
        public string InscricaoEstadual { get; set; }
    }
}