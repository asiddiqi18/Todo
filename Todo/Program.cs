using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Todo
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, TodoCommand> commands = new Dictionary<string, TodoCommand>();
            commands.Add("add", new subcommands.Add(args));
            commands.Add("show", new subcommands.Show(args));
            commands.Add("remove", new subcommands.Remove(args));
            commands.Add("purge", new subcommands.Purge(args));
            commands.Add("search", new subcommands.Search(args));
            commands.Add("edit", new subcommands.Edit(args));
            commands.Add("help", new subcommands.Help(args, commands));



            if (args.Length == 0)
            {
                commands["help"].Execute();
                Environment.Exit(0);
            }

            if (!commands.ContainsKey(args[0]))
            {
                Console.WriteLine("Invalid command");
                // show help
                commands["help"].Execute();
                Environment.Exit(-1);
            }

            TodoCommand command = commands[args[0]];

            bool commandResult = command.Execute();

            if (!commandResult)
            {
                Environment.Exit(-1);
            }


            //Console.ReadKey();
        }
    }
}
