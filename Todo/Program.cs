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


            //Task taskA = new Task(1, "My first task", DateTime.Now);
            //Task taskB = new Task(2, "My second task", DateTime.Now.AddDays(30));
            //Task[] taskList = { taskA, taskB };

            ////Console.WriteLine(taskA.ToString());

            //string jsonString = JsonSerializer.Serialize(taskList);
            //Console.WriteLine(jsonString);

            //List<Task> taskListReturn = JsonSerializer.Deserialize<List<Task>>(jsonString);
            //Task taskC = new Task(3, "My third task", DateTime.Now.AddMinutes(45));
            //taskListReturn.Add(taskC);

            //foreach (Task t in taskListReturn)
            //{
            //    Console.WriteLine(t);
            //}


            Dictionary<string, TodoCommand> commands = new Dictionary<string, TodoCommand>();
            commands.Add("add", new subcommands.Add(args));
            commands.Add("show", new subcommands.Show(args));
            commands.Add("remove", new subcommands.Remove(args));
            commands.Add("purge", new subcommands.Purge(args));


            if (args.Length == 0 || args[0] == "help")
            {
                foreach (var cmd in commands)
                {
                    Console.WriteLine($"{cmd.Key}: {cmd.Value.GetSyntax()} -- {cmd.Value.GetHelp()}");
                }
                Environment.Exit(0);
            }

            if (!commands.ContainsKey(args[0]))
            {
                Console.WriteLine("Invalid command");
                // show help
                Environment.Exit(-1);
            }

            TodoCommand command = commands[args[0]];
            //Console.WriteLine(command.GetSyntax());
            //Console.WriteLine(command.GetHelp());

            bool commandResult = command.Execute();

            if (!commandResult)
            {
                Environment.Exit(-1);
            }


            //Console.ReadKey();
        }
    }
}
