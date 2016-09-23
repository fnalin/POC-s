using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCConvertToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlCli =
                (new Cliente
                {
                    Id = 1,
                    Nome = "Fabiano Nalin",
                    Sexo = "M"
                }).ToXML();


            var cli = (Cliente)xmlCli.ToObject(typeof(Cliente));

            var xmlProduto =
                (new Produto
                {
                    Id = 100,
                    Nome = "Notebook Dell",
                    Preco = 3250M
                }).ToXML();
            var prod = (Produto)xmlProduto.ToObject(typeof(Produto));



            Console.Write("XML do cliente: {0}{1}{0}", Environment.NewLine, xmlCli);
            Console.Write("XML do produto: {0}{1}{0}", Environment.NewLine, xmlProduto);
            Console.ReadLine();
        }
    }
}
