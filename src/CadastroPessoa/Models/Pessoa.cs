using System;

namespace CadastroPessoa.Models
{
    public class Pessoa
    {
        public long Id {get; set;}
        public string Cpf {get; set;}
        public string Nome {get; set;}
        public string Cep {get; set;}
        public string Endereco {get; set;}
        public int Numero {get; set;}
        public string Bairro {get; set;}
        public string Complemento {get; set;}
        public string Municipio {get; set;}
        public string Uf {get; set;}
        public string Rg {get; set;}
        public DateTime DataDeCriacao {get; set;} = DateTime.Now;
    }
}