using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Todo.subcommands
{
    class Add : TodoCommand
    {
        public Add(string[] args) : base(args)
        {
        }

        public override bool Execute()
        {
            string message = Args[1];
            Task newTask = new Task(1, message, DateTime.Now);

            SortedDictionary<int, Task> tasks = parser.GetTaskDict();

            parser.NextID += 1;
            newTask.ID = parser.NextID;
            tasks[parser.NextID] = newTask;

            parser.WriteJSON(tasks);

            Console.WriteLine($"Successfully created a new task -- ({message})");

            return true;
        }

        public override string GetHelp()
        {
            return "Adds an item to your todo list";
        }

        public override string GetSyntax()
        {
            return "todo add <todo message>";
        }
    }
}
