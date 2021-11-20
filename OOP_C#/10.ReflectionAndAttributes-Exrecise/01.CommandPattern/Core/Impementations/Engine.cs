using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core.Impementations
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpeter;
        public Engine(ICommandInterpreter commandInterpeter)
        {
            this.commandInterpeter = commandInterpeter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string result = this.commandInterpeter.Read(input);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }
    }
}
