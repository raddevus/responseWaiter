using System;
using System.Globalization;
using System.Timers;

class Program
{
    private static DateTime inputDateTime;
    private static System.Timers.Timer timer;
    private static TimeSpan elapsed;

    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide a date and time as a command line argument.");
            Console.WriteLine("Format: yyyy-MM-dd HH:mm:ss");
            return;
        }

        if (!DateTime.TryParseExact(args[0], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture,
                                     DateTimeStyles.None, out inputDateTime))
        {
            Console.WriteLine("Invalid date and time format.");
            Console.WriteLine("Use: yyyy-MM-dd HH:mm:ss (e.g., 2023-05-10 14:30:00)");
            return;
        }

        Console.WriteLine($"Tracking time since: {inputDateTime}");
        Console.WriteLine("Press Enter to exit...");
        DisplayElapsedTime();
        timer = new System.Timers.Timer(5000); // 5 seconds
        timer.Elapsed += TimerElapsed;
        timer.AutoReset = true;
        timer.Enabled = true;

        Console.ReadLine(); // Keeps the app running without blocking the timer
    }

    private static void DisplayElapsedTime(){

        elapsed = DateTime.Now - inputDateTime;

        string output = $"Elapsed: {elapsed.Days} days, {elapsed.Hours} hours, {elapsed.Minutes} minutes, {elapsed.Seconds} seconds";
        Console.WriteLine(output);
    }

    private static void TimerElapsed(object sender, ElapsedEventArgs e)
    {
       DisplayElapsedTime();
    }
}
