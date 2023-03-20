using Application.Models.DTOs;
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
                .Must(x => x.DocumentoEhValido());

            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .Must(x => x.Split(" ").Length > 1)
                .WithMessage("FullName deve conter ao menos um sobrenome")
                .Must(x => !x.ContemEspacoEmBranco())
                .WithMessage("FullName não deve conter espaços em branco")
                .Must(x => !x.ExisteAlgumSimboloOuCaracterEspecial())
                .WithMessage("FullName não deve conter caracteres especiais")
                .Must(x => x.TemPeloMenosDoisCaracteresParaCadaPalavra())
                .WithMessage("FullName inválido. Nome e/ou sobrenome devem conter ao menos duas letras ou mais");

            RuleFor(x => x.Cep)
                .NotEmpty()
                .NotNull()
                .Must(x => x.EhUmCepValido())
                .WithMessage("O campo PostalCode deve estar no formato XXXXX-XXX");

            RuleFor(x => x.Numero)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Bairro)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Complemento)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Municipio)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Uf)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Rg)
                .NotEmpty()
                .NotNull();
        }
    }
}
