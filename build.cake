#load "./Constants.cs"
#load "./cake-scripts/npm.csx"
#load "./cake-scripts/nuget.csx"
#load "./cake-scripts/nunit.csx"
#load "./cake-scripts/Project.cs"
#load "./cake-scripts/compile_netframework.csx"

var target = Argument("target", "DefaultNetFramework");

Task("DefaultNetFramework")
    .Description("Compiles the code and runs the NUnit tests.")
    .IsDependentOn("NpmInstall")
    .IsDependentOn("NugetRestore")
    .IsDependentOn("CompileDebug")
    .IsDependentOn("NUnit");

Task("TestsNetFramework")
    .Description("Runs only the tests. This assumes the project is already built.")
    .IsDependentOn("NUnit");

RunTarget(target);