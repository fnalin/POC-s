using System.Collections.Generic;

namespace AutoComplete.NomeOrCPF.API.Models
{
    public class PessoaRepo : IPessoaRepo
    {
        private IList<Pessoa> _tabPessoas
        {
            get
            {
                return new List<Pessoa> {
                    new Pessoa { Id=1,Nome="Fabiano Nalin",CPF="12263425233"},
                    new Pessoa { Id=2,Nome="Priscila Mitui",CPF="93806365989"},
                    new Pessoa { Id=3,Nome="Raphael Nalin",CPF="77056873642"},
                    new Pessoa { Id=4,Nome="Rafael Pereira de Goes",CPF="58133513707"},
                    new Pessoa { Id=5,Nome="Isabel Aparecida da Silva",CPF="48173942269"},
                    new Pessoa { Id=6,Nome="Fernanda Franco",CPF="74897867207"},
                    new Pessoa { Id=7,Nome="Fulano com CPF errado",CPF="1867207"},
                }
                .FormatarCPF();
            }
        }


        public IList<Pessoa> GetAll()
        {
            return _tabPessoas;
        }

        public int Count
        {
            get
            {
                return _tabPessoas.Count;
            }
        }
    }
}