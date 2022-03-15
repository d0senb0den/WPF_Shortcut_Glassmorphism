using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Shortcut_Glassmorphism
{
    public class Shortcut
    {
        public string Command { get; set; }
        public string Description { get; set; }

        public Shortcut(string command, string description)
        {
            Command = command;
            Description = description;
        }
    }
}
