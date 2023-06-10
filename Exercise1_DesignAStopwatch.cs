using System;

public class Stopwatch
{
    private TimeSpan _duration;
    private DateTime _startDateTime = new DateTime();
    private DateTime _stopDateTime = new DateTime();
    private int isStartMethodRunTwice = 0;
    
    public void Start() 
    {
        isStartMethodRunTwice++;
        if (isStartMethodRunTwice <= 1)
        {
            _startDateTime = DateTime.Now;
        }
        else
        {
            throw new InvalidOperationException("Cannot start the stopwatch twice in a row");
        }
    }
    
    public void Stop() 
    {
        _stopDateTime = DateTime.Now;
        isStartMethodRunTwice--;
        _duration += _stopDateTime - _startDateTime;
    }
    
    public void GetDuration()
    {
        Console.WriteLine(_duration);
    }
}

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        //stopwatch.Start();
        System.Threading.Thread.Sleep(2000);
        stopwatch.Stop();
        stopwatch.Start();
        System.Threading.Thread.Sleep(10000);
        stopwatch.Stop();
        stopwatch.GetDuration();
    }
}