using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Undertale_WPF
{
    public class MainChar : Interface1
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
        [JsonProperty("maxHealth")] // specify actual name for MongoDB
        public int MaxHealth { get; set; }
        [JsonProperty("abilities")] // specify actual name for MongoDB
        public Dictionary<string, Ability> Abilities { get; set; }
        
        public MainChar()
        {

        }

        public MainChar(string? id, string name, List<string> appearances, string role, string status, int maxHealth, Dictionary<string, Ability> abilities)
        {
            this.Id = id;
            this.Name = name;
            this.Appearances = appearances;
            this.Role = role;
            this.Status = status;
            this.MaxHealth = maxHealth;
            this.Abilities = abilities;
        }

        public class Ability
        {
            [JsonProperty("name")] // specify actual name for MongoDB
            public string Name { get; set; }
            [JsonProperty("features")] // specify actual name for MongoDB
            public List<string> Features { get; set; }

            public Ability (string name, List<string> features)
            {
                this.Name = name;
                this.Features = features;
            }
        } 
    }
}
