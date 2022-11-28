namespace DelegatesEvents;

internal class Delegates
{
	public delegate void Vorstellungen(string name); //Definition von Delegate: speichert Referenzen auf Methoden, können zur Laufzeit hinzugefügt und weggenommen werden

	static void Main(string[] args)
	{
		Vorstellungen v; //Variablendeklaration
		v = new Vorstellungen(VorstellungDE); //Delegate erstellen mit Initialmethode
		v("Max"); //Delegate ausführen

		v += new Vorstellungen(VorstellungEN); //Weitere Methode an Delegate anhängen
		v += VorstellungEN; //Weitere Methode an Delegate anhängen (Kurzform)
		v("Max"); //Methoden werden in der Reihenfolge ausgeführt in der sie angehängt wurden

		v -= VorstellungDE; //Methode abhängen
		v -= VorstellungDE; //Methode die nicht am Delegate hängt löst keinen Fehler aus
		v -= VorstellungDE;
		v -= VorstellungDE;
		v("Max");

		v -= VorstellungEN;
		v -= VorstellungEN; //Wenn alle Methoden entfernt werden wird das Delegate null
		v("Max");

		if (v is not null) //Null-Check
			v("Max");

		v.Invoke("Max"); //Führt mein Delegate aus wie oben
		v?.Invoke("Max"); //? Operator: Null-Check vor Methodenaufruf

		//List<int> test = null;
		//test?.Add(2); hier auch Null-Check vor Add

		v = null; //Delegate entleeren

		foreach (Delegate dg in v.GetInvocationList()) //Delegate durchgehen (alle Methoden anschauen)
		{
			Console.WriteLine(dg.Method.Name); //in dg.Method stehen alle möglichen Informationen zu der Methode drinnen
		}
	}

	static void VorstellungDE(string name) => Console.WriteLine($"Hallo mein Name ist {name}");

	static void VorstellungEN(string name) => Console.WriteLine($"Hello my name is {name}");
}