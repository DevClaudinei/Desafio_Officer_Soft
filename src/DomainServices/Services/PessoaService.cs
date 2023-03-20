using DomainModels.Entities;
using DomainServices.Exceptions;
using DomainServices.Services.Interfaces;
using Infrastructure.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainServices.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly ApplicationDbContext _context;

        public PessoaService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<long> CadastraPessoa(Pessoa pessoa)
        {
            pessoa.Cpf = FormataCpf(pessoa.Cpf);
            VerificaSePessoaJaExiste(pessoa);

            var cadastro = _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();

            return cadastro.Entity.Id;
        }

        private void VerificaSePessoaJaExiste(Pessoa pessoa)
        {
            var pessoaJaExiste = _context.Pessoas.AnyAsync(x => x.Cpf.Equals(pessoa.Cpf)).Result;

            if (pessoaJaExiste)
                throw new BadRequestException($"Pessoa com o Cpf: {pessoa.Cpf} já esta cadastrada.");
        }

        private static string FormataCpf(string cpf)
        {
            return cpf.Substring(0, 3) + "." + cpf.Substring(3, 3) + "." + cpf.Substring(6, 3) + "-" + cpf.Substring(9, 2);
        }

        public async Task<List<Pessoa>> MostraTodosCadastrados()
        {
            var pessoasCadastradas = await _context.Pessoas.ToListAsync();

            return pessoasCadastradas;
        }

        public async Task<Pessoa> BuscaPessoaPeloCpf(string cpf)
        {
            cpf = FormataCpf(cpf);

            var pessoaEncontrada = await _context.Pessoas.FirstOrDefaultAsync(x => x.Cpf.Equals(cpf));

            return pessoaEncontrada;
        }

        public async Task<Pessoa> BuscaPessoaPorId(long id)
        {
            var pessoaEncontrada = await _context.Pessoas.FirstOrDefaultAsync(x => x.Id.Equals(id));

            return pessoaEncontrada;
        }

        public async Task<Pessoa> BuscaPessoaPeloNome(string name)
        {
            var pessoaEncontrada = await _context.Pessoas.FirstOrDefaultAsync(x => x.Nome.Contains(name));

            return pessoaEncontrada;
        }

        public async Task<Pessoa> MostraPessoaPorId(long id)
        {
            var pessoaEncontrada = await _context.Pessoas.FirstOrDefaultAsync(x => x.Id.Equals(id));

            return pessoaEncontrada;
        }

        public void AtualizCadastro(Pessoa pessoa)
        {
            pessoa.Cpf = FormataCpf(pessoa.Cpf);

            _context.Update(pessoa);
            _context.SaveChanges();
        }

        public void ExcluiPessoa(long id)
        {
            var pessoaParaExclusao = _context.Pessoas.Find(id) 
                ?? throw new NotFoundException($"Pessoa com o Id: {id} não localizada.");

            _context.Remove(pessoaParaExclusao);
            _context.SaveChangesAsync();
        }
    }
}
