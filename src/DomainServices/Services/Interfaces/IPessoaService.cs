using DomainModels.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainServices.Services.Interfaces
{
    public interface IPessoaService
    {
        Task<long> CadastraPessoa(Pessoa pessoa);
        IEnumerable<Pessoa> MostraTodosCadastrados();
        void AtualizCadastro(long id, Pessoa pessoa);
        void ExcluiPessoa(long id);
        Task<Pessoa> BuscaPessoaPorId(long id);
        Task<Pessoa> BuscaPessoaPeloNome(string name);
        Task<Pessoa> BuscaPessoaPeloCpf(string cpf);
    }
}
