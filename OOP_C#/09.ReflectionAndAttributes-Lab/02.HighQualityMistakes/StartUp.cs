using System;
using System.Text;

namespace Stealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            Spy spy = new Spy();
            string result = spy.AnalyzeAccessModifiers("Stealer.Hacker");
            Console.WriteLine(result);

        }
    }
}
