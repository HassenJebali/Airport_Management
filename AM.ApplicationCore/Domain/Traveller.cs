using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveller :Passenger 
    {
        public String HealthInformation { get; set; }
        public string Nationality { get; set; }

        override
            public void PassengerType() {
            Console.WriteLine("I am a traveller");
        }
    }
}
