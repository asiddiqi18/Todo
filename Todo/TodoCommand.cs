using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    abstract class TodoCommand
    {
        protected TodoCommand(string[] args)
        {
            Args = args;
            parser = new ParserJSON(@"c:\temp\Task.json");
        }


        public ParserJSON parser;
        public abstract string GetHelp();
        public abstract string GetSyntax();
        public abstract bool Execute();
        public string[] Args { get; }


    }
}
