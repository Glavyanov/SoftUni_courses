using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList rndList = new RandomList() { "ab", "cd", "ef", "gh" };
            Console.WriteLine(string.Join(' ',rndList));
            rndList.RandomString();
            Console.WriteLine(string.Join(' ',rndList));
        }
    }
}
