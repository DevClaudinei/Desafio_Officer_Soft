using DomainModels.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainServices.Services.Interfaces
{
    public interface IPessoaService
    {
        Task<long> CadastraPessoa(Pessoa pessoa);
        Task<Pessoa> MostraPessoaPorId(long id);
        Task<List<Pessoa>> MostraTodosCadastrados();
        void AtualizCadastro(Pessoa pessoa);
        void ExcluiPessoa(long id);
        Task<Pessoa> BuscaPessoaPorId(long id);
    }
}
