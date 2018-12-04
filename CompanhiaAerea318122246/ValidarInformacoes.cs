using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanhiaAerea318122246
{
    public class ValidaInformacoes
    {
        public bool ValidaCPF(string CPF)
        {
            int[] multiplicar1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicar2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCPF;

            string digito;

            int soma;

            int resto;

            CPF = cpf.Trim();

            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)

                return false;

            tempCPF = CPF.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)

                soma += int.Parse(tempCPF[i].ToString()) * multiplicar1[i];

            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();

            tempCPF = tempCPF + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += int.Parse(tempCPF[i].ToString()) * multiplicar2[i];

            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = digito + resto.ToString();

            return CPF.EndsWith(digito);
        }
    }
}
