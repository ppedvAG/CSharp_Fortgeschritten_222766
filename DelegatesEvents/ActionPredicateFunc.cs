namespace DelegatesEvents;

internal class ActionPredicateFunc
{
	static void Main(string[] args)
	{
		Action<int, int> action = Addiere; //Action: Methode mit void als Rückgabewert und bis zu 16 Parametern
		action += Subtrahiere; //Methode anhängen wie bei Delegate
		action(6, 2); //Ausführen wie bei Delegate
		action?.Invoke(6, 2); //Ausführen mit Null-Check

		DoAction(6, 2, Addiere); //Das Verhalten der Methode anpassen über Action Parameter
		DoAction(6, 2, Subtrahiere);
		DoAction(6, 2, action);

		Predicate<int> pred = CheckForZero; //Predicate: Methode mit bool als Rückgabewert und genau einem Parameter
		pred += CheckForOne;
		bool b = pred(0); //Ergebnis von Predicate in Variable schreiben (hier letztes Ergebnis verwenden)
		bool? b2 = pred?.Invoke(0); //bool?: Nullable Boolean, hier notwendig da das Predicate null sein kann und dadurch nicht unbedingt ein Ergebnis herauskommt
		bool b3 = pred?.Invoke(0) == true; //false oder null ist -> b3 = false sonst true

		DoPredicate(4, CheckForZero);
		DoPredicate(4, CheckForOne);
		DoPredicate(4, pred);

		Func<int, int, double> func = Multipliziere; //Func: Methode mit bis zu 16 Parametern und einem Rückgabewert, letztes Generic ist der Rückgabetyp
		func += Dividiere;
		double d = func(4, 2); //Das letzte Ergebnis
		double? d2 = func?.Invoke(6, 2);

		DoFunc(6, 2, Multipliziere);
		DoFunc(1, 9, Dividiere);

		func += delegate (int x, int y) { return x + y; }; //Anonyme Methode

		func += (int x, int y) => { return x + y; }; //Kürzere Form

		func += (x, y) => { return x - y; };

		func += (x, y) => (double) x / y;

		DoAction(5, 1, (x, y) => Console.WriteLine(x + y)); //Hier kein Rückgabewert möglich -> cw hat keinen Rückgabewert
		DoPredicate(6, x => x % 2 == 0); //Ist eine gerade Zahl als Bedingung
		DoFunc(6, 3, (x, y) => x % y); //Anonyme Methode bei Methode mit Func Parameter benutzen
	}

	#region Action
	static void Addiere(int z1, int z2) => Console.WriteLine(z1 + z2);

	static void Subtrahiere(int z1, int z2) => Console.WriteLine(z1 - z2);

	static void DoAction(int z1, int z2, Action<int, int> action) => action?.Invoke(z1, z2);
	#endregion

	#region Predicate
	static bool CheckForZero(int x) => x == 0;

	static bool CheckForOne(int x) => x == 1;

	static bool DoPredicate(int x, Predicate<int> pred) => pred?.Invoke(x) == true;
	#endregion

	#region Func
	static double Multipliziere(int z1, int z2) => z1 * z2;

	static double Dividiere(int z1, int z2) => z1 / z2;

	static double? DoFunc(int z1, int z2, Func<int, int, double> func) => func?.Invoke(z1, z2);
	#endregion
}
