using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Todo
{
    class Task
    {
        public Task(int id, string description, DateTime date)
        {
            ID = id;
            Description = description;
            Date = date;
        }

        [JsonIgnore]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public static int HighestID { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} ID: {ID}, Description: {Description}, Date: {Date}";
        }

    }
}
