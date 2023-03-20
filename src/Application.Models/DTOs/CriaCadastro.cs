namespace Application.Models.DTOs
{
    public class CriaCadastro
    {
        public CriaCadastro() { }

        public CriaCadastro(
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
            Cpf = FormatCPF(cpf.Trim());
            Nome = nome;
            Cep = cep.Trim();
            Endereco = endereco;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Municipio = municipio;
            Uf = uf;
            Rg = rg;
        }

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
    }
}
