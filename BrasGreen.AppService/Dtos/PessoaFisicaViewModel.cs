namespace BrasGreen.AppService.Dtos
{
    class PessoaFisicaViewModel
    {
        public int PessoaFisicaID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string DataNascimento { get; set; }
        public int DocumentoID { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public int EnumTipoPessoa { get; set; }
        public int EnderecoID { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string PontoReferencia { get; set; }
        public int EnumTipoEndereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string UF { get; set; }
    }
}
