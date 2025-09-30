using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Boing,
        Airbus
    }



    public class Plane
    {
        public int PlaneId { get; set; }
        public int Capacity { get; set; }

        public DateTime ManufactureDate { get; set; }

        public  PlaneType PlaneType { get; set; }

        public virtual  ICollection <Flight> Flights { get; set;}

        public override string? ToString()
        {
            return $"Plane de type : {PlaneType}, Capacité : {Capacity}, Date de fabrication : {ManufactureDate:dd/MM/yyyy}";
        }

       /* public static Plane BoingPlane = new Plane { PlaneType = PlaneType.Boing, Capacity = 150, ManufactureDate = new DateTime(2015, 02, 03) };

        public Plane() { }

        public Plane(int capacity, DateTime manufactureDate, PlaneType planeType)
        {
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            this.PlaneType = planeType;
        }*/
    }
}
