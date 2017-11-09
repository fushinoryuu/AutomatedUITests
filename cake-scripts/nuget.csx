Task("NugetRestore")
    .Description("Restore all the NuGet dependencies.")
    .Does(() =>
    {
        // Get sln files
        var solutions = GetFiles("./**/*.sln");
        
        // Restore all NuGet packages.
        foreach(var solution in solutions)
        {
            Information("\nRestoring {0}", solution);
            NuGetRestore(solution);
        }
    });