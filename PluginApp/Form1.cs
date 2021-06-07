using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PluginInterface;

namespace PluginApp
{
    public partial class Form1 : Form
    {
        int i;
        public Form1()
        {
            InitializeComponent();
        }

        private PluginLoader _pluginLoader = new PluginLoader();

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = GetExecutionFolder();
            var plugins = _pluginLoader.LoadPlugins(path);

            if (plugins.Count == 0)
                MessageBox.Show("No Plugins found!");

            else
            {
                for (i = 0;i < 3; i++)
                {
                    foreach (Iplugin plugin in plugins)
                    {
                        if (plugin.Text == "Radius")
                        {
                            int top = (panel1.Controls.Count - 8) * 20 + i;
                            Label label = new Label() { Left = 350, Top = top };
                            label.Text = "Radius";
                            panel1.Controls.Add(label);
                            TrackBar trackbar = new TrackBar() { Left = 450, Top = top };
                            panel1.Controls.Add(trackbar);
                        }
                        else if (plugin.Text == "Size")
                        {
                            int top = (panel1.Controls.Count - 7) * 20 + i;
                            Label label = new Label() { Left = 350, Top = top };
                            label.Text = "Size";
                            panel1.Controls.Add(label);
                            TextBox textbox = new TextBox() { Width = 100, Height = 40, Left = 450, Top = top };
                            panel1.Controls.Add(textbox);
                        }
                        else
                        {
                            CheckBox checkbox = new CheckBox() { Left = 200, Top = (panel1.Controls.Count - 4) * 20 + i };
                            checkbox.Text = plugin.Text;
                            panel1.Controls.Add(checkbox);
                        }
                    }
                    Button button = new Button() { Width = 100, Height = 30, Left = 600, Top = (panel1.Controls.Count - 12) * 20 + i };
                    button.Text = "Apply";
                    //button.Name = i.ToString();
                    //button.Tag = button.Name;
                    //button.Click += new EventHandler(button_Click);
                    panel1.Controls.Add(button);
                }
            }
        }

        //void button_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show(button.Name + " Added");
        //}

        public string GetExecutionFolder()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}
