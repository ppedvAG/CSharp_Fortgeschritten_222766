using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncAwaitWPF;

public partial class MainWindow : Window
{
	public MainWindow() => InitializeComponent();

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Progress.Value = 0;
		for (int i = 0; i < 100; i++)
		{
			Thread.Sleep(25);
			Progress.Value++;
		} //Thread.Sleep verhindert UI Updates
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		Task.Run(() =>
		{
			Dispatcher.Invoke(() => Progress.Value = 0);
			for (int i = 0; i < 100; i++)
			{
				Thread.Sleep(25);
				Dispatcher.Invoke(() => Progress.Value++);
			}
		});
	}

	private async void Button_Click_2(object sender, RoutedEventArgs e)
	{
		Progress.Value = 0;
		for (int i = 0; i < 100; i++)
		{
			await Task.Delay(25);
			Progress.Value++;
		} //funktioniert auch ohne Dispatcher.Invoke
	}

	private async void Button_Click_3(object sender, RoutedEventArgs e)
	{
		using HttpClient client = new(); //mit using anlegen da IDisposable
		HttpResponseMessage resp = await client.GetAsync(@"http://www.gutenberg.org/files/54700/54700-0.txt"); //Get Request machen mit await
		string content = await resp.Content.ReadAsStringAsync();
		TB.Text = content;
	}

	private async void Button_Click_4(object sender, RoutedEventArgs e)
	{
		List<int> ints = Enumerable.Range(0, 100).ToList(); //Schnell eine int Liste von 0-99 generieren
		await Parallel.ForEachAsync(ints, (item, ct) => //item: Derzeitige Zahl, ct: CancellationToken, kann ignoriert werden
		{
			Dispatcher.Invoke(() => TB.Text += item * 10 + "\n");
			return ValueTask.CompletedTask; //Leeren Task returnen, muss man wissen
		});
	}
}
