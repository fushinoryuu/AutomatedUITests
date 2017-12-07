#load "./Constants.cs"
#load "./cake-scripts/npm.csx"
#load "./cake-scripts/nunit.csx"
#load "./cake-scripts/paket.csx"
#load "./cake-scripts/compile.csx"
#load "./cake-scripts/nuget.csx"
#load "./cake-scripts/Project.cs"
#load "./cake-scripts/DropOptions.cs"

var target = Argument("target", "Default");

Task("Default")
    .Description("Compiles the code and runs the NUnit tests.")
    .IsDependentOn("NpmInstall")
    .IsDependentOn("NugetRestore")
    .IsDependentOn("CompileDebug")
    .IsDependentOn("NUnit");

Task("Tests")
    .Description("Runs only the tests. This assumes the project is already built.")
    .IsDependentOn("NUnit");

RunTarget(target);