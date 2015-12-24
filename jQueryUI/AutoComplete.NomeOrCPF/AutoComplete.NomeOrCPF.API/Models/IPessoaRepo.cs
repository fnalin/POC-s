using System.Collections.Generic;

namespace AutoComplete.NomeOrCPF.API.Models
{
    public interface IPessoaRepo
    {
        IList<Pessoa> GetAll();
        int Count { get; }
    }
}
