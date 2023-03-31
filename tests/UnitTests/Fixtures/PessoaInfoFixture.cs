using Application.Models.DTOs;
using Bogus;
using Bogus.Extensions.Brazil;
using System.Collections.Generic;

namespace UnitTests.Fixtures
{
    public static class PessoaInfoFixture
    {
        public static PessoaInfo PessoaInfoFake()
        {
            var pessoaInfoFake = new Faker<PessoaInfo>()
                .RuleFor(x => x.Id, f => f.Random.Long(1, 10))
                .RuleFor(x => x.Nome, f => f.Person.FullName)
                .RuleFor(x => x.Cpf, f => f.Person.Cpf(true))
                .RuleFor(x => x.Rg, f => f.Random.String())
                .RuleFor(x => x.Cep, f => f.Person.Address.ZipCode)
                .RuleFor(x => x.DataDeCriacao, f => f.Date.Recent())
                .Generate();

            return pessoaInfoFake;
        }

        public static IEnumerable<PessoaInfo> PessoasInfoFakes(int quantidade)
        {
            var pessoasInfoFakes = new Faker<PessoaInfo>()
                .RuleFor(x => x.Id, f => f.Random.Long(1, 10))
                .RuleFor(x => x.Nome, f => f.Person.FullName)
                .RuleFor(x => x.Cpf, f => f.Person.Cpf(true))
                .RuleFor(x => x.Rg, f => f.Random.String())
                .RuleFor(x => x.Cep, f => f.Person.Address.ZipCode)
                .RuleFor(x => x.DataDeCriacao, f => f.Date.Recent())
                .Generate(quantidade);

            return pessoasInfoFakes;
        }
    }
}
