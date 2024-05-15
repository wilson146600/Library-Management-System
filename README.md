# Library Management System

## Overzicht

Het Library-Management-System is een C# console-applicatie ontworpen om de collectie van een bibliotheek te beheren, inclusief boeken, tijdschriften en kranten. Het systeem biedt functionaliteiten om items toe te voegen, te zoeken en het uitlenen van bibliotheekitems te beheren.

## Functies

- **Toevoegen van Boeken, Tijdschriften en Kranten**: Voeg eenvoudig nieuwe items toe aan de collectie van de bibliotheek.
- **Zoeken en Weergeven**: Zoek naar items op titel, auteur of andere attributen en geef gedetailleerde informatie weer.
- **Beheer van Uitleningen**: Leen boeken uit en neem ze terug in met automatische berekening van de vervaldatum.
- **Dataopslag**: Sla boekgegevens op en laad ze vanuit CSV-bestanden voor blijvende opslag.
- **Datum- en Tijdafhandeling**: Nauwkeurige datum parsing en formattering voor verschillende operaties.
- **Gebruiksvriendelijke Interface**: Intuïtieve command-line interface voor soepele gebruikersinteractie.
- **Foutafhandeling**: foutafhandeling om runtime fouten te voorkomen en de stabiliteit van de applicatie te waarborgen.

## Installatie

1. Clone de repository:
    ```bash
    git clone https://github.com/<yourusername>/library-management-system.git
    ```

2. Open het project in je favoriete C# IDE (bijv. Visual Studio).

3. Bouw de oplossing om afhankelijkheden te herstellen en de applicatie te compileren.

## Gebruik

1. Voer de applicatie uit vanuit je IDE of met behulp van het gegenereerde uitvoerbare bestand tijdens het bouwproces.

2. Volg de instructies op het scherm om te communiceren met het bibliotheekbeheersysteem:
    - Voeg nieuwe boeken, tijdschriften en kranten toe.
    - Zoek naar items op basis van verschillende criteria.
    - Beheer uitleentransacties voor boeken.
    - Bekijk nieuwe acquisities in de leeszaal die vandaag zijn toegevoegd.

## Code Structuur

- **Program.cs**: Startpunt van de applicatie.
- **Library.cs**: Bevat de `Library` klasse die verantwoordelijk is voor het beheren van de collectie items en gerelateerde operaties.
- **Book.cs, Magazine.cs, Newspaper.cs**: Definieer de `Book`, `Magazine` en `Newspaper` klassen.
- **CSVFileHandler.cs**: Behandelt het lezen van en schrijven naar CSV-bestanden.
- **Loan.cs**: Beheert de uitleentransacties voor boeken.

## Belangrijke Concepten en Technologieën

- **Objectgeoriënteerd Programmeren (OOP)**: Maakt gebruik van OOP-principes om een modulaire en onderhoudbare codebase te ontwerpen.
- **Bestandshandling**: Implementeert dataopslag door middel van CSV-bestand lezen en schrijven.
- **Foutafhandeling**: Zorgt voor stabiliteit van de applicatie met uitgebreide fout- en uitzonderingsafhandelingsmechanismen.
- **Datum- en Tijdsmanipulatie**: Behandelt nauwkeurig datum- en tijdoperaties voor verschillende functionaliteiten.

## Bijdragen

Bijdragen zijn welkom! Als je bugs vindt of suggesties hebt voor verbeteringen, maak dan een issue aan of dien een pull request in.


## Contact

Voor vragen of inlichtingen, neem contact op met Wilson (mailto:wilsonquayson1999@gmail.com).


