namespace DelegatesEvents;

internal class ComponentWithEvent
{
	static void Main(string[] args)
	{
		Component c = new Component();
		c.ProcessCompleted += () => Console.WriteLine("Prozess fertig");
		c.ValueChanged += ValueChanged;
		c.StartProcess();
	}

	private static void ValueChanged(int i)
	{
		Console.WriteLine($"Zähler: {i}");
	}
}

public class Component
{
	public event Action ProcessCompleted; //Action statt EventHandler ist einfacher

	public event Action<int> ValueChanged;

	public void StartProcess()
	{
		for (int i = 0; i < 10; i++)
		{
			Thread.Sleep(200);
			ValueChanged(i);
		}
		ProcessCompleted();
	}
}
