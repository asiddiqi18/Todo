using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.subcommands
{
    class Show : TodoCommand
    {
        public Show(string[] args) : base(args)
        {
        }
        public override bool Execute()
        {
            SortedDictionary<int, Task> tasks = parser.GetTaskDict();

            if (tasks.Count == 0)
            {
                Console.WriteLine("You don't have any tasks");
                return true;
            }

            foreach(var task in tasks)
            {
                Console.WriteLine($"{task.Key} -- {task.Value.Description}");
            }
            return true;
        }

        public override string GetHelp()
        {
            return "Shows all of your tasks";
        }

        public override string GetSyntax()
        {
            return "todo show";
        }
    }
}
