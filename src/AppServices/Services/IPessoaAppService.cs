using Application.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public interface IPessoaAppService
    {
        Task<long> CadastraPessoa(CriaCadastro criaCadastro);
        Task<AtualizaCadastro> MostraPessoaPorId(long id);
        Task<PessoaInfo> BuscaPessoaPorId(long id);
        Task<List<PessoaInfo>> MostraTodosCadastrados();
        void AtualizCadastro(long id, AtualizaCadastro atualizaCadastro);
        void ExcluiPessoa(long id);
    }
}
