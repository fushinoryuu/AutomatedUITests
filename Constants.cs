public static class Constants
{
	public const string PaketExecutible = ".paket/paket.exe";
	public const string PaketBootstrapperExecutible = "./.paket/paket.bootstrapper.exe";
	public const string SolutionFile = "./src/AutomatedTests.sln";
	public const string TestAssembliesGlob = "./src/**/bin/Debug/*.Tests.dll";
}

public DropOptions dropOptions = new DropOptions
{
	Projects = new[]
	{
		new Project
		{
			Name = "Automation.Database",
			Folders = new string[0],
			Files = new string[0]
		},
		new Project
		{
			Name = "Automation.Framework",
			Folders = new string[0],
			Files = new string[0]
		},
		new Project
		{
			Name = "Automation.Gui",
			Folders = new string[0],
			Files = new string[0]
		},
		new Project
		{
			Name = "Automation.Selenium",
			Folders = new string[0],
			Files = new string[0]
		},
		new Project
		{
			Name = "Automation.Tests",
			Folders = new string[0],
			Files = new string[0]
		},
		new Project
		{
			Name = "Automation.Xml",
			Folders = new string[0],
			Files = new string[0]
		}
	}
};