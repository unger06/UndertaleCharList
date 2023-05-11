using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Undertale_WPF
{
    internal class Npc : Interface1
    {

        public string Id { get; set; }
        [JsonProperty("name")] // specify actual name for MongoDB
        public string Name { get; set; }
        [JsonProperty("appearances")] // specify actual name for MongoDB
        public List<string> Appearances { get; set; }
        [JsonProperty("role")] // specify actual name for MongoDB
        public string Role { get; set; }
        [JsonProperty("status")] // specify actual name for MongoDB
        public string Status { get; set; }

        public Npc()
        {

        }
        public Npc (string? id, string name, List<string> appearances, string role, string status)
        {
            this.Id = id;
            this.Name = name;
            this.Appearances = appearances;
            this.Role = role;
            this.Status = status;
        }
    }
}
