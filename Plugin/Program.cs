using PluginBase;

internal class Plugin : ICalculatorPlugin
{
	public string Name => "Calculator";

	public string Description => "Ein einfacher Rechner";

	public int Addiere(double z1, double z2) => (int) (z1 + z2);

	public int Subtrahiere(double z1, double z2) => (int) (z1 - z2);
}