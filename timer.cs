using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var signal = GenerateSquareWave(500); // 500ms period for the square wave

        Console.WriteLine("Press Enter to start...");
        Console.ReadLine();

        var cancellationTokenSource = new CancellationTokenSource();

        // Start a task to simulate the square wave
        var task = Task.Run(() => SimulateSquareWave(signal, cancellationTokenSource.Token));

        Console.WriteLine("Press Enter to stop...");
        Console.ReadLine();

        // Cancel the task to stop the simulation
        cancellationTokenSource.Cancel();
        await task;
    }

    static IEnumerable<int> GenerateSquareWave(int periodMs)
    {
        while (true)
        {
            yield return 1;
            Thread.Sleep(periodMs / 2); // High for half the period

            yield return 0;
            Thread.Sleep(periodMs / 2); // Low for half the period
        }
    }

    static void SimulateSquareWave(IEnumerable<int> signal, CancellationToken token)
    {
        foreach (var state in signal)
        {
            if (token.IsCancellationRequested)
                break;

            Console.WriteLine($"Signal State: {state}");
        }
    }
}
