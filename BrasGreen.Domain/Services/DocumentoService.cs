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
            char[] rgBase = FormatarValor(rg).ToCharArray();
            int resultadoDv = 0;

            int somaDv = 0;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            try
            {
                for (int i = 0; i < rgBase.Count() - 1; i++)
                {
                    dictionary.Add(i, (i + 2) * int.Parse(rgBase[i].ToString()));
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
                (rgBase.Last() == 'X' && resultadoDv == 10) ||
                (rgBase.Last() != 'X' && rgBase.Last() != '0' && rgBase.Last().ToString() == resultadoDv.ToString()) ||
                (rgBase.Last() == '0' && resultadoDv == 11)
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
            char[] cpfBase = FormatarValor(cpf).ToCharArray();

            int primeiroDV = 0;
            int segundoDV = 0;
            int multiplicador = 0;
            int somaDv = 0;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            try
            {
                for (int i = 0; i < cpfBase.Count() - 2; i++)
                {
                    dictionary.Add(i, multiplicador * int.Parse(cpfBase[i].ToString()));
                    if (dictionary.TryGetValue(i, out int value))
                    {
                        somaDv += value;
                    }
                    multiplicador -= 1;
                }

                primeiroDV = 11 - (somaDv % 11);
                multiplicador = 11;

                if (primeiroDV.ToString() == cpfBase[9].ToString() ||
                    (primeiroDV == 0 && cpfBase[9] == '0') ||
                    (primeiroDV == 1 && cpfBase[9] == '0'))
                {
                    for (int i = 0; i < cpfBase.Count() - 1; i++)
                    {
                        dictionary.Add(i, multiplicador * int.Parse(cpfBase[i].ToString()));
                        if (dictionary.TryGetValue(i, out int value))
                        {
                            somaDv += value;
                        }
                        multiplicador -= 1;
                    }
                    segundoDV = 11 - (somaDv % 11);

                    if (segundoDV.ToString() == cpfBase[10].ToString() ||
                    (segundoDV == 0 && cpfBase[10] == '0') ||
                    (segundoDV == 1 && cpfBase[10] == '0'))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
