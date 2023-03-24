using Application.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppServices.Services.Interfaces
{
    public interface IPessoaAppService
    {
        Task<long> CadastraPessoa(CriaCadastro criaCadastro);
        Task<AtualizaCadastro> MostraPessoaPorId(long id);
        Task<PessoaInfo> BuscaPessoaPorId(long id);
        Task<IEnumerable<PessoaInfo>> MostraTodosCadastrados();
        void AtualizCadastro(long id, AtualizaCadastro atualizaCadastro);
        void ExcluiPessoa(long id);
        Task<PessoaInfo> BuscaPessoaPeloNome(string name);
        Task<PessoaInfo> BuscaPessoaPeloCpf(string cpf);
    }
}
