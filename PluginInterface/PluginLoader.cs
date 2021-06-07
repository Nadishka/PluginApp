using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PluginInterface;

namespace PluginInterface
{
    public class PluginLoader
    {
        public IList<Iplugin> LoadPlugins(string folder)
        {
            IList<Iplugin> plugins = new List<Iplugin>();

            string[] files = Directory.GetFiles(folder, "*Plugin.dll");
            foreach (string file in files)
            {
                Assembly assembly = Assembly.LoadFile(file);
                var types = assembly.GetExportedTypes();

                foreach (Type type in types)
                    if (type.GetInterfaces().Contains(typeof(Iplugin)))
                    {
                        object instance = Activator.CreateInstance(type);
                        plugins.Add(instance as Iplugin);
                    }
            }

            return plugins;
        }
    }
}
