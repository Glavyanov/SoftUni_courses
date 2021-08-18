using System;

namespace BirthdayParty
{
class BirthdayParty
{
static void Main(string[] args)
{
    double rent = double.Parse(Console.ReadLine());

    double cake = rent * 0.2;
    double drinks = cake - cake * 0.45;
    double animator = rent / 3 ;
    Console.WriteLine(rent + cake + drinks + animator);

}
}
}
