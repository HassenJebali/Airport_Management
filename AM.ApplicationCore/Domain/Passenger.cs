using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int Id { get; set; }

        [Display(Name = "DateOfBirth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [StringLength(7)]
        public String PassportNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public String EmailAddress { get; set; }

        [MinLength(3, ErrorMessage = "Le nom doit contenir au moins 3 caracteres")]
        [MaxLength(25, ErrorMessage = "Le nom doit contenir au maximum 25 caracteres")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Numéro de télephone Invalide")]
        public int TelNumber { get; set; }


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
        public virtual ICollection<Ticket> Tickets { get; set; }

        public override string? ToString()
        {
            return $"Le passager {FirstName} {LastName} ";
        }

        public Boolean CheckProfile(String First_Name, String Last_Name)
        {
            if (First_Name != null && Last_Name != null)
                return true;
            else return false;
        }

        public Boolean CheckProfile(String First_Name, String Last_Name, String EmailAdress)
        {
            if (First_Name != null && Last_Name != null && EmailAdress != null)
                return true;
            else return false;
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am passenger");
        }
    }
}
