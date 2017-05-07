#load "./cake-scripts/npm.csx"
#load "./cake-scripts/nunit.csx"
#load "./cake-scripts/paket.csx"
#load "./cake-scripts/compile.csx"
#load "./Constants.cs"
#load "./cake-scripts/Project.cs"
#load "./cake-scripts/DropOptions.cs"

var target = Argument("target", "Default");

Task("Default")
    .Description("Compiles the code and runs the NUnit tests.")
    .IsDependentOn("NpmInstall")
    .IsDependentOn("PaketRestore")
    .IsDependentOn("CompileDebug")
    .IsDependentOn("NUnit");

RunTarget(target);