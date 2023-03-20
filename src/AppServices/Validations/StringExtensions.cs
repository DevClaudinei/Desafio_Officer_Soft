using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AppServices.Validations
{
    public static class StringExtensions
    {
        public static bool DocumentoEhValido(this string documento)
        {
            documento = documento.RemoveMascaraDeCpf();

            if (!documento.PossuiNumerosValidos() || documento.TodosOsCaracteresSaoIguaisOPrimeiro()) return false;

            if (documento.Length != 11) return false;

            var validadorPrimeiroDigito = 0;
            for (int i = 0; i < documento.Length - 2; i++)
            {
                validadorPrimeiroDigito += documento.ConverteParaInteiro(i) * (10 - i);
            }
            validadorPrimeiroDigito = validadorPrimeiroDigito * 10 % 11;
            if (validadorPrimeiroDigito is 10) validadorPrimeiroDigito = 0;

            var validadorSegundoDigito = 0;
            for (int i = 0; i < documento.Length - 1; i++)
            {
                validadorSegundoDigito += documento.ConverteParaInteiro(i) * (11 - i);
            }
            validadorSegundoDigito = validadorSegundoDigito * 10 % 11;
            if (validadorSegundoDigito is 10) validadorSegundoDigito = 0;

            return validadorPrimeiroDigito.Equals(documento.ConverteParaInteiro(^2)) 
                && validadorSegundoDigito.Equals(documento.ConverteParaInteiro(^1));
        }

        public static string RemoveMascaraDeCpf(this string cpf)
        {
            var cpfSemMascara = cpf.Replace(".", string.Empty).Replace("-", string.Empty);
            return cpfSemMascara;
        }

        public static bool TodosOsCaracteresSaoIguaisOPrimeiro(this string campo)
        {
            campo = campo.Replace(" ", string.Empty).ToLower();

            return campo.All(c => c.Equals(campo.First()));
        }

        public static bool PossuiNumerosValidos(this string numero)
        {
            if (string.IsNullOrEmpty(numero)) return false;

            return numero.All(x => char.IsDigit(x));
        }

        public static int ConverteParaInteiro(this string cpf, Index indice)
        {
            var valorDoIndice = indice.IsFromEnd
                ? cpf.Length - indice.Value
                : indice.Value;

            return (int)char.GetNumericValue(cpf, valorDoIndice);
        }

        public static bool ContemEspacoEmBranco(this string campos)
            => campos.Split(" ").Any(x => x == string.Empty);

        public static bool ExisteAlgumSimboloOuCaracterEspecial(this string valor)
            => valor.Replace(" ", string.Empty).Any(x => !char.IsLetter(x));

        public static bool TemPeloMenosDoisCaracteresParaCadaPalavra(this string campos)
            => !campos.Split(" ").Where(x => x.Length < 2).Any();

        public static bool EhUmCepValido(this string cep)
        {
            var expression = "([0-9]{5}-[0-9]{3})";
            return Regex.Match(cep, expression).Success;
        }
    }
}
