﻿using Application.Models.DTOs;
using FluentValidation;

namespace AppServices.Validations
{
    public class ValidadorCriaCadastro : AbstractValidator<CriaCadastro>
    {
        public ValidadorCriaCadastro()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty()
                .NotNull()
                .MinimumLength(11)
                .MaximumLength(14)
                .Must(x => x.DocumentoEhValido())
                .WithMessage("Verifique a digitação do Cpf. Um ou mais números podem estar incorretos.");


            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .Must(x => x.Split(" ").Length > 1)
                .WithMessage("Nome deve conter ao menos um sobrenome")
                .Must(x => !x.ContemEspacoEmBranco())
                .WithMessage("Nome não deve conter espaços em branco")
                .Must(x => !x.ExisteAlgumSimboloOuCaracterEspecial())
                .WithMessage("Nome não deve conter caracteres especiais")
                .Must(x => x.TemPeloMenosDoisCaracteresParaCadaPalavra())
                .WithMessage("Nome inválido. Nome e/ou sobrenome devem conter ao menos duas letras ou mais");

            RuleFor(x => x.Cep)
                .NotEmpty()
                .NotNull()
                .Must(x => x.EhUmCepValido())
                .WithMessage("O campo PostalCode deve estar no formato XXXXX-XXX");

            RuleFor(x => x.Numero)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo Número não pode ser vazio ou nulo");

            RuleFor(x => x.Bairro)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo Bairro não pode ser vazio ou nulo");

            RuleFor(x => x.Complemento)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo Complemento não pode ser vazio ou nulo");

            RuleFor(x => x.Municipio)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Uf)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo Uf não pode ser vazio ou nulo");

            RuleFor(x => x.Rg)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo Rg não pode ser vazio ou nulo");
        }
    }
}
