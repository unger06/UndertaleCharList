using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Undertale_WPF
{
    public class ItemsCB
    {
        public List<string> Items { get; set; }
        public List<string> Appearances { get; set; }

        public ItemsCB(List<string> items)
        {
            this.Items = items;
            this.Appearances = new List<string>();
        }
    }
}
