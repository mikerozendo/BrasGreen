using BrasGreen.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrasGreen.Domain.Services
{
    public class DocumentoService : IDocumentoService
    {
        public bool ValidarRG(string rg)
        {
            char[] caracteres = FormatarValor(rg).ToCharArray();
            int resultadoDv = 0;

            int somaDv = 0;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            try
            {
                for (int i = 0; i < caracteres.Length - 1; i++)
                {
                    dictionary.Add(i, (i + 2) * int.Parse(caracteres[i].ToString()));
                    if (dictionary.TryGetValue(i, out int value))
                    {
                        somaDv += value;
                    }
                }

                resultadoDv = 11 - (somaDv % 11);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            if (
                (caracteres.Last() == 'X' && resultadoDv == 10) ||
                (caracteres.Last() != 'X' && caracteres.Last() != '0' && caracteres.Last().ToString() == resultadoDv.ToString()) ||
                (caracteres.Last() == '0' && resultadoDv == 11)
               )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string FormatarValor(string valorFormatar)
        {
            string valorFormatado = valorFormatar.Replace(".", "");
            valorFormatado = valorFormatar.Replace("-", "");
            return valorFormatado;
        }


        public bool ValidarCPF(string cpf)
        {
            char[] cpfCaracteres = FormatarValor(cpf).ToCharArray();

            int resultadoDv = 0;

            int somaDv = 0;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            try
            {
                for (int i = 0; i < cpfCaracteres.Length - 2; i++)
                {
                    dictionary.Add(i, (i + 1) * int.Parse(cpfCaracteres[i].ToString()));
                    if (dictionary.TryGetValue(i, out int value))
                    {
                        somaDv += value;
                    }
                }
            }
            //448.724.598-22
            //280.012.389

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }
    }
}
