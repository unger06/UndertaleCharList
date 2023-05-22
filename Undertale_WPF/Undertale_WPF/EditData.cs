using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Undertale_WPF
{
    class EditData
    {
        public string Name { get; set; }
        public List<string> Appearances { get; set; }
        public ItemsCB ItemsCBAppearance { get; set; }

        public EditData()
        {
            this.Name = string.Empty;
            this.Appearances = new List<string>();
            List<string> appearances = new List<string> { "Ruins", "Snowdin", "Waterfall", "Hotland", "The Core", "New Home" };
            ItemsCBAppearance = new ItemsCB(appearances);
        }
    }
}
