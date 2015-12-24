using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoComplete.NomeOrCPF.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace AutoComplete.NomeOrCPF.API.Test.Model
{
    [TestClass]
    public class TestPessoaExtensionMethods
    {
        [TestMethod]
        [TestCategory("PessoaExtensionMethods / output")]
        public void PessoaExtensionMethods_Formatando_cpfs_válidos()
        {
            var pessoas = new List<Pessoa> {
                 new Pessoa { Id=1,Nome="Fabiano Nalin",CPF="12263425233"},
                    new Pessoa { Id=2,Nome="Priscila Mitui",CPF="93806365989"},
                    new Pessoa { Id=3,Nome="Raphael Nalin",CPF="77056873642"},
            };

            pessoas.FormatarCPF();

            Assert.AreEqual(3, pessoas.Count(p => p.CPF.Length == 14));
        }



        [TestMethod]
        [TestCategory("PessoaExtensionMethods / output")]
        public void PessoaExtensionMethods_Formatando_cpfs_testando_saida_invalida()
        {
            var pessoas = new List<Pessoa> {
                 new Pessoa { Id=1,Nome="Fabiano Nalin",CPF="12263425233"},
                    new Pessoa { Id=2,Nome="Priscila Mitui",CPF="93806365989"},
                    new Pessoa { Id=3,Nome="Raphael Nalin",CPF="7705687364"}, //cpf inválido
            };

            pessoas.FormatarCPF();

            Assert.AreEqual(2, pessoas.Count(p => p.CPF.Length == 14));
        }
    }
}
