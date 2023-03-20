using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AppServices.Validations
{
    public static class StringExtensions
    {
        public static bool DocumentoEhValido(this string document)
        {
            if (document.Length != 11) return false;

            var firstDigitChecker = 0;
            for (int i = 0; i < document.Length - 2; i++)
            {
                firstDigitChecker += document.ConverteParaInteiro(i) * (10 - i);
            }
            firstDigitChecker = firstDigitChecker * 10 % 11;
            if (firstDigitChecker is 10) firstDigitChecker = 0;

            var secondDigitChecker = 0;
            for (int i = 0; i < document.Length - 1; i++)
            {
                secondDigitChecker += document.ConverteParaInteiro(i) * (11 - i);
            }
            secondDigitChecker = secondDigitChecker * 10 % 11;
            if (secondDigitChecker is 10) secondDigitChecker = 0;

            return firstDigitChecker.Equals(document.ConverteParaInteiro(^2)) && secondDigitChecker.Equals(document.ConverteParaInteiro(^1));
        }

        public static int ConverteParaInteiro(this string cpf, Index index)
        {
            var indexValue = index.IsFromEnd
                ? cpf.Length - index.Value
                : index.Value;

            return (int)char.GetNumericValue(cpf, indexValue);
        }

        public static bool ContemEspacoEmBranco(this string fields)
            => fields.Split(" ").Any(x => x == string.Empty);

        public static bool ExisteAlgumSimboloOuCaracterEspecial(this string value)
            => value.Replace(" ", string.Empty).Any(x => !char.IsLetter(x));

        public static bool TemPeloMenosDoisCaracteresParaCadaPalavra(this string fields)
            => !fields.Split(" ").Where(x => x.Length < 2).Any();

        public static bool EhUmCepValido(this string cep)
        {
            var expression = "([0-9]{5}-[0-9]{3})";
            return Regex.Match(cep, expression).Success;
        }
    }
}
