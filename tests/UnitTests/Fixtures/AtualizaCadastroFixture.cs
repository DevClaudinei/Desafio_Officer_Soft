using Application.Models.DTOs;
using Bogus;
using Bogus.Extensions.Brazil;

namespace UnitTests.Fixtures
{
    public static class AtualizaCadastroFixture
    {
        public static AtualizaCadastro AtualizaCadastroFake()
        {
            var atualizaCadastroFake = new Faker<AtualizaCadastro>("pt_BR")
                .CustomInstantiator(f => new AtualizaCadastro(
                    cpf: f.Person.Cpf(true),
                    nome: f.Person.FullName,
                    cep: f.Address.ZipCode(),
                    endereco: f.Address.StreetName(),
                    numero: f.Random.Int(),
                    bairro: f.Random.String(),
                    complemento: f.Random.String(),
                    municipio: f.Person.Address.City,
                    uf: f.Random.String(),
                    rg: f.Random.String()
                )).Generate();

            return atualizaCadastroFake;
        }
    }
}
