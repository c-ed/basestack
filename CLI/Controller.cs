using System;
using System.Linq;
using System.Reflection;
using BaseStack.CLI.Model;
using Microsoft.Extensions.Options;

namespace BaseStack.CLI
{
    public class Controller
    {
        private readonly AppSettings _settings;

        public Controller(IOptions<AppSettings> options)
        {
            _settings = options.Value;
        }

        public void Operate(string[] args)
        {
            var command = FindCommand(args.Any() ? args.First() : "help");
            RouteCommand(command, args.Skip(1).ToArray());
        }

        private void RouteCommand(Command command, string[] args)
        {
            var commandType = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(p =>
                p.Name.Equals(command.Class, StringComparison.OrdinalIgnoreCase));

            if (commandType == null)
                throw new Exception($"No type found for '{command.Class}'");

            var instance = Activator.CreateInstance(commandType);
            var method = instance.GetType().GetMethod(command.Method, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
            var parameters = method.GetParameters();

            if (args.Length != parameters.Length)
                throw new Exception($"The '{command.Name}' command expects {parameters.Length} arguments");

            method.Invoke(instance, args);
        }

        private Command FindCommand(string commandName)
        {
            var command = _settings.Commands.SingleOrDefault(p => p.Name.Equals(commandName, StringComparison.OrdinalIgnoreCase));
            if (command == null)
                throw new Exception($"'{commandName}' is not a valid command");

            return command;
        }
    }
}
