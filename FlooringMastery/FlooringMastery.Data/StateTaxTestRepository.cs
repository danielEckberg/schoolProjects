using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.RepoType;

namespace FlooringMastery.Data
{
    public class StateTaxTestRepository : IStateTaxRepository
    {

        private static Tax _stateTax = new Tax
        {
            State = "OH",
            StateName = "Ohio",
            TaxRate = 6.25M
        };

        public List<Tax> GetStateTaxList()
        {
            List<Tax> states = new List<Tax>();
            { 
            
                states.Add(_stateTax);
                
            }
            return states;
        }

        public Tax ChooseStateTax(string State)
        {
            var states = GetStateTaxList();

            foreach (var state in states)
            {
                if (state.State == State)
                    return state;
            }
            return null;
        }
    }
}
