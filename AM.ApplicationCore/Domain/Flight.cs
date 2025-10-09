using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {

        public String Destination { get; set; }

        public int MyProperty { get; set; }
        public DateTime Deparature { get; set; }

        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }

       

        public string Airline {  get; set; }
        public virtual ICollection<Passenger> Passengers { get; set;}
        public virtual ICollection<Ticket> Tickets { get; set; }

        public int PlaneId { get; set; }
        [ForeignKey("PlaneId")]
        public virtual Plane Plane { get; set; }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
