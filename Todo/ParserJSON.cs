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



        public void DetermineNextHighestID()
        {
            SortedDictionary<int, Task> tasks = JSONToDict();
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

        public SortedDictionary<int, Task> JSONToDict()
        {
            try
            {
                string readJSON = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<SortedDictionary<int, Task>>(readJSON);
            }
            catch (Exception e)
            {
                if (e is FileNotFoundException || e is JsonException)
                {
                    return new SortedDictionary<int, Task>();
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
            return true;
        }

        public SortedDictionary<int, Task> FilterJSON(string query)
        {
            SortedDictionary<int, Task> tasks = JSONToDict();
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

    }
}
