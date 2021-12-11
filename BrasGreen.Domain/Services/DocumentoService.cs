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
            char[] rgBase = rg.Contains("-") || rg.Contains(".") ? FormatarValor(rg).ToCharArray() : rg.ToCharArray();
            int resultadoDv, somaDv = 0;
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

            if ((rgBase.Last() == 'X' && resultadoDv == 10) ||
                (rgBase.Last() != 'X' && rgBase.Last() != '0' && rgBase.Last().ToString() == resultadoDv.ToString()) ||
                (rgBase.Last() == '0' && resultadoDv == 11))
                return true;
            else
                return false;
        }

        public string FormatarValor(string valorFormatar)
        {
            string formatado = valorFormatar.Contains("-") ? valorFormatar.Replace("-", "") : valorFormatar;
            formatado = formatado.Contains("/") ? formatado.Replace("/", "") : formatado;
            return formatado.Contains(".") ? formatado.Replace(".", "") : formatado;
        }

        public bool ValidarCPF(string cpf)
        {
            char[] cpfBase = cpf.Contains("-") || cpf.Contains("-") ? FormatarValor(cpf).ToCharArray() : cpf.ToCharArray();

            int primeiroDV, segundoDV, somaDv = 0;
            int multiplicador = 10;

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
                dictionary.Clear();
                somaDv = 0;

                if (primeiroDV.ToString() == cpfBase[9].ToString() ||
                    (primeiroDV == 0 && cpfBase[9] == '0') ||
                    (primeiroDV == 1 && cpfBase[9] == '0'))
                {
                    for (int i = 0; i < cpfBase.Count() - 1; i++)
                    {
                        dictionary.Add(i, multiplicador * int.Parse(cpfBase[i].ToString()));

                        if (dictionary.TryGetValue(i, out int value))
                            somaDv += value;

                        multiplicador -= 1;
                    }
                    segundoDV = 11 - (somaDv % 11);

                    if (segundoDV.ToString() == cpfBase[10].ToString() ||
                    (segundoDV == 0 && cpfBase[10] == '0') ||
                    (segundoDV == 1 && cpfBase[10] == '0'))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ValidarCnpj(string cnpj)
        {
            char[] cnpjCarcteres = cnpj.Contains("/") || cnpj.Contains(".") ? FormatarValor(cnpj).ToCharArray() : cnpj.ToCharArray();

            int primeiroDV, segundoDV, somaDv = 0;
            int multiplicador = 6;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            try
            {
                for (int i = 0; i <= cnpjCarcteres.Count() - 3; i++)
                {
                    if (multiplicador > 9)
                        multiplicador = 2;

                    dictionary.Add(i, multiplicador * int.Parse(cnpjCarcteres[i].ToString()));

                    if (dictionary.TryGetValue(i, out int value))
                        somaDv += value;

                    multiplicador++;
                }

                multiplicador = 5;
                primeiroDV = somaDv % 11;
                dictionary.Clear();

                if (primeiroDV.ToString() == cnpjCarcteres[12].ToString())
                {
                    for (int i = 0; i <= cnpjCarcteres.Count() - 2; i++)
                    {
                        if (multiplicador > 9)
                            multiplicador = 2;

                        dictionary.Add(i, multiplicador * int.Parse(cnpjCarcteres[i].ToString()));

                        if (dictionary.TryGetValue(i, out int value) && i == 0)
                            somaDv = value;
                        else if(dictionary.TryGetValue(i, out int obj))
                            somaDv += obj;

                        multiplicador++;
                    }

                    segundoDV = somaDv % 11;

                    return segundoDV.ToString() == cnpjCarcteres[13].ToString();
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
