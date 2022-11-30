using System.Reflection;

namespace Reflection;

internal class Program
{
	static void Main(string[] args)
	{
		Program p = new Program();
		Type pt = p.GetType(); //Typ holen mit GetType() über Objekt

		Type t = typeof(Program); //Typ holen durch typeof(<Klassenname>)

		object o = Activator.CreateInstance(t); //Objekte erstellen über Type

		t.GetMethods(); //Alle Methoden anzeigen
		t.GetMethod("Test").Invoke(p, null); //Methode über Reflection ausführen

		t.GetMethod("Test2").Invoke(p, new[] { "Zwei Test" }); //Methode mit Parameter ausführen

		t.GetField("EineZahl").SetValue(p, 5); //Variable setzen
		Console.WriteLine(t.GetField("EineZahl").GetValue(p)); //Variable holen

		t.GetProperty("EinText").SetValue(p, "Test"); //Property setzen
		Console.WriteLine(t.GetProperty("EinText").GetValue(p));

		object o2 = Activator.CreateInstance("Reflection", "Reflection.Program"); //Objekt erstellen nur über strings

		Assembly a = Assembly.GetExecutingAssembly(); //Informationen über das derzeitige Projekt erhalten

		List<TypeInfo> types = a.DefinedTypes.ToList(); //Alle Typen aus einem Assembly holen

		string path = @"C:\Users\lk3\source\repos\CSharp_Fortgeschritten_2022_11_28\DelegatesEvents\bin\Debug\net6.0\DelegatesEvents.dll";

		Assembly de = Assembly.LoadFrom(path);

		List<TypeInfo> deTypes = de.DefinedTypes.ToList();

		object comp = Activator.CreateInstance(deTypes.First(e => e.Name == "Component"));
		comp.GetType().GetEvent("ValueChanged").AddEventHandler(comp, (int i) => Console.WriteLine($"Zähler: {i}"));
		comp.GetType().GetEvent("ProcessCompleted").AddEventHandler(comp, () => Console.WriteLine("Fertig"));
		comp.GetType().GetMethod("StartProcess").Invoke(comp, null);
	}

	public int EineZahl;

	public string EinText { get; set; }

	public void Test() => Console.WriteLine("Ein Test");

	public void Test2(string test) => Console.WriteLine(test);
}