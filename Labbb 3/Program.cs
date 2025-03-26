using System;
using System.Linq;

// KLASS: TemperatureAnalyzer innehåller logik för att hantera och analysera temperaturdata.
class TemperatureAnalyzer
{
    // FÄLT: Array som lagrar temperaturerna för maj månad (31 dagar)
    private int[] temperatures;

    // FÄLT: Random-objekt för att slumpa temperaturvärden
    private Random random = new Random();

    // METOD: Konstruktor (samma namn som klassen), anropas när ett objekt skapas
    public TemperatureAnalyzer()
    {
        temperatures = new int[31]; // Skapar en array med 31 element för varje dag i maj
        GenerateTemperatures();     // Anropar en metod för att fylla arrayen
    }

    // METOD (utan parameter, returtyp: void): Fyller arrayen med slumpmässiga temperaturer
    private void GenerateTemperatures()
    {
        for (int dayIndex = 0; dayIndex < temperatures.Length; dayIndex++)
        {
            temperatures[dayIndex] = random.Next(5, 26); // Temperatur mellan 5 och 25 grader
        }
    }

    // METOD (utan parameter, returtyp: void): Skriver ut alla temperaturer
    public void DisplayTemperatures()
    {
        for (int dayIndex = 0; dayIndex < temperatures.Length; dayIndex++)
        {
            int temperatureForDay = temperatures[dayIndex];
            Console.WriteLine($"Dag {dayIndex + 1}: {temperatureForDay}°C");
        }
    }

    // METOD (utan parameter, returtyp: double): Returnerar medeltemperaturen
    public double GetAverageTemperature()
    {
        double averageTemperature = temperatures.Average();
        return averageTemperature;
    }

    // METOD (utan parameter, returtyp: tuple): Returnerar högsta temperatur och dag(ar) den inträffade
    public (int[] days, int temperature) GetMaxTemperature()
    {
        int maxTemperature = temperatures.Max();
        int[] daysWithMaxTemp = temperatures
            .Select((temp, index) => temp == maxTemperature ? index + 1 : -1)
            .Where(day => day != -1)
            .ToArray();

        return (daysWithMaxTemp, maxTemperature);
    }

    // METOD (utan parameter, returtyp: tuple): Returnerar lägsta temperatur och dag(ar) den inträffade
    public (int[] days, int temperature) GetMinTemperature()
    {
        int minTemperature = temperatures.Min();
        int[] daysWithMinTemp = temperatures
            .Select((temp, index) => temp == minTemperature ? index + 1 : -1)
            .Where(day => day != -1)
            .ToArray();

        return (daysWithMinTemp, minTemperature);
    }

    // METOD (utan parameter, returtyp: double): Returnerar mediantemperaturen
    public double GetMedianTemperature()
    {
        var sortedTemperatures = temperatures.OrderBy(t => t).ToArray();
        int middleIndex = sortedTemperatures.Length / 2;

        if (sortedTemperatures.Length % 2 == 0)
        {
            return (sortedTemperatures[middleIndex - 1] + sortedTemperatures[middleIndex]) / 2.0;
        }
        else
        {
            return sortedTemperatures[middleIndex];
        }
    }

    // METOD (med parameter, returtyp: void): Sorterar temperaturer i stigande eller fallande ordning
    public void SortTemperatures(bool ascending = true)
    {
        if (ascending)
        {
            Array.Sort(temperatures);
        }
        else
        {
            Array.Sort(temperatures, (a, b) => b.CompareTo(a));
        }
    }

    // METOD (med parameter, returtyp: void): Skriver ut temperaturer över ett visst tröskelvärde
    public void DisplayFilteredTemperatures(int threshold)
    {
        var filteredTemperatures = temperatures.Where(t => t > threshold);

        foreach (var temperature in filteredTemperatures)
        {
            Console.WriteLine($"{temperature}°C");
        }
    }

    // METOD (med parameter, returtyp: void): Skriver ut temperaturen för en viss dag samt intilliggande dagar
    public void DisplayTemperatureForDay(int day)
    {
        if (day < 1 || day > 31)
        {
            Console.WriteLine("Ogiltig dag. Välj en dag mellan 1 och 31.");
            return;
        }

        int selectedDayTemp = temperatures[day - 1];
        Console.WriteLine($"Dag {day}: {selectedDayTemp}°C");

        if (day > 1)
        {
            int previousDayTemp = temperatures[day - 2];
            Console.WriteLine($"Föregående dag ({day - 1}): {previousDayTemp}°C");
        }

        if (day < 31)
        {
            int nextDayTemp = temperatures[day];
            Console.WriteLine($"Nästa dag ({day + 1}): {nextDayTemp}°C");
        }
    }

    // METOD (utan parameter, returtyp: int): Returnerar den vanligast förekommande temperaturen
    public int GetMostFrequentTemperature()
    {
        int mostFrequent = temperatures
            .GroupBy(t => t)
            .OrderByDescending(group => group.Count())
            .First().Key;

        return mostFrequent;
    }
}

// KLASS: Program innehåller startpunkten för programmet
class Program
{
    // METOD: Main är programmets startpunkt (returtyp: void)
    static void Main()
    {
        // OBJEKT: Skapar ett objekt av klassen TemperatureAnalyzer
        TemperatureAnalyzer analyzer = new TemperatureAnalyzer();

        Console.WriteLine("Temperaturer för maj månad:");
        analyzer.DisplayTemperatures();

        Console.WriteLine($"\nMedeltemperatur: {analyzer.GetAverageTemperature():F1}°C");

        var maxResult = analyzer.GetMaxTemperature();
        Console.WriteLine($"Högsta temperatur: {maxResult.temperature}°C (Dag/Dagar: {string.Join(", ", maxResult.days)})");

        var minResult = analyzer.GetMinTemperature();
        Console.WriteLine($"Lägsta temperatur: {minResult.temperature}°C (Dag/Dagar: {string.Join(", ", minResult.days)})");

        Console.WriteLine($"Mediantemperatur: {analyzer.GetMedianTemperature():F1}°C");
        Console.WriteLine($"Vanligast förekommande temperatur: {analyzer.GetMostFrequentTemperature()}°C");
    }
}