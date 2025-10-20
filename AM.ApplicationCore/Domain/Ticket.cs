using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public int IdTicket { get; set; }
        public float Prix { get; set; }
        public string Siege { get; set; }

        public bool VIP { get; set; }
   

        public int FlightId { get; set; }
        public virtual Flight Flights { get; set; }

        public int  IdPassenger { get; set; }
    
        public virtual Passenger Passengers { get; set; }
    }
}
