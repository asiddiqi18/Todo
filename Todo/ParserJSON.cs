using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Todo
{
    class ParserJSON
    {
        public string FileName { get; set; }
        public int NextID { get; set; }

        public SortedDictionary<int, Task> TaskDict;

        public void DetermineNextHighestID()
        {
            SortedDictionary<int, Task> tasks = GetTaskDict();
            List<int> keyList = new List<int>(tasks.Keys);
            if (keyList.Count == 0)
            {
                NextID = 0;
            }
            else
            {
                NextID = keyList.Max();
            }
        }

        public ParserJSON(string fileName)
        {
            FileName = fileName;
            DetermineNextHighestID();
        }

        public SortedDictionary<int, Task> GetTaskDict()
        {
            if (TaskDict == null)
            {
                JSONToDict();
            }
            return TaskDict;
        }

        private void JSONToDict()
        {
            try
            {
                string readJSON = File.ReadAllText(FileName);
                TaskDict = JsonSerializer.Deserialize<SortedDictionary<int, Task>>(readJSON);
            }
            catch (Exception e)
            {
                if (e is FileNotFoundException || e is JsonException)
                {
                    TaskDict = new SortedDictionary<int, Task>();
                }
                else
                {
                    throw;
                }
            }
        }

        public bool WriteJSON(SortedDictionary<int, Task> dict)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string writeJSON = JsonSerializer.Serialize(dict, options);
            File.WriteAllText(FileName, writeJSON);
            TaskDict = dict;
            return true;
        }

        public SortedDictionary<int, Task> FilterJSON(string query)
        {
            SortedDictionary<int, Task> tasks = GetTaskDict();
            SortedDictionary<int, Task> matches = new SortedDictionary<int, Task>();

            if (tasks.Count == 0)
            {
                return matches;
            }

            foreach (var task in tasks)
            {
                if (task.Value.Description.Contains(query))
                {
                    matches[task.Key] = task.Value;
                }
            }

            return matches;
        }

        public bool ClearJSON()
        {
            File.WriteAllText(FileName, string.Empty);
            return true;
        }

        public Task GetTaskByID(int ID)
        {
            SortedDictionary<int, Task> tasks = GetTaskDict();

            if (ID < 1)
            {
                throw new ArgumentException("Task ID's must be at least 1");
            }

            if (!tasks.ContainsKey(ID))
            {
                throw new ArgumentException($"ID {ID} is not found");
            }

            return tasks[ID];

        }

    }
}
