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

        public void DestinationGroupedFlights()
        {
            var query = from f in Flights
                        group f by f.Destination into g
                        select g;
            foreach (var g in query)
            {
                Console.WriteLine($"Destination : {g.Key}");
                foreach (var f in g)
                {
                    Console.WriteLine($"Décollage : {f.FlightDate}");
                }
            }

            var grouped = Flights.GroupBy(f => f.Destination);

        }

        public double DurationAverage(string destination)
        {

            var query1 = from f in Flights
                          where f.Destination == destination
                          select f.EstimatedDuration;

            var query2 = Flights.Where(f => f.Destination == destination)
                .Select(f => f.EstimatedDuration);
            
            /*dans cette méthode on va selectionner une destination spécifique 
             pour calculer valeur moyenne des vols dans cette destination en utilisant "average"  
            */
            return query2.Average();
        }

        /* public List<DateTime> GetFlightDates(string destination)
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
        /*    }
            return result; // il faut un return 
        }*/

        public List<DateTime> GetFlightDates(string destination)
        {

            var query1 = from f in Flights
                         where f.Destination == destination
                         select f.FlightDate;


            var query2 = Flights.Where(f => f.Destination == destination)
                .Select(f => f.FlightDate);
            return query1.ToList();
        
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "destination":
                    foreach (var f in Flights)
                    {
                        if (f.Destination == filterValue)
                        {
                            Console.WriteLine(f.ToString());
                        }
                    }
                    break;

                case "flightdate":
                    foreach (var f in Flights)
                    {
                        if (f.FlightDate.ToString() == filterValue)
                        {
                            Console.WriteLine(f.ToString());
                        }
                    }
                    break;

                case "effectivearrival":
                    foreach (var f in Flights)
                    {
                        if (!f.EffectiveArrival.Equals(filterValue))
                        {
                            Console.WriteLine(f.ToString());
                        }
                    }
                    break;


            }
        }

        public IEnumerable<Flight> OrderedDurationFlights() 
        {
            /*dans cette méthode on vas selectionner les vols a l'aide
             de "orderby" pour que la résultats soit ordonnes 
            et descending pour qu'elle soit de plus long au plus court 
             */

            var query1 = from f in Flights
                         orderby f.EstimatedDuration descending
                         select f;
            foreach(var f in query1)
            {
                Console.WriteLine($"Destination : {f.Destination}la durée du vols estimée est : {f.EstimatedDuration}");
            }

            /* dans le syntax de lambda on ne mets 
               pas select apres orderby (c'est le dernier paramétre) */
            var query2= Flights.
                OrderByDescending(f => f.EstimatedDuration);
            foreach(var f in query2)
            {
                Console.WriteLine($"Destination : {f.Destination}la durée du vols estimée est : {f.EstimatedDuration}");

            }

            /*foreach pour afficher la resultat du query1 ou query2 */
            return query1;
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {

            DateTime endDate = startDate.AddDays(7); 
            // variable pour fixer 7 jours a partir de la date donnee

            //version LINQ (query)
            var query1 = from f in Flights
                         where f.FlightDate >= startDate && f.FlightDate < endDate
                         select f; 
            /* ici on veut selectionner tous les vols planifier entre
            la date donnée et les 7 jours prochaine en utilisant count() 
            pour calculer le nombre des vols planifier dans cette intervale */

            //Version LINQ (lambda)
           var query2 = Flights.Where(f => f.FlightDate >= startDate && f.FlightDate < endDate)
                .Select(f => f);

            return query1.Count();
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
       
            var query1 = flight.Passengers
                        .OfType<Traveller>()  
                        .OrderBy(t => t.BirthDate) 
                        .Take(3);
            foreach(var f in query1)
            {
                Console.WriteLine($" Mr/Mme : {f.FirstName}{f.LastName} née le {f.BirthDate}");
            }

            /*cette méthode vise a selectionner 3 premier passager 
             de type traveller les plus agés en  orderBY qui 
             collecte par défaut de les perssones les plus agés 
             */

            var query2=flight.Passengers.OfType<Traveller>()
                .OrderBy(f => f.BirthDate).Take(3);
           
            foreach (var f in query2)
            {
                Console.WriteLine($" Mr/Mme : {f.FirstName}{f.LastName} née le {f.BirthDate}");
            }

            return query1;
                       
        }

        public void ShowFlightDetails(Plane plane)
        {
            var query1 =  from f in Flights
                          where f.Plane == plane
                          select new { f.Destination, f.FlightDate } ;
            foreach (var f in Flights)
            {
                Console.WriteLine($"Flight details: {query1.ToString()}");
            }

            var query2 = Flights.Where(f => f.Plane== plane )
                .Select(f => new { f.Destination,f.FlightDate }) ;
            foreach (var f in Flights)
            {
                Console.WriteLine($"f details : {query2.ToString()}");
            }
            
        }
    }


       
}
