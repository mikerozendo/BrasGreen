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
            int resultadoDv = 0;

            //Alterar retornos quando implementar DVs X e 0
            if (caracteres.Last() != 'X' && caracteres.Last() != '0')
            {
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

                    resultadoDv = (somaDv % 11) - 11;

                    if (resultadoDv.ToString() == caracteres.Last().ToString())
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
               
            }
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
