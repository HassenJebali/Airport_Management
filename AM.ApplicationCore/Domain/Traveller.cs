using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    internal class Traveller :Passenger 
    {
        public int HealthInformation { get; set; }
        public string Nationality { get; set; }
    }
}
