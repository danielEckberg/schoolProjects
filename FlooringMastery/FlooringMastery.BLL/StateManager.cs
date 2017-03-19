using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.BLL
{
    public class StateManager
    {
        private IStateTaxRepository _stateTaxRepository;

        public StateManager(IStateTaxRepository stateTaxRepository)
        {
            _stateTaxRepository = stateTaxRepository;
        }

        public StateLookupResponse LookupState(string State)
        {
            StateLookupResponse response = new StateLookupResponse();

            response.StateTax = _stateTaxRepository.ChooseStateTax(State);

            if (response.StateTax == null)
            {
                response.Success = false;
                response.Message = $"{State} is not currently in our sales region.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public StateFileLookup ListAllStates()
        {
            StateFileLookup response = new StateFileLookup();

            response.StateList = _stateTaxRepository.GetStateTaxList();

            if (response.StateList == null)
            {
                response.Success = false;
                response.Message = "There was an error with the State Tax File. Contact IT.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
    }
}
