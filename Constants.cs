using System.Collections.Generic;

public static class Constants
{
	public const int NunitWorkers = 30;
	public const string NetFrameworkSolutionFile = "./src/NetFramework/AutomationToolbox_NetFramework.sln";
	public const string TestAssembliesGlob = "./src/**/bin/Debug/*.Tests.dll";

	public public IEnumerable<Project> NetFrameworkProjects = new[]
	{
		new Project
		{
			Name = "Automation.Database",
			Location = "./src/NetFramework/Automation.Database/Automation.Database.csproj",
			Folders = new string[0],
			Files = new string[0]
		},
		new Project
		{
			Name = "Automation.Framework",
			Location = "./src/NetFramework/Automation.Framework/Automation.Framework.csproj",
			Folders = new string[0],
			Files = new string[0]
		},
		new Project
		{
			Name = "Automation.Gui",
			Location = "./src/NetFramework/Automation.Gui/Automation.Gui.csproj",
			Folders = new string[0],
			Files = new string[0]
		},
		new Project
		{
			Name = "Automation.Selenium",
			Location = "./src/NetFramework/Automation.Selenium/Automation.Selenium.csproj",
			Folders = new string[0],
			Files = new string[0]
		},
		new Project
		{
			Name = "Automation.Tests",
			Location = "./src/NetFramework/Automation.Tests/Automation.Tests.csproj",
			Folders = new string[0],
			Files = new string[0]
		},
		new Project
		{
			Name = "Automation.Xml",
			Location = "./src/NetFramework/Automation.Xml/Automation.Xml.csproj",
			Folders = new string[0],
			Files = new string[0]
		}
	}
}