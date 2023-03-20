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
            VerificaSePessoaJaExiste(pessoa);
            pessoa.Cpf = FormataCpf(pessoa.Cpf);

            var cadastro = _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();

            return cadastro.Entity.Id;
        }

        private string FormataCpf(string cpf)
        {
            var x = cpf.Substring(0, 3) + "." + cpf.Substring(3, 3) + "." + cpf.Substring(6, 3) + "-" + cpf.Substring(9, 2);
            return x;
        }

        private void VerificaSePessoaJaExiste(Pessoa pessoa)
        {
            var pessoaJaExiste = _context.Pessoas.AnyAsync(x => x.Cpf.Equals(pessoa.Cpf)).Result;

            if (pessoaJaExiste)
                throw new BadRequestException($"Customer already exists for CPF: {pessoa.Cpf}");
        }

        public async Task<Pessoa> MostraPessoaPorId(long id)
        {
            var pessoaEncontrada = await _context.Pessoas.FirstOrDefaultAsync(x => x.Id.Equals(id));

            return pessoaEncontrada;
        }

        public async Task<List<Pessoa>> MostraTodosCadastrados()
        {
            var pessoasCadastradas = await _context.Pessoas.ToListAsync();

            return pessoasCadastradas;
        }

        public void AtualizCadastro(Pessoa pessoa)
        {
            _context.Update(pessoa);
            _context.SaveChanges();
        }

        public void ExcluiPessoa(long id)
        {
            var pessoaParaExclusao = _context.Pessoas.Find(id);

            _context.Remove(pessoaParaExclusao);
            _context.SaveChangesAsync();
        }

        public async Task<Pessoa> BuscaPessoaPorId(long id)
        {
            var pessoaEncontrada = await _context.Pessoas.FirstOrDefaultAsync(x => x.Id.Equals(id));

            return pessoaEncontrada;
        }
    }
}
