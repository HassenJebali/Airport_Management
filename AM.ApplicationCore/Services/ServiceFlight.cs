using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Interface;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> result = new List<DateTime>();

            foreach (Flight flight in Flights)
            {
                if (flight.Destination == destination)
                {
                    result.Add(flight.FlightDate);
                }
                /* for (int i = 0, i< Flights.Count; i++) 
                     {
                         result.Add(Flights[i].FlightDate);
                     }
                  } */


            }
            return result; // il faut un return 
        }


    }
}
