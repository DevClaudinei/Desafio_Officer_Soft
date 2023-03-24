using Application.Models.DTOs;
using Bogus;
using Bogus.Extensions.Brazil;

namespace UnitTests.Fixtures
{
    public static class AtualizaCadastroFixture
    {
        public static AtualizaCadastro AtualizaCadastroFake()
        {
            var atualizaCadastroFake = new Faker<AtualizaCadastro>()
                .RuleFor(x => x.Cpf, f => f.Person.Cpf(true))
                .RuleFor(x => x.Nome, f => f.Person.FullName)
                .RuleFor(x => x.Cep, f => f.Person.Address.ZipCode)
                .RuleFor(x => x.Endereco, f => f.Person.Address.Street)
                .RuleFor(x => x.Numero, f => f.Random.Int())
                .RuleFor(x => x.Bairro, f => f.Random.String())
                .RuleFor(x => x.Complemento, f => f.Random.String())
                .RuleFor(x => x.Municipio, f => f.Person.Address.City)
                .RuleFor(x => x.Uf, f => f.Random.String())
                .RuleFor(x => x.Rg, f => f.Random.String())
                .Generate();

            return atualizaCadastroFake;
        }
    }
}
