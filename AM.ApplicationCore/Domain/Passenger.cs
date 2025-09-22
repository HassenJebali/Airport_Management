using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public int PassportNumber { get; set; }
        public string EmailAdress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int TelNumber {  get; set; }

        public ICollection<Flight> Flights { get; set; }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
