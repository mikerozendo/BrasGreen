using BrasGreen.Domain.Enums;

namespace BrasGreen.Domain.Entities
{
    public class Endereco
    {
        public int EnderecoID { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string PontoReferencia { get; set; }
        public EnumTipoEndereco EnumTipoEndereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string UF { get; set; }
    }
}
