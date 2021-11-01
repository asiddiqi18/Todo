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
            Dictionary<int, Task> tasks = JSONToDict();
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

        public Dictionary<int, Task> JSONToDict()
        {
            try
            {
                string readJSON = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<Dictionary<int, Task>>(readJSON);
            }
            catch (Exception e)
            {
                if (e is FileNotFoundException || e is JsonException)
                {
                    return new Dictionary<int, Task>();
                } else
                {
                    throw;
                }
            }
        }

        public bool WriteJSON(Dictionary<int, Task> dict)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string writeJSON = JsonSerializer.Serialize(dict, options);
            File.WriteAllText(FileName, writeJSON);
            return true;
        }

        public bool ClearJSON()
        {
            File.WriteAllText(FileName, string.Empty);
            return true;
        }

    }
}
