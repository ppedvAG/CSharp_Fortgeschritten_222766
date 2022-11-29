namespace Multitasking;

internal class _05_ContinueWith
{
	static void Main(string[] args)
	{
		Task<double> t1 = Task.Run(() =>
		{
			Thread.Sleep(1000);
			return Math.Pow(4, 23);
		});
		t1.ContinueWith(task => Console.WriteLine(task.Result)); //Tasks verketten, Code wird ausgeführt wenn originaler Task fertig, Variable des vorherigen Tasks inkludiert
		t1.ContinueWith(task => Console.WriteLine(task.Result * 2), TaskContinuationOptions.OnlyOnRanToCompletion); //Dieser Pfad wird betreten wenn keine Exception aufgetreten ist, es können auch mehrere Folgetasks ausgeführt werden
		t1.ContinueWith(task => Console.WriteLine("Exception"), TaskContinuationOptions.OnlyOnFaulted); //Wird ausgeführt bei Exception
		t1.ContinueWith(task => Console.WriteLine(), TaskContinuationOptions.NotOnFaulted); //Wenn keine Unhandled Exception

		Console.ReadKey();
	}
}
