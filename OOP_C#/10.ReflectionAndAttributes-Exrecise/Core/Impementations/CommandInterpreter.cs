using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Impementations
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {

            string[] cmdArgs = args.Split();
            string commandName = $"{cmdArgs[0]}Command";
            string[] parameters = cmdArgs.Skip(1).ToArray();
            string result = string.Empty;
            ICommand command = null;
            Type type = Assembly.GetCallingAssembly().GetTypes().Where(t => t.Name == commandName).FirstOrDefault();
            if (type == null)
            {
                throw new InvalidOperationException("Invalid command");
            }
            command = (ICommand)Activator.CreateInstance(type);
            //if (commandName == nameof(HelloCommand))
            //{
            //    command = new HelloCommand();
            //}
            //else if (commandName == nameof(ExitCommand))
            //{
            //    command = new ExitCommand();
            //}
            //else
            //{
            //    throw new InvalidOperationException("Invalid command");
            //}
            result = command.Execute(parameters);
            return result;

        }
    }
}
