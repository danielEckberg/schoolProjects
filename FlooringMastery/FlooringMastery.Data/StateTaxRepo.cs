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
    public class StateTaxRepo: IStateTaxRepository
    {
        public const string taxFilePath =
            @"C:\Users\dr3ek\Documents\bootcamp\daniel.eckberg.self.work\Labs\FlooringMastery\Taxes.txt";

        private string _taxFilePath;

        public StateTaxRepo(string taxFilePath)
        {
            _taxFilePath = taxFilePath;
        }

        public List<Tax> GetStateTaxList()
        {
            List<Tax> states = new List<Tax>();

            using (StreamReader sr = new StreamReader(_taxFilePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Tax stateTax = new Tax();

                    string[] columns = line.Split('|');

                    stateTax.State = columns[0];
                    stateTax.StateName = columns[1];
                    stateTax.TaxRate = decimal.Parse(columns[2]);

                    states.Add(stateTax);

                }
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
