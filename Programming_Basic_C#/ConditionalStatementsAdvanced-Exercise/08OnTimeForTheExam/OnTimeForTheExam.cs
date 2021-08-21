using System;

namespace _08OnTimeForTheExam
{
class OnTimeForTheExam
{
static void Main(string[] args)
{
    int hour = int.Parse(Console.ReadLine());
    int minute = int.Parse(Console.ReadLine());
    int hourArrive = int.Parse(Console.ReadLine());
    int minuteArrive = int.Parse(Console.ReadLine());
    hour = (hour * 60) + minute;
    hourArrive = (hourArrive * 60) + minuteArrive;
    int hourResult = 0;
    int minuteResult = 0;

    int totalResult = Math.Abs((hour - hourArrive));
    if (hour == hourArrive)
    {
        Console.WriteLine("On time");
    }
    else if (hour < hourArrive)
    {
        if (totalResult <= 59)
        {
            Console.WriteLine($"Late {totalResult} minutes after the start");
        }
        else
        {
            hourResult = totalResult / 60;
            minuteResult = totalResult % 60;
            Console.WriteLine($"Late {hourResult}:{minuteResult:d2} hours after the start");
        }


    }
    else if (hour > hourArrive)
    {
        if (totalResult <= 30 && totalResult > 0)
        {
            Console.WriteLine($"On time {totalResult} minutes before the start");
        }
        else if (totalResult > 30 && totalResult <= 59)
        {
            Console.WriteLine($"Early {totalResult} minutes before the start");
        }
        else
        {
            hourResult = totalResult / 60;
            minuteResult = totalResult % 60;
            Console.WriteLine($"Early {hourResult}:{minuteResult:d2} hours before the start");
        }

    }
}
}
}
