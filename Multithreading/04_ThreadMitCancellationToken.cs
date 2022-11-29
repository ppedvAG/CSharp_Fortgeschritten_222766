namespace Multithreading;

internal class _04_ThreadMitCancellationToken
{
	static void Main(string[] args)
	{
		CancellationTokenSource cts = new CancellationTokenSource(); //Sender
		CancellationToken ct = cts.Token; //Empfänger

		ParameterizedThreadStart pt = new ParameterizedThreadStart(Run);
		Thread t = new Thread(pt);
		t.Start(ct); //Hier Token weitergeben

		Thread.Sleep(2000);

		cts.Cancel(); //Alle Tokens an der Source canceln
	}

	static void Run(object o)
	{
		try
		{
			if (o is CancellationToken ct)
			{
				for (int i = 0; i < 100; i++)
				{
					Console.WriteLine($"Side Thread: {i}");
					Thread.Sleep(100);
					if (ct.IsCancellationRequested)
						ct.ThrowIfCancellationRequested(); //OperationCanceledException werfen um Thread zu beenden
				}
			}
		}
		catch (OperationCanceledException) //try/catch funktioniert nur hier unten
		{
			Console.WriteLine("Thread wurde abgebrochen");
		}
	}
}
