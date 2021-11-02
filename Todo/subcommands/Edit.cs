using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.subcommands
{
    class Edit : TodoCommand
    {
        public Edit(string[] args) : base(args)
        {
        }
        public override bool Execute()
        {

            if (Args.Length != 3)
            {
                Console.WriteLine("Expected 2 args: " + GetSyntax());
                return false;
            }

            int ID;
            try
            {
                ID = int.Parse(Args[1]);
            }
            catch (FormatException)
            {
                return false;
            }

            string message = Args[2];

            Task task;

            try
            {
                task = parser.GetTaskByID(ID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            var tasks = parser.TaskDict;
            tasks[ID].Description = message;
            parser.WriteJSON(tasks);

            Console.WriteLine($"Successfully edited task {ID}");

            return true;

        }

        public override string GetHelp()
        {
            return "Edits a task given its ID";
        }

        public override string GetSyntax()
        {
            return "todo edit <id> <new message>";
        }
    }
}
