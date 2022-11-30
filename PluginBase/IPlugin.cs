namespace PluginBase;

public interface IPlugin //Basisplugin, alle Plugins haben diese Grundvoraussetzungen
{
	string Name { get; }

	string Description { get; }
}

public interface ICalculatorPlugin : IPlugin
{
	int Addiere(double z1, double z2);

	int Subtrahiere(double z1, double z2);
}