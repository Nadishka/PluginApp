using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginInterface;

namespace Effect1.Plugin
{
    public class Effect1 : Iplugin
    {
        public string Text
        {
            get { return "Blur Effect"; }
        }
    }
}
