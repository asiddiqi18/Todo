using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.subcommands
{
    class Search : TodoCommand
    {
        public Search(string[] args) : base(args)
        {
        }
        public override bool Execute()
        {
            string query = Args[1];

            SortedDictionary<int, Task> matches = parser.FilterJSON(query);

            int matchCount = matches.Count;

            if (matchCount == 0) {
                Console.WriteLine($"No results for '{query}'");
                return true;
            }

            Console.Write($"Found {matchCount} ");
            if (matchCount > 1)
            {
                Console.WriteLine("matches");
            } else
            {
                Console.WriteLine("match");
            }

            foreach (var match in matches)
            {
                Console.WriteLine($"{match.Key} -- {match.Value.Description}");
            }

            return true;
        }

        public override string GetHelp()
        {
            return "Search for a task";
        }

        public override string GetSyntax()
        {
            return "todo search <query>";
        }
    }
}
