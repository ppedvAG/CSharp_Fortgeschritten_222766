namespace LinqErweiterungsmethoden;

internal static class Erweiterungsmethoden
{
	public static int Quersumme(this int z) => z.ToString().ToCharArray().Sum(e => (int) char.GetNumericValue(e));

	public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list) => list.OrderBy(e => Random.Shared.Next()); //Eigene Linq Methode
}
