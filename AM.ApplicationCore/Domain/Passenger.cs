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
        public String PassportNumber { get; set; }
        public String EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int TelNumber {  get; set; }

        // public Passenger() { }
        /*public Passenger(DateTime birthDate, int passportNumber, string emailAdress, string firstName, string lastName, int telNumber, ICollection<Flight> flights)
        {
            BirthDate = birthDate;
            PassportNumber = passportNumber;
            EmailAdress = emailAdress;
            FirstName = firstName;
            LastName = lastName;
            TelNumber = telNumber;
        }*/

        public virtual ICollection<Flight> Flights { get; set; }

        public override string? ToString()
        {
            return $"Le passager {FirstName} {LastName} ";
        }

        public Boolean CheckProfile (String First_Name, String Last_Name)
        {
            if (First_Name != null && Last_Name != null)
                return true;
            else return false;
        }

        public Boolean CheckProfile(String First_Name,String Last_Name, String EmailAdress)
        {
            if(First_Name!=null && Last_Name != null && EmailAdress != null)
                return true;
            else return false;
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am passenger");
        }
    }
}
