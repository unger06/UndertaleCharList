using MongoDB.Driver.Core.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Undertale_WPF
{
    internal class Vendor : Interface1
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Appearances { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public List<string> Wares { get; set; }
        public Dictionary<string, Feature> Features { get; set; }

        public Vendor (string id, string name, List<string> appearances, string role, string status, List<string> wares, Dictionary<string, Feature> features)
        {
            this.Id = id;
            this.Name = name;
            this.Appearances = appearances;
            this.Role = role;
            this.Status = status;
            this.Wares = wares;
            this.Features = features;
        }

        public class Feature
        {
            public string Name { get; set;}
            public string Type { get; set;}
            public List<int> Price { get; set; }
            public int? Heal { get; set; }
            public int? Sell { get; set; }
            public int? Attack { get; set; }
            public int? Defense { get; set; }
            public string? Extras { get; set; }

            public Feature (string name, string type, List<int> price, int? heal, int? sell, int? attack, int? defense, string? extras)
            {
                this.Name = name;
                this.Type = type;
                this.Price = price;
                this.Heal = heal;
                this.Sell = sell;
                this.Attack = attack;
                this.Defense = defense;
                this.Extras = extras;
            }
        }
    }
}
