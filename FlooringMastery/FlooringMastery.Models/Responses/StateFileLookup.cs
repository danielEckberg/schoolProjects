using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.RepoType;

namespace FlooringMastery.Models.Responses
{
    public class StateFileLookup: Response
    {
        public List<Tax> StateList { get; set; }
    }
}
