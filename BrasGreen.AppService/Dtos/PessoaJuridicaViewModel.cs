namespace BrasGreen.AppService.Dtos
{
    public class PessoaJuridicaViewModel
    {
        public int PessoaJuridicaID { get; set; }
        public string RazaoSocial { get; set; }
        public int DocumentoID { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public int EnderecoID { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string PontoReferencia { get; set; }
        public int EnumTipoEndereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string UF { get; set; }
        public int PessoaResponsavelID { get; set; }
        public string ResponsavelNome { get; set; }
        public string ResponsavelSobrenome { get; set; }
    }
}
