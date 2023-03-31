using Bogus;
using Bogus.Extensions.Brazil;
using DomainModels.Entities;
using System.Collections.Generic;

namespace UnitTests.Fixtures
{
    public static class PessoaFixture
    {
        public static Pessoa PessoaFake()
        {
            var pessoaFake = new Faker<Pessoa>("pt_BR")
                .RuleFor(x => x.Id, f => f.Random.Long(1, 10))
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
                .RuleFor(x => x.DataDeCriacao, f => f.Date.Recent())
                .Generate();

            return pessoaFake;
        }

        public static IEnumerable<Pessoa> PessoasFakes(int quantidade)
        {
            var pessoasFakes = new Faker<Pessoa>("pt_BR")
                .RuleFor(x => x.Id, f => f.Random.Long(1, 10))
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
                .RuleFor(x => x.DataDeCriacao, f => f.Date.Recent())
                .Generate(quantidade);

            return pessoasFakes;
        }
    }
}