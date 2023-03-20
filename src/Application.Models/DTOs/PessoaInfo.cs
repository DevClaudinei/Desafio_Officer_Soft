using DomainModels.Interfaces;
using System;

namespace Application.Models.DTOs
{
    public class PessoaInfo : IIdentificavel
    {
        public PessoaInfo() { }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Cep { get; set; }
        public DateTime DataDeCriacao { get; set; }
    }
}
