using System;
using System.Globalization;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide a date and time as a command line argument.");
            Console.WriteLine("Format: yyyy-MM-dd HH:mm:ss");
            return;
        }

        if (!DateTime.TryParseExact(args[0], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture,
                                     DateTimeStyles.None, out DateTime inputDateTime))
        {
            Console.WriteLine("Invalid date and time format.");
            Console.WriteLine("Use: yyyy-MM-dd HH:mm:ss (e.g., 2023-05-10 14:30:00)");
            return;
        }

        Console.WriteLine($"Tracking time since: {inputDateTime}");

        while (true)
        {
            TimeSpan elapsed = DateTime.Now - inputDateTime;

            string output = $"Elapsed: {elapsed.Days} days, {elapsed.Hours} hours, {elapsed.Minutes} minutes, {elapsed.Seconds} seconds";
            Console.WriteLine(output);

            Thread.Sleep(5000); // Wait 5 seconds
        }
    }
}

