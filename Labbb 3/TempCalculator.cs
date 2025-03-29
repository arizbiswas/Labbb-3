using System;
using System.Linq;

// Namespace - Ett "paket" där vår klass ligger
namespace MayTemperatureLab
{
    // Klass - TempCalculator hanterar allt som har med temperaturerna att göra
    public class TempCalculator
    {
        // Fält - variabler som lagrar information som används i klassen
        private const int MayDays = 31; // Antal dagar i maj (31 dagar)
        private int[] temperatures = new int[MayDays]; // Array som lagrar temperaturerna för varje dag i maj
        private Random random = new Random(); // Random används för att slumpa temperaturer

        // Konstruktor - körs automatiskt när vi skapar ett nytt objekt av TempCalculator
        public TempCalculator()
        {
            GenerateTemperatures(); // När objektet skapas, genereras temperaturerna direkt
        }

        // Metod - skapar slumpade temperaturer mellan 5°C och 25°C för varje dag
        public void GenerateTemperatures()
        {
            for (int i = 0; i < MayDays; i++)
            {
                temperatures[i] = random.Next(5, 26); // Slumpar temperatur och sparar i arrayen
            }
        }

        // Metod - skriver ut alla temperaturer för maj månad i konsolen
        public void PrintTemperatures()
        {
            for (int i = 0; i < MayDays; i++)
            {
                Console.WriteLine($"Dag {i + 1}: {temperatures[i]}°C"); // Visar vilken dag och temperatur
            }
        }

        // Metod - beräknar och visar medeltemperaturen för hela maj
        public void CalculateAverageTemp()
        {
            double average = temperatures.Average(); // Räknar ut snittet
            Console.WriteLine($"\nMedeltemperaturen i Maj är: {average:F1}°C");
        }

        // Metod - visar högsta temperaturen och vilken dag/dagar den inträffade
        public void ShowMaxTemp()
        {
            int maxTemp = temperatures.Max(); // Hittar högsta temperaturen
            int[] days = temperatures
                .Select((temp, index) => temp == maxTemp ? index + 1 : -1) // Kollar vilka dagar den inträffade
                .Where(day => day != -1)
                .ToArray();

            Console.WriteLine($"\nHögsta temperaturen i Maj: {maxTemp}°C (Dag/Dagar: {string.Join(", ", days)})");
        }

        // Metod - visar lägsta temperaturen och vilken dag/dagar den inträffade
        public void ShowMinTemp()
        {
            int minTemp = temperatures.Min(); // Hittar lägsta temperaturen
            int[] days = temperatures
                .Select((temp, index) => temp == minTemp ? index + 1 : -1) // Kollar vilka dagar den inträffade
                .Where(day => day != -1)
                .ToArray();

            Console.WriteLine($"\nLägsta temperaturen i Maj: {minTemp}°C (Dag/Dagar: {string.Join(", ", days)})");
        }

        // Metod - beräknar medianvärdet av temperaturerna
        public void CalculateMedianTemp()
        {
            var sortedTemps = temperatures.OrderBy(t => t).ToArray(); // Sorterar temperaturerna
            double median;

            if (sortedTemps.Length % 2 == 0)
            {
                // Om jämnt antal dagar (inte aktuellt här, men bra att kunna)
                median = (sortedTemps[MayDays / 2 - 1] + sortedTemps[MayDays / 2]) / 2.0;
            }
            else
            {
                // Om udda antal dagar (som maj, 31 dagar)
                median = sortedTemps[MayDays / 2];
            }

            Console.WriteLine($"\nMediantemperaturen för Maj är: {median:F1}°C");
        }

        // Metod - sorterar och visar temperaturerna i stigande ordning
        public void SortTemperaturesAscending()
        {
            Array.Sort(temperatures); // Sorterar i stigande ordning
            Console.WriteLine("\nTemperaturer i stigande ordning:");
            foreach (int temp in temperatures)
            {
                Console.Write($"{temp}°C ");
            }
            Console.WriteLine();
        }

        // Metod - sorterar och visar temperaturerna i fallande ordning
        public void SortTemperaturesDescending()
        {
            Array.Sort(temperatures); // Först stigande
            Array.Reverse(temperatures); // Sedan vänder vi på arrayen så den blir fallande
            Console.WriteLine("\nTemperaturer i fallande ordning:");
            foreach (int temp in temperatures)
            {
                Console.Write($"{temp}°C ");
            }
            Console.WriteLine();
        }

        // Metod - filtrerar fram och visar temperaturer som är högre än ett tröskelvärde som användaren väljer
        public void FilterTemperatures()
        {
            Console.WriteLine("\nSkriv in ett tröskelvärde:"); // Ber användaren skriva in gräns
            if (int.TryParse(Console.ReadLine(), out int threshold)) // Försöker läsa in ett heltal
            {
                var filtered = temperatures.Where(t => t > threshold); // Hittar temperaturer över tröskeln
                Console.WriteLine($"\nTemperaturer över {threshold}°C:");
                foreach (int temp in filtered)
                {
                    Console.Write($"{temp}°C ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ogiltig input."); // Om användaren inte skriver ett heltal
            }
        }

        // Metod - visar temperaturen för en specifik dag, samt dagen före och efter (om de finns)
        public void ShowTempForDay()
        {
            Console.WriteLine("\nSkriv in en dag (1-31):"); // Frågar efter dag
            if (int.TryParse(Console.ReadLine(), out int day))
            {
                if (day >= 1 && day <= 31) // Kollar att dagen är inom giltigt intervall
                {
                    Console.WriteLine($"Dag {day}: {temperatures[day - 1]}°C");

                    // Visar föregående dag om det inte är dag 1
                    if (day > 1)
                    {
                        Console.WriteLine($"Föregående dag ({day - 1}): {temperatures[day - 2]}°C");
                    }
                    else
                    {
                        Console.WriteLine("Det finns ingen dag innan dag 1.");
                    }

                    // Visar nästa dag om det inte är dag 31
                    if (day < 31)
                    {
                        Console.WriteLine($"Nästa dag ({day + 1}): {temperatures[day]}°C");
                    }
                    else
                    {
                        Console.WriteLine("Det finns ingen dag efter dag 31.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltig dag. Välj en dag mellan 1 och 31.");
                }
            }
            else
            {
                Console.WriteLine("Ogiltig input.");
            }
        }

        // Metod - visar vilken temperatur som förekommer flest gånger under månaden
        public void ShowMostCommonTemp()
        {
            int mostCommon = temperatures
                .GroupBy(t => t) // Grupperar temperaturerna
                .OrderByDescending(g => g.Count()) // Sorterar så den som förekommer mest hamnar först
                .First().Key; // Hämtar temperaturen

            Console.WriteLine($"\nVanligast förekommande temperatur i Maj är: {mostCommon}°C");
        }
    }
}
