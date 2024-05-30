using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using PluginInterface;

namespace PluginArchitectureApp
{
    public partial class MainForm : Form
    {
        private IPlugin loadedPlugin = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadPlugin(string path)
        {
            var assembly = Assembly.LoadFile(path);
            var pluginType = assembly.GetTypes().FirstOrDefault(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);
            if (pluginType != null)
            {
                loadedPlugin = (IPlugin)Activator.CreateInstance(pluginType);
                loadedPlugin.Initialize();
                MessageBox.Show("Plugin loaded successfully.");
            }
            else
            {
                MessageBox.Show("No valid plugin found in the selected file.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "DLL files (*.dll)|*.dll";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadPlugin(openFileDialog.FileName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (loadedPlugin != null)
            {
                MessageBox.Show($"Plugin '{loadedPlugin.Name}' is loaded.");
            }
            else
            {
                MessageBox.Show("No plugin is loaded.");
            }
        }
    }
}
