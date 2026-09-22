using System;

class TimeDuration
{
    public int Hours { get; set; }
    public int Minutes { get; set; }

    public TimeDuration(int hours, int minutes)
    {
        Hours = hours;
        Minutes = minutes;

        NormalizeTime();
    }

    private void NormalizeTime()
    {
        if (Minutes >= 60)
        {
            Hours = Hours + (Minutes / 60);
            Minutes = Minutes % 60;
        }
    }

    // Binary operator overloading for adding two time values
    public static TimeDuration operator +(
        TimeDuration firstTime,
        TimeDuration secondTime)
    {
        int totalHours = firstTime.Hours + secondTime.Hours;
        int totalMinutes = firstTime.Minutes + secondTime.Minutes;

        return new TimeDuration(totalHours, totalMinutes);
    }

    // Unary operator overloading for adding one minute
    public static TimeDuration operator ++(TimeDuration time)
    {
        return new TimeDuration(time.Hours, time.Minutes + 1);
    }

    public void DisplayTime()
    {
        Console.WriteLine($"{Hours:D2}:{Minutes:D2}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("TIME ADDITION USING OPERATOR OVERLOADING");
        Console.WriteLine("========================================");

        TimeDuration firstSession = new TimeDuration(2, 45);
        TimeDuration secondSession = new TimeDuration(1, 35);

        Console.Write("First session time  : ");
        firstSession.DisplayTime();

        Console.Write("Second session time : ");
        secondSession.DisplayTime();

        TimeDuration totalTime = firstSession + secondSession;

        Console.Write("Total time          : ");
        totalTime.DisplayTime();

        firstSession++;

        Console.Write("First session after adding one minute : ");
        firstSession.DisplayTime();
    }
}