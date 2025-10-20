// See https://aka.ms/new-console-template for more information

using System;
using System.ComponentModel.DataAnnotations;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
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

/*
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


*/


/*AMContext context = new AMContext();
context.Flights.Add(TestData.flight2);
context.SaveChanges();
Console.WriteLine(context.Flights.First());
*/



AMContext ctx = new AMContext();

int choix = 0;

do
{
    Console.WriteLine("\n=============================");
    Console.WriteLine(" MENU PRINCIPAL ");
    Console.WriteLine("=============================");
    Console.WriteLine("1. Ajouter un Avion");
    Console.WriteLine("2. Ajouter un Vol");
    Console.WriteLine("3. Ajouter un Voyageur");
    Console.WriteLine("4. Affecter des Vols à un Avion");
    Console.WriteLine("5. Affecter des Voyageurs à des Vols");
    Console.WriteLine("6. Afficher le nombre de vols assuré par un avion");
    Console.WriteLine("7. Afficher le nombre de passagers par vol");
    Console.WriteLine("8. Quitter");
    Console.Write("👉 Votre choix : ");

    choix = int.Parse(Console.ReadLine());

    switch (choix)
    {
        case 1:
            AjouterAvion(ctx);
            break;
        case 2:
            AjouterVol(ctx);
            break;
        case 3:
            AjouterVoyageur(ctx);
            break;
        case 4:
            AffecterVolsAvion(ctx);
            break;
        case 5:
            AffecterVoyageursVol(ctx);
            break;
        case 6:
            NbVolsParAvion(ctx);
            break;
        case 7:
            NbPassagersParVol(ctx);
            break;
        case 8:
            Console.WriteLine("Quitter !");
            break;
        default:
            Console.WriteLine("❌ Choix invalide, veuillez entrer un nombre entre 1 et 8.");
            break;
    }

} while (choix != 8);
    

static void AjouterAvion(AMContext ctx)
{
    var plane = new Plane();

    Console.Write("👉 Type d’avion (0 = Boing, 1 = Airbus) : ");
    plane.PlaneType = (PlaneType)int.Parse(Console.ReadLine());

    Console.Write("👉 Capacité : ");
    plane.Capacity = int.Parse(Console.ReadLine());

    Console.Write("👉 Date de fabrication (format JJ/MM/AAAA) : ");
    plane.ManufactureDate = DateTime.Parse(Console.ReadLine());

    ctx.Planes.Add(plane);
    int result = ctx.SaveChanges();

    if (result > 0)
        Console.WriteLine("✅ Avion ajouté avec succès !");
    else
        Console.WriteLine("❌ Erreur lors de l'ajout de l'avion.");
}


static void AjouterVol(AMContext ctx)
{
    var flight = new Flight();

    Console.WriteLine("=== ✈️ AJOUT D’UN NOUVEAU VOL ===");

    Console.Write("👉 Destination : ");
    flight.Destination = Console.ReadLine();

    Console.Write("👉 Date du vol (JJ/MM/AAAA) : ");
    flight.FlightDate = DateTime.Parse(Console.ReadLine());

    Console.Write("👉 Heure de départ (HH:MM) : ");
    flight.Deparature = flight.FlightDate.Date + TimeSpan.Parse(Console.ReadLine());

    Console.Write("👉 Heure d’arrivée effective (HH:MM) : ");
    flight.EffectiveArrival = flight.FlightDate.Date + TimeSpan.Parse(Console.ReadLine());

    Console.Write("👉 Durée estimée (en minutes) : ");
    flight.EstimatedDuration = int.Parse(Console.ReadLine());

    Console.Write("👉 Compagnie aérienne : ");
    flight.Airline = Console.ReadLine();

    Console.Write("👉 ID de l’avion assigné : ");
    flight.PlaneId = int.Parse(Console.ReadLine());

    // Vérification que l’avion existe
    var plane = ctx.Planes.Find(flight.PlaneId);
    if (plane == null)
    {
        Console.WriteLine("❌ Aucun avion trouvé avec cet ID !");
        return;
    }
    ctx.Flights.Add(flight);
    int result = ctx.SaveChanges();

    if (result > 0)
        Console.WriteLine("✅ Vol ajouté avec succès !");
    else
        Console.WriteLine("❌ Erreur lors de l’ajout du vol.");

}



    static void AjouterVoyageur(AMContext ctx)
    {
        var passenger = new Passenger();

        Console.WriteLine("=== 👤 AJOUT D’UN NOUVEAU VOYAGEUR ===");

        Console.Write("👉 Prénom : ");
        passenger.FirstName = Console.ReadLine();

        Console.Write("👉 Nom : ");
        passenger.LastName = Console.ReadLine();

        Console.Write("👉 Numéro de passeport (7 caractères max) : ");
        passenger.PassportNumber = Console.ReadLine();

        Console.Write("👉 Adresse e-mail : ");
        passenger.EmailAddress = Console.ReadLine();

        Console.Write("👉 Numéro de téléphone (8 chiffres) : ");
        passenger.TelNumber = int.Parse(Console.ReadLine());

        Console.Write("👉 Date de naissance (JJ/MM/AAAA) : ");
        passenger.BirthDate = DateTime.Parse(Console.ReadLine());

        // Ajout dans la base
        ctx.Passeengers.Add(passenger);
        int result = ctx.SaveChanges();

        if (result > 0)
            Console.WriteLine("✅ Voyageur ajouté avec succès !");
        else
            Console.WriteLine("❌ Erreur lors de l’ajout du voyageur.");
    }


    static void AffecterVolsAvion(AMContext ctx)
    {
        Console.WriteLine("=== ✈️ AFFECTATION D’UN VOL À UN AVION ===");

        // Demander l’ID de l’avion
        Console.Write("👉 Entrez l'ID de l'avion : ");
        int idAvion = int.Parse(Console.ReadLine());

        // Chercher l’avion dans la base
        var avion = ctx.Planes.Find(idAvion);
        if (avion == null)
        {
            Console.WriteLine("❌ Aucun avion trouvé avec cet ID !");
            return;
        }

        // Demander l’ID du vol
        Console.Write("👉 Entrez l'ID du vol à affecter : ");
        int idVol = int.Parse(Console.ReadLine());

        // Chercher le vol dans la base
        var vol = ctx.Flights.Find(idVol);
        if (vol == null)
        {
            Console.WriteLine("❌ Aucun vol trouvé avec cet ID !");
            return;
        }

        // Affecter le vol à l’avion
        vol.Plane = avion;

        // Enregistrer les changements
        ctx.SaveChanges();

        Console.WriteLine($"✅ Le vol vers {vol.Destination} a été affecté à l’avion de type {avion.PlaneType} !");
    }


static void AffecterVoyageursVol(AMContext ctx)
{
    Console.WriteLine("=== 👤 AFFECTATION D’UN VOYAGEUR À UN VOL ===");

    // Demander l’ID du vol
    Console.Write("👉 Entrez l'ID du vol : ");
    int idVol = int.Parse(Console.ReadLine());

    var vol = ctx.Flights.Find(idVol);
    if (vol == null)
    {
        Console.WriteLine("❌ Aucun vol trouvé avec cet ID !");
        return;
    }

    // Demander l’ID du voyageur
    Console.Write("👉 Entrez l'ID du voyageur : ");
    int idVoy = int.Parse(Console.ReadLine());

    var passenger = ctx.Passeengers.Find(idVoy);
    if (passenger == null)
    {
        Console.WriteLine("❌ Aucun voyageur trouvé avec cet ID !");
        return;
    }

    // Initialiser la collection si nécessaire
    if (vol.Passengers == null)
        vol.Passengers = new List<Passenger>();

    // Ajouter le voyageur au vol
    vol.Passengers.Add(passenger);

    // Enregistrer les changements
    ctx.SaveChanges();

    Console.WriteLine($"✅ Le voyageur {passenger.FirstName} {passenger.LastName} a été ajouté au vol vers {vol.Destination} !");
}


static void NbVolsParAvion(AMContext ctx)
{
    Console.WriteLine("=== ✈️ NOMBRE DE VOLS D’UN AVION ===");

    // Demander l'ID de l'avion
    Console.Write("👉 Entrez l'ID de l'avion : ");
    int idAvion = int.Parse(Console.ReadLine());

    // Vérifier si l'avion existe
    var avion = ctx.Planes.Find(idAvion);
    if (avion == null)
    {
        Console.WriteLine("❌ Aucun avion trouvé avec cet ID !");
        return;
    }
}
// Compter les vols liés à ce


static void NbPassagersParVol(AMContext ctx)
{
    Console.WriteLine("=== 👥 NOMBRE DE PASSAGERS PAR VOL ===");

    // Récupérer tous les vols
    var vols = ctx.Flights.ToList();

    if (vols.Count == 0)
    {
        Console.WriteLine("❌ Aucun vol disponible.");
        return;
    }

    // Parcourir chaque vol et compter les passagers
    foreach (var vol in vols)
    {
        // Initialiser la collection si nécessaire
        if (vol.Passengers == null)
            vol.Passengers = new List<Passenger>();

        int nbPassagers = vol.Passengers.Count;

        Console.WriteLine($"Vol ID {vol.FlightId} vers {vol.Destination} : {nbPassagers} passager(s).");
    }
}

