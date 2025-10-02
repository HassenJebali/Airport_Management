
namespace AM.ApplicationCore.Domain
{
    public class PassengerExtension : Passenger
    {
        public String UpperFullName(Passenger p) {
            if(p == null) return String.Empty;


           String firstName, lastName;
            firstName = char.ToUpper(p.FirstName[0]) + p.FirstName.Substring(1).ToLower();
            lastName = char.ToUpper(p.LastName[0]) + p.LastName.Substring(1).ToLower();
            return $"{firstName} {lastName}";
        }
    }
}
