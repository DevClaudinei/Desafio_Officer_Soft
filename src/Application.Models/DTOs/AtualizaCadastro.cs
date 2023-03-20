using DomainModels.Interfaces;
using System;

namespace Application.Models.DTOs
{
    public class AtualizaCadastro : IIdentificavel, ICriavel
    {
        public AtualizaCadastro() { }

        public AtualizaCadastro
        (
            string cpf,
            string nome,
            string cep,
            string endereco,
            int numero,
            string bairro,
            string complemento,
            string municipio,
            string uf,
            string rg
        )
        {
            Cpf = cpf;
            Nome = nome;
            Cep = cep;
            Endereco = endereco;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Municipio = municipio;
            Uf = uf;
            Rg = rg;
        }

        public long Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
        public string Rg { get; set; }
        public DateTime DataDeCriacao { get; set; }
    }
}
