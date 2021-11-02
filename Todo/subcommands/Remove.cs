using System;
using System.Collections.Generic;
using System.Linq;

namespace Todo.subcommands
{
    internal class Remove : TodoCommand
    {
        public Remove(string[] args) : base(args)
        {
        }

        public override bool Execute()
        {
            try
            {
                int[] ID = { int.Parse(Args[1]) };
                return RemoveByID(ID);
            }
            catch (FormatException)
            {
                string query = Args[1];
                return RemoveByQuery(query);
            }
        }

        public override string GetHelp()
        {
            return "Removes a selected task by its ID";
        }

        public override string GetSyntax()
        {
            return "todo remove <id>";
        }

        private bool RemoveByID(int[] IDs)
        {
            SortedDictionary<int, Task> tasks = parser.GetTaskDict();

            foreach (int ID in IDs)
            {
                if (ID < 1)
                {
                    Console.WriteLine("Task ID's must be at least 1");
                    return false;
                }

                if (!tasks.ContainsKey(ID))
                {
                    Console.WriteLine($"ID {ID} is not found");
                    return false;
                }

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

                parser.NextID -= 1;

                Console.WriteLine($"Successfully deleted task #{ID} ({task.Description})");
                tasks.Remove(ID);
            }

            InSequence(ref tasks);

            parser.WriteJSON(tasks);

            return true;
        }

        private bool RemoveByQuery(string query)
        {
            int[] tasks = parser.FilterJSON(query).Keys.ToArray();

            RemoveByID(tasks);

            return true;
        }

        private static void InSequence(ref SortedDictionary<int, Task> tasks)
        {
            List<int> keyList = new List<int>(tasks.Keys);
            int nextExpected = 1;
            foreach (var i in keyList)
            {
                if (i != nextExpected)
                {
                    tasks[nextExpected] = tasks[i];
                    tasks.Remove(i);
                }
                nextExpected += 1;
            }

        }

    }
}