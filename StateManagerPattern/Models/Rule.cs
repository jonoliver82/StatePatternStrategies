using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace StateManagerPattern.Models
{
    public class Rule
    {
        public Rule(ConnectionState destinationState, Func<char, bool> func)
        {
            DestinationState = destinationState;
            Func = func;
        }

        public ConnectionState DestinationState { get; set; }

        public Func<char, bool> Func { get; set; }
    }
}
