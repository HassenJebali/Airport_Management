// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
//using AM.ApplicationCore.Services;
/*
Plane plane = new Plane();
plane.planeType = PlaneType.Airbus;
plane.Capacity = 200;
plane.ManufactureDate = new DateTime(2018, 11, 10);
Console.WriteLine(plane.ToString());

Console.WriteLine("2éme méthode");


Plane plane2 = new Plane
{
    planeType = PlaneType.Airbus,
    Capacity = 150,
    ManufactureDate = new DateTime(2015, 02, 03)
};

Console.WriteLine(plane2.ToString());
Console.WriteLine("3eme méthode");

Plane plane3 = new Plane(300,DateTime.Now ,PlaneType.Boing);
Console.WriteLine(plane3.ToString());
Console.ReadLine();*/


Passenger P1 = new Passenger
{ FirstName = "steve", LastName = "jobs", EmailAddress = "steve.jobs@000.us" };
Console.WriteLine("La méthode passenger");
Console.WriteLine(P1.CheckProfile("steve", "jobs"));
Console.WriteLine(P1.CheckProfile("steve","jobs",""));

Staff s1 = new Staff
{
    FirstName = "steve",
    LastName = "jobs",
    EmailAddress = "steve.jobs@000.us"
};

Traveller t1 = new Traveller
{
    FirstName = "steve",
    LastName = "jobs",
    EmailAddress = "steve.jobs@000.us"
};

Console.WriteLine("-----P1------");
P1.PassengerType();
Console.WriteLine("-------S1----");
s1.PassengerType();
Console.WriteLine("------T1-----");
t1.PassengerType();

Console.WriteLine("-----------");

ServiceFlight sf = new ServiceFlight();
sf.Flights= TestData.listFlights;

Console.WriteLine("=== Vols vers Paris ===");
foreach (var date in sf.GetFlightDates("Paris"))
{
    Console.WriteLine(date);
}

Console.WriteLine("-----------");

PassengerExtension pe = new PassengerExtension
{
    FirstName = "hassen",
    LastName = "jebali",
    EmailAddress = "hj0000@55.tn"
};

Console.WriteLine(pe.UpperFullName(pe));
Console.WriteLine(pe.UpperFullName(P1));
Console.WriteLine(pe.UpperFullName(t1));
Console.WriteLine(pe.UpperFullName(s1));
