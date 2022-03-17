using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Shortcut_Glassmorphism
{
    public class Shortcut
    {
        public string[] Keys { get; set; }
        public string Description { get; set; }

        public Shortcut(string description, params string[] keys)
        {
            Keys = keys;
            Description = description;
        }
    }
}
