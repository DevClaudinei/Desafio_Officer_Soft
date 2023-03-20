using Application.Models.DTOs;
using AppServices.Services.Interfaces;
using AutoMapper;
using DomainModels.Entities;
using DomainServices.Exceptions;
using DomainServices.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public class PessoaAppService : IPessoaAppService
    {
        private readonly IPessoaService _customerService;
        private readonly IMapper _mapper;

        public PessoaAppService(IPessoaService customerService, IMapper mapper)
        {
            _customerService = customerService ?? throw new System.ArgumentNullException(nameof(customerService));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public async Task<long> CadastraPessoa(CriaCadastro criaCadastro)
        {
            var pessoa = _mapper.Map<Pessoa>(criaCadastro);

            return await _customerService.CadastraPessoa(pessoa);
        }

        public async Task<List<PessoaInfo>> MostraTodosCadastrados()
        {
            var pessoasEncontradas = await _customerService.MostraTodosCadastrados();

            return _mapper.Map<List<PessoaInfo>>(pessoasEncontradas);
        }

        public async Task<PessoaInfo> BuscaPessoaPeloCpf(string cpf)
        {
            var pessoaEncontrada = await _customerService.BuscaPessoaPeloCpf(cpf)
                ?? throw new NotFoundException($"Pessoa com o Cpf: {cpf} não localizada.");

            return _mapper.Map<PessoaInfo>(pessoaEncontrada);
        }

        public async Task<PessoaInfo> BuscaPessoaPorId(long id)
        {
            var pessoaEncontrada = await _customerService.BuscaPessoaPorId(id) 
                ?? throw new NotFoundException($"Pessoa com o Id: {id} não localizada.");

            return _mapper.Map<PessoaInfo>(pessoaEncontrada);
        }

        public async Task<PessoaInfo> BuscaPessoaPeloNome(string nome)
        {
            var pessoaEncontrada = await _customerService.BuscaPessoaPeloNome(nome)
                ?? throw new NotFoundException($"Pessoa com o nome: {nome} não localizada.");

            return _mapper.Map<PessoaInfo>(pessoaEncontrada);
        }

        public async Task<AtualizaCadastro> MostraPessoaPorId(long id)
        {
            var pessoaEncontrada = await _customerService.MostraPessoaPorId(id);

            return _mapper.Map<AtualizaCadastro>(pessoaEncontrada);
        }

        public void AtualizCadastro(long id, AtualizaCadastro atualizaCadastro)
        {
            var pessoa = _mapper.Map<Pessoa>(atualizaCadastro);
            pessoa.Id = id;

            _customerService.AtualizCadastro(pessoa);
        }

        public void ExcluiPessoa(long id)
        {
            _customerService.ExcluiPessoa(id);
        }
    }
}
