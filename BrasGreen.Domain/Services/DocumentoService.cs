using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrasGreen.Domain.Interfaces;

namespace BrasGreen.Domain.Services
{
    public class DocumentoService : IDocumentoService
    {
        public bool ValidarRG(string rg)
        {
            char[] caracteres = FormatarRG(rg).ToCharArray();
            string resultadoDv = "";

            if (caracteres.Last() != 'X' && caracteres.Last() != '0')
            {
                int[] numeros = new int[caracteres.Length];
                int[] multiplicadores = { 2, 3, 4, 5, 6, 7, 8, 9 };
                int resultado = 0;
                for (int i = 0; i < caracteres.Length; i++)
                {
                    numeros[i] = int.Parse(caracteres[i].ToString());
                }

                for (int j = 0; j < numeros.Length; j++)
                {
                    resultado += numeros[j] + multiplicadores[j];
                }

                int calculoDv = resultado % 11;
                //resultadoDv = calculoDv - 11;
                resultado = calculoDv - 11;
                resultadoDv = resultado.ToString();
            }


            if (resultadoDv == caracteres.Last().ToString())
            {
                return true;
            }

            //alterar retorno quando calcular finais X e 0;
            return false;
        }

        public string FormatarRG(string rgSemFormatacao)
        {
            string rgFormatado = rgSemFormatacao.Replace(".", "");
            rgFormatado = rgSemFormatacao.Replace("-", "");
            return rgFormatado;
        }
    }
}
