using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.RepoType;

namespace FlooringMastery.Models.Interfaces
{
    public interface IStateTaxRepository
    {
        List<Tax> GetStateTaxList();
        Tax ChooseStateTax(string State);
    }
}
