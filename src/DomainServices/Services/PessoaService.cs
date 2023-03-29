using DomainModels.Entities;
using DomainServices.Exceptions;
using DomainServices.Services.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainServices.Services
{
    public class PessoaService : BaseService, IPessoaService
    {
        public PessoaService(
            IUnitOfWork<DataContext> unitOfWork,
            IRepositoryFactory<DataContext> repositoryFactory
        ) : base(unitOfWork, repositoryFactory) { }

        public async Task<long> CadastraPessoa(Pessoa pessoa)
        {
            var unitOfWork = UnitOfWork.Repository<Pessoa>();

            pessoa.Cpf = FormataCpf(pessoa.Cpf);
            VerificaSePessoaJaExiste(pessoa);

            var cadastro = unitOfWork.Add(pessoa);
            await UnitOfWork.SaveChangesAsync();

            return cadastro.Id;
        }

        private void VerificaSePessoaJaExiste(Pessoa pessoa)
        {
            var repository = RepositoryFactory.Repository<Pessoa>();
            var pessoaJaExiste = repository.Any(x => x.Cpf.Equals(pessoa.Cpf));

            if (pessoaJaExiste)
                throw new BadRequestException($"Pessoa com o Cpf: {pessoa.Cpf} já esta cadastrada.");
        }

        private static string FormataCpf(string cpf)
        {
            if (cpf.Length == 11)
                return cpf.Substring(0, 3) + "." + cpf.Substring(3, 3) + "." + cpf.Substring(6, 3) + "-" + cpf.Substring(9, 2);

            return cpf;
        }

        public IEnumerable<Pessoa> MostraTodosCadastrados()
        {
            var repository = RepositoryFactory.Repository<Pessoa>();
            var pessoasCadastradas = repository.MultipleResultQuery();

            return repository.Search(pessoasCadastradas);
        }

        public async Task<Pessoa> BuscaPessoaPeloCpf(string cpf)
        {
            var repository = RepositoryFactory.Repository<Pessoa>();

            cpf = FormataCpf(cpf);

            var pessoaEncontrada = repository.SingleResultQuery()
                .AndFilter(x => x.Cpf.Equals(cpf));

            return await repository.SingleOrDefaultAsync(pessoaEncontrada);
        }

        public async Task<Pessoa> BuscaPessoaPorId(long id)
        {
            var repository = RepositoryFactory.Repository<Pessoa>();

            var pessoaEncontrada = repository.SingleResultQuery()
                .AndFilter(x => x.Id.Equals(id));

            return await repository.SingleOrDefaultAsync(pessoaEncontrada);
        }

        public async Task<IEnumerable<Pessoa>> BuscaPessoaPeloNome(string name)
        {
            var repository = RepositoryFactory.Repository<Pessoa>();

            var pessoaEncontrada = repository.MultipleResultQuery()
                .AndFilter(x => x.Nome.Contains(name));

            return await repository.SearchAsync(pessoaEncontrada);
        }

        public void AtualizCadastro(long id, Pessoa pessoa)
        {
            var unitOfWork = UnitOfWork.Repository<Pessoa>();

            var pessoaParaAtualizacao = PessoaExiste(id).Result;

            pessoa.Cpf = FormataCpf(pessoa.Cpf);
            pessoa.DataDeCriacao = pessoaParaAtualizacao.DataDeCriacao;

            unitOfWork.Update(pessoa);
            UnitOfWork.SaveChanges();
        }

        private Task<Pessoa> PessoaExiste(long id)
        {
            var pessoaEncontrada = BuscaPessoaPorId(id);

            if (pessoaEncontrada.Result is null) 
                throw new NotFoundException($"Pessoa com o Id: {id} não localizada.");

            return pessoaEncontrada;
        }

        public void ExcluiPessoa(long id)
        {
            var unitOfWork = UnitOfWork.Repository<Pessoa>();

            var pessoaParaExclusao = PessoaExiste(id).Result;

            unitOfWork.Remove(pessoaParaExclusao);
            UnitOfWork.SaveChanges();
        }
    }
}
