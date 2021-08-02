﻿using System.Linq;
using System.Text.RegularExpressions;

namespace VendasOnLine
{
    public class CpfValidator
    {
        const int TAMANHO_MAX_CPF = 11;

        public static bool Validar(string numero)
        {
            if (string.IsNullOrEmpty(numero)) return false;
            numero = Clean(numero);
            if (IsInvalidLenth(numero)) return false;
            if (AllDigitsAreEqual(numero)) return false;
            var digito1 = CalculateDigit(numero, 9);
            var digito2 = CalculateDigit(numero, 10);
            return numero.EndsWith($"{digito1}{digito2}");
        }

        private static string Clean(string cpf)
        {
            return Regex.Replace(cpf, @"\D", "");
        }

        private static bool IsInvalidLenth(string cpf)
        {
            return cpf.Length != TAMANHO_MAX_CPF;
        }

        private static bool AllDigitsAreEqual(string cpf)
        {
            var firstDigit = cpf.Substring(0, 1);
            return cpf.ToArray().All(c => c.ToString().Equals(firstDigit));
        }

        private static int CalculateDigit(string number, int digits)
        {
            var total = 0;
            foreach (var digit in number.Substring(0, digits).ToArray())
            {
                total += int.Parse(digit.ToString()) * (digits-- + 1);
            }
            var resto = total % 11;
            return resto < 2 ? 0 : 11 - resto;
        }
    }
}
