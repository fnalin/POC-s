using System.Collections.Generic;

namespace AutoComplete.NomeOrCPF.API.Models
{
    public static class PessoaExtensionMethods
    {

        public static IList<Pessoa> FormatarCPF(this List<Pessoa> pessoas) {

            foreach (var item in pessoas)
            {
                if (item.CPF.Length == 11)
                {
                    item.CPF = string.Format("{0}.{1}.{2}-{3}",
                        item.CPF.Substring(0, 3),
                        item.CPF.Substring(3, 3),
                        item.CPF.Substring(6, 3),
                        item.CPF.Substring(9, 2)
                    );
                }
            }

            return pessoas;
        }

    }
}