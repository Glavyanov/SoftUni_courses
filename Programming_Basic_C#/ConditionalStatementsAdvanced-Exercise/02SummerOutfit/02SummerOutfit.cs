﻿using System;

namespace _02SummerOutfit
{
class Program
{
static void Main(string[] args)
{
    int degrees = int.Parse(Console.ReadLine());
    string dayTime = Console.ReadLine();
    string outfit = "";
    string shoes = "";
    if (degrees >= 25)
    {
        switch (dayTime)
        {
            case "Morning":
                outfit = "T-Shirt";
                shoes = "Sandals";
                break;
            case "Afternoon":
                outfit = "Swim Suit";
                shoes = "Barefoot";
                break;
            case "Evening":
                outfit = "Shirt";
                shoes = "Moccasins";
                break;
            default:
                break;
        }
    }
    else if (degrees > 18 && degrees <= 24)
    {
        switch (dayTime)
        {
            case "Morning":
                outfit = "Shirt";
                shoes = "Moccasins";
                break;
            case "Afternoon":
                outfit = "T-Shirt";
                shoes = "Sandals";
                break;
            case "Evening":
                outfit = "Shirt";
                shoes = "Moccasins";
                break;
            default:
                break;
        }

    }
    else
    {
        switch (dayTime)
        {
            case "Morning":
                outfit = "Sweatshirt";
                shoes = "Sneakers";
                break;
            case "Afternoon":
                outfit = "Shirt";
                shoes = "Moccasins";
                break;
            case "Evening":
                outfit = "Shirt";
                shoes = "Moccasins";
                break;
            default:
                break;
        }
    }
    Console.WriteLine("It's {0} degrees, get your {1} and {2}.", degrees, outfit, shoes);
}
}
}
