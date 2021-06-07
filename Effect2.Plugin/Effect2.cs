using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginInterface;

namespace Effect2.Plugin
{
    public class Effect2 : Iplugin
    {
        public string Text
        {
            get { return "Vintage Effect"; }
        }
    }
}
