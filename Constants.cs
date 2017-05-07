public static class Constants
{
	public const string PaketExecutible = ".paket/paket.exe";
	public const string PaketBootstrapperExecutible = "./.paket/paket.bootstrapper.exe";
	public const string SolutionFile = "./src/HealthcareAutomatedTests.sln";
	public const string TestAssembliesGlob = "./src/**/bin/Debug/*.Tests.dll";
}

public DropOptions dropOptions = new DropOptions
{
	Projects = new[]
	{
		new Project
		{
			Name = "Healthcare.Framework",
			Folders = new string[0],
			Files = new string[0]
		},
		new Project
		{
			Name = "Healthcare.Tests",
			Folders = new string[0],
			Files = new string[0]
		}
	}
};