using System;
using MayTemperatureLab; // Importerar namespace där vår TempCalculator-klass finns

// Namespace - Ett "paket" som innehåller hela programmet
namespace MayTemperatureLab
{
    // Klass - Program är vår huvudklass där programmet startar
    class Program
    {
        // Main-metoden - Programmet startar här
        static void Main(string[] args)
        {
            // Skapar ett objekt (instans) av TempCalculator-klassen
            TempCalculator tempCalculator = new TempCalculator();

            bool isRunning = true; // Bool som styr while-loopen

            // While-loop som körs tills användaren väljer att avsluta
            while (isRunning)
            {
                // Meny - visar alternativ för användaren
                Console.WriteLine("\nVälj ett alternativ mellan 1 till 11:");
                Console.WriteLine("1. Visa temperaturer för varje dag i Maj");
                Console.WriteLine("2. Visa medeltemperaturen för Maj månad");
                Console.WriteLine("3. Visa dag med högsta temperaturen i Maj");
                Console.WriteLine("4. Visa dag med lägsta temperaturen i Maj");
                Console.WriteLine("5. Visa mediantemperaturen för Maj");
                Console.WriteLine("6. Visa temperaturdata i stigande ordning");
                Console.WriteLine("7. Visa temperaturdata i fallande ordning");
                Console.WriteLine("8. Filtrera temperatur över ett visst värde");
                Console.WriteLine("9. Visa temperatur för en specifik dag samt dagen innan och efter");
                Console.WriteLine("10. Visa den vanligast förekommande temperaturen i Maj");
                Console.WriteLine("11. Avsluta programmet");

                string userInput = Console.ReadLine(); // Läser in användarens val

                // Switch-sats - kollar vad användaren skrev in
                switch (userInput)
                {
                    case "1":
                        tempCalculator.PrintTemperatures(); // Visar alla temperaturer
                        break;
                    case "2":
                        tempCalculator.CalculateAverageTemp(); // Visar medeltemperaturen
                        break;
                    case "3":
                        tempCalculator.ShowMaxTemp(); // Visar högsta temperaturen
                        break;
                    case "4":
                        tempCalculator.ShowMinTemp(); // Visar lägsta temperaturen
                        break;
                    case "5":
                        tempCalculator.CalculateMedianTemp(); // Visar medianen
                        break;
                    case "6":
                        tempCalculator.SortTemperaturesAscending(); // Sorterar i stigande ordning
                        break;
                    case "7":
                        tempCalculator.SortTemperaturesDescending(); // Sorterar i fallande ordning
                        break;
                    case "8":
                        tempCalculator.FilterTemperatures(); // Filtrerar temperaturer över ett visst värde
                        break;
                    case "9":
                        tempCalculator.ShowTempForDay(); // Visar temperatur för vald dag + dag före och efter
                        break;
                    case "10":
                        tempCalculator.ShowMostCommonTemp(); // Visar vanligaste temperaturen
                        break;
                    case "11":
                        isRunning = false; // Avslutar programmet
                        break;
                    default:
                        // Om användaren skriver något annat än 1-11
                        Console.WriteLine("Välj ett alternativ mellan 1 och 11.");
                        break;
                }
            }
        }
    }
}
