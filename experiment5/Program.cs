using System;
using System.Threading;

class Program
{
    static void DisplayEvenNumbers()
    {
        for (int number = 2; number <= 10; number = number + 2)
        {
            Console.WriteLine(
                $"Even Number Thread: {number}");

            Thread.Sleep(500);
        }
    }

    static void DisplayOddNumbers()
    {
        for (int number = 1; number <= 10; number = number + 2)
        {
            Console.WriteLine(
                $"Odd Number Thread : {number}");

            Thread.Sleep(500);
        }
    }

    static void Main()
    {
        Console.WriteLine("PARALLEL TASK PROCESSING");
        Console.WriteLine("========================");

        Thread evenNumberThread =
            new Thread(DisplayEvenNumbers);

        Thread oddNumberThread =
            new Thread(DisplayOddNumbers);

        Console.WriteLine("\nStarting both threads...\n");

        evenNumberThread.Start();
        oddNumberThread.Start();

        evenNumberThread.Join();
        oddNumberThread.Join();

        Console.WriteLine(
            "\nBoth threads completed their work.");
    }
}