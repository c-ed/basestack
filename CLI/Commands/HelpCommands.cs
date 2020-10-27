using System;

namespace BaseStack.CLI.Commands
{
    public class HelpCommands
    {
        public void Help()
        {
            Console.WriteLine("Help");
        }

        public void OtherHelp(string arg1, string arg2)
        {
            Console.WriteLine($"Hello arg1: {arg1} arg2: {arg2}");
        }
    }
}
