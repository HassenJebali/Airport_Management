using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmployementDate { get; set; }
        public string function { get; set; }

        [DataType(DataType.Currency)]
        public double Salary { get; set; }

        override
            public void PassengerType()
        {
            Console.WriteLine("I am a staff");
        }
    }
}
