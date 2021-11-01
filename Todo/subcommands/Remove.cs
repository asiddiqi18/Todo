using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.subcommands
{
    class Remove : TodoCommand
    {
        public Remove(string[] args) : base(args)
        {
        }
        public override bool Execute()
        {
            int ID;
            try
            {
                ID = int.Parse(Args[1]);
            } catch (FormatException)
            {
                Console.WriteLine($"Unable to parse {Args[1]} as a number");
                return false;
            }

            if (ID < 1)
            {
                Console.WriteLine("Task ID's must be at least 1");
                return false;
            }

            Dictionary<int, Task> tasks = parser.JSONToDict();
            if (!tasks.ContainsKey(ID))
            {
                Console.WriteLine($"ID {ID} is not found");
                return false;
            }

            for (int i = ID; i < parser.NextID; i++)
            {
                tasks[i + 1].ID = i;
                tasks[i] = tasks[i + 1];
            }

            tasks.Remove(parser.NextID);

            parser.NextID -= 1;

            parser.WriteJSON(tasks);

            Console.WriteLine($"Successfully deleted task #{ID}");

            return true;
        }

        public override string GetHelp()
        {
            return "Removes a selected task by its ID";
        }

        public override string GetSyntax()
        {
            return "todo remove <id>";
        }
    }
}
