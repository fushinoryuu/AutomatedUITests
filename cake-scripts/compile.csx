DirectoryPath currentWorkingDirectory;

Task("CompileDebug")
    .Description("Compiles the solution in Debug mode.")
    .Does(() =>
    {
        Compile("Debug");
        dropPrepare("Debug");
    });

Task("CompileRelease")
    .Description("Compiles the solution in Release mode.")
    .Does(() =>
    {
        Compile("Release");
        dropPrepare("Release");
    });

Task("CompileAll")
    .Description("Compiles both release and debug builds.")
    .IsDependentOn("CompileDebug")
    .IsDependentOn("CompileRelease");

private void Compile(string mode)
{
    DotNetBuild(Constants.SolutionFile, settings =>
        settings.SetConfiguration(mode)
            .SetVerbosity(Verbosity.Minimal)
            .WithProperty("nodeReuse", "false")
            .WithTarget("Rebuild"));
}

private void dropPrepare(string releaseTarget)
{
    currentWorkingDirectory = MakeAbsolute(Directory("./"));

    foreach (var project in dropOptions.Projects)
    {
        Information("\nGathering release files for project {0}", project.Name);
        var destinationRoot = currentWorkingDirectory
            .Combine("Build")
            .Combine(project.Name)
            .Combine(releaseTarget);

        EnsureDirectoryExists(destinationRoot);
        CleanDirectory(destinationRoot);

        var projectDirectory = currentWorkingDirectory.Combine("src").Combine(project.Name);;

        var sourceDirectory = getSourceDirectory(currentWorkingDirectory, project.Name, releaseTarget);
        var finalDestination = getFinalDestination(currentWorkingDirectory, destinationRoot, project.Name, releaseTarget);

        Information("Copying {0} to {1}.", sourceDirectory, finalDestination);
        CopyDirectory(sourceDirectory, finalDestination);

        var projectEnvironmentDirectory = projectDirectory.Combine("Env");
        if (DirectoryExists(projectEnvironmentDirectory))
        {
            var projectBuildDirectory = currentWorkingDirectory.Combine("Build").Combine(project.Name).Combine("Env");
            CopyDirectory(projectEnvironmentDirectory, projectBuildDirectory);
        }

        foreach (var folderName in project.Folders)
        {
            var source = projectDirectory.Combine(folderName);
            var destination = destinationRoot.Combine(folderName);
            CopyDirectory(source, destination);
        }

        foreach (var fileName in project.Files)
        {
            var source = projectDirectory.GetFilePath(fileName);
            CopyFileToDirectory(source, destinationRoot);
        }
    }
}

private bool isWebProject(DirectoryPath projectDirectory, string releaseTarget)
{
    var projectDirectoryWithReleaseTarget = projectDirectory.Combine("bin").Combine(releaseTarget);
    return !DirectoryExists(projectDirectoryWithReleaseTarget);
}

private DirectoryPath getSourceDirectory(DirectoryPath currentWorkingDirectory, string projectName, string releaseTarget)
{
    var projectDirectory = currentWorkingDirectory.Combine("src").Combine(projectName);

    if (isWebProject(projectDirectory, releaseTarget))
    {
        return projectDirectory.Combine("bin");
    }

    return projectDirectory.Combine("bin").Combine(releaseTarget);
}

private DirectoryPath getFinalDestination(DirectoryPath currentWorkingDirectory, DirectoryPath destinationRoot, string projectName, string releaseTarget)
{
    var projectDirectory = currentWorkingDirectory.Combine("src").Combine(projectName);

    if (isWebProject(projectDirectory, releaseTarget))
    {
        return destinationRoot.Combine("bin");
    }

    return destinationRoot;
}