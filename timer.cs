using System;
using System.Timers;

class Program
{
    static int signalState = 0; // Initial state of the signal
    static Timer timer;

    static void Main()
    {
        timer = new Timer(500); // Set the interval to 500ms (1Hz square wave)
        timer.Elapsed += OnTimedEvent; // Subscribe to the Elapsed event
        timer.AutoReset = true; // Make the timer repeat
        timer.Enabled = true; // Start the timer

        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine(); // Wait for the user to press Enter to stop the program
    }

    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        signalState = 1 - signalState; // Toggle between 0 and 1
        Console.WriteLine($"Signal State: {signalState}");
    }
}
