using BrasGreen.Domain.Enums;
using System;
using System.Collections.Generic;

namespace BrasGreen.Domain.Entities
{
    public class PessoaFisica
    {
        public int PessoaFisicaID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Documento Documentacao { get; set; }
        public EnumTipoPessoa EnumTipoPessoa { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }
    }
}
