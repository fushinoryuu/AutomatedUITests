DirectoryPath currentWorkingDirectory;

Task("CompileDebug")
    .Description("Compiles the solution in Debug mode.")
    .Does(() =>
    {
        Compile("Debug");
    });

Task("CompileRelease")
    .Description("Compiles the solution in Release mode.")
    .Does(() =>
    {
        Compile("Release");
    });

Task("CompileAll")
    .Description("Compiles both release and debug builds.")
    .IsDependentOn("CompileDebug")
    .IsDependentOn("CompileRelease");

private void Compile(string mode)
{
    DotNetBuild(Constants.NetFrameworkSolutionFile, settings =>
        settings.SetConfiguration(mode)
            .SetVerbosity(Verbosity.Minimal)
            .WithProperty("nodeReuse", "false")
            .WithTarget("Rebuild"));
}
