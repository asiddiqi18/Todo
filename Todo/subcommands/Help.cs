using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.subcommands
{
    class Help : TodoCommand
    {

        Dictionary<string, TodoCommand> cmds;

        public Help(string[] args, Dictionary<string, TodoCommand> cmds) : base(args)
        {
            this.cmds = cmds;
        }

        public override bool Execute()
        {
            Console.WriteLine("{0, -10} {1, -35} {2, -35}", "Command", "Syntax", "Description");
            Console.WriteLine("{0, -10} {1, -35} {2, -35}", new string('-', 10), new string('-', 35), new string('-', 35));


            foreach (var cmd in cmds)
            {
                Console.WriteLine("{0, -10} {1, -35} {2, -35}", cmd.Key, cmd.Value.GetSyntax(), cmd.Value.GetHelp());
            }

            return true;
        }

        public override string GetHelp()
        {
            return "Shows a help menu to list all commands";
        }

        public override string GetSyntax()
        {
            return "todo help";
        }
    }
}
