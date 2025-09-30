# ✈️ TP Airport Management

## 🎯 Objectif 
Ce Projet a pour but de développer une **application de gestion des activités d’un aéroport** en utilisant **.NET 8**.  
Il permet de pratiquer et d'appliquer les concepts suivants :  

- **Modélisation objet** : héritage, associations, navigation.  
- **Instanciation et manipulation d’objets**.  
- **Polymorphisme** : surcharge de méthodes et héritage.  
- **Interfaces et services** en C#.  
- **Boucles et structures conditionnelles** (`for`, `foreach`).  
- **Requêtes LINQ** pour interroger et manipuler des collections.  
- **Méthodes d’extension** en C#.  

---

## 📌 Étapes à suivre

### 1. Mise en place de la solution
- Créer une solution **AirportManagement** avec deux projets :  
  - `AM.UI.Console` → application console pour tests.  
  - `AM.ApplicationCore` → bibliothèque de classes.  
- Dans `AM.ApplicationCore`, créer un dossier **Domain** pour les entités :  
  `Plane`, `Flight`, `Passenger`, `Staff`, `Traveller`.  
- Ajouter les références entre les projets.

---

### 2. Diagramme de classes
- Implémenter les classes selon le diagramme fourni.  
- Relations :  
  - **Héritage** : `Passenger` → `Staff`, `Traveller`.  
  - **One-to-Many** : `Plane` ↔ `Flight`.  
  - **Many-to-Many** : `Flight` ↔ `Passenger`.  
- Utiliser le mot-clé `virtual` pour les propriétés de navigation.  
- Redéfinir `ToString()` dans chaque classe pour un affichage lisible.

---

### 3. Instanciation des objets
- Créer des objets `Plane` :  
  1. Avec un constructeur vide et affectation des propriétés.  
  2. Avec un constructeur paramétré `(PlaneType pt, int capacity, DateTime date)`.  
  3. Avec un initialiseur d’objet.

---

### 4. Polymorphisme
- **Surcharge (Passenger)** : deux méthodes `CheckProfile()` :  
  - `(string nom, string prénom)`  
  - `(string nom, string prénom, string email)`  
- **Héritage (PassengerType)** :  
  - `"I am a passenger"` pour `Passenger`  
  - `"I'm a traveller"` pour `Traveller`  
  - `"I'm a staff member"` pour `Staff`  
- Tester les comportements dans le projet Console.

---

### 5. Interfaces et services
- Créer une interface `IServiceFlight` et son implémentation `ServiceFlight`.  
- Définir une propriété :  
  ```csharp
  public List<Flight> Flights { get; set; } = new List<Flight>();

---

### 6. Données de test
- Créer une classe statique `TestData` contenant :  
  - **Avions (`Planes`)**  
  - **Staff**  
  - **Travellers**  
  - **Vols (`Flights`)**  
- Tester toutes les méthodes avec ces données dans le projet Console.

---

### 7. Boucles et conditions
- **Méthode `GetFlightDates(string destination)`** :  
  - Retourne les **dates des vols** vers une destination donnée.  
  - Implémenter avec `for` puis `foreach`.  
  - Tester avec plusieurs destinations.

- **Méthode `GetFlights(string filterType, string filterValue)`** :  
  - Affiche les **vols filtrés** par un attribut (Destination, FlightDate, EffectiveArrival).  
  - Exemple : `GetFlights("Destination", "Paris")`.

