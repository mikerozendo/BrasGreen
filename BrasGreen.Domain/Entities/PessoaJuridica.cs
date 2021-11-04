using System.Collections.Generic;

namespace BrasGreen.Domain.Entities
{
    public class PessoaJuridica
    {
        public int PessoaJuridicaID { get; set; }
        public string RazaoSocial { get; set; }
        public Documento Documento { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }
        public PessoaFisica PessoaResponsavel { get; set; }
    }
}
