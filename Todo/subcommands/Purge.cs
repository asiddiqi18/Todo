using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.subcommands
{
    class Purge : TodoCommand
    {
        public Purge(string[] args) : base(args)
        {
        }
        public override bool Execute()
        {
            int taskCount = parser.NextID;
            if (taskCount == 0)
            {
                Console.WriteLine("You don't have any tasks to purge!");
                return false;
            }
            parser.ClearJSON();
            parser.NextID = 1;
            Console.WriteLine($"You have successfully purged all tasks (removed {taskCount}).");
            return true;
        }

        public override string GetHelp()
        {
            return "Removes all tasks";
        }

        public override string GetSyntax()
        {
            return "tasks purge";
        }
    }
}
