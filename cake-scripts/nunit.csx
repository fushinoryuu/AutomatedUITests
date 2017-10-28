#tool "nuget:?package=NUnit.ConsoleRunner&version=3.7.0"

Task("NUnit")
    .Description("Runs the NUnit tests.")
    .IsDependentOn("CompileDebug")
    .Does(() =>
    {
        var testAssemblies = getTestAssemblies();

        NUnit3(testAssemblies, new NUnit3Settings
        {
            Workers = Constants.NunitWorkers,
            Work = "./Build"
        });
    });

private IEnumerable<FilePath> getTestAssemblies()
{
    var testAssemblies = GetFiles(Constants.TestAssembliesGlob);
    return testAssemblies;
}