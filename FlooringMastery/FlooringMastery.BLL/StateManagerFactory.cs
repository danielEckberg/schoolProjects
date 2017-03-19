using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;

namespace FlooringMastery.BLL
{
    public static class StateManagerFactory
    {
        public static StateManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new StateManager(new StateTaxTestRepository());
                case "Live":
                    return new StateManager(new StateTaxRepo(StateTaxRepo.taxFilePath));
                default:

                    throw new Exception("Mode value in app config is not valid");

            }
        }
    }
}
