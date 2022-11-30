using PluginBase;
using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace PluginClient
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string path = @"C:\Users\lk3\source\repos\CSharp_Fortgeschritten_2022_11_28\Plugin\bin\Debug\net6.0\Plugin.dll";
			Assembly a = Assembly.LoadFrom(path);
			Type pluginType = a.DefinedTypes.First(e => e.Name == "Plugin");
			ICalculatorPlugin plugin = Activator.CreateInstance(pluginType) as ICalculatorPlugin;
			//plugin.Addiere möglich
			SP.Children.RemoveRange(1, 100);
			foreach (MethodInfo m in pluginType.GetMethods())
			{
				Button b = new Button();
				b.Content = m.Name;
				b.Click += (sender, e) => m.Invoke(plugin, null);
				SP.Children.Add(b);
			}
		}
	}
}
