#addin "Cake.Npm"

Task("NpmInstall")
    .Description("Installs all the npm packages.")
    .Does(() =>
    {
        NpmInstall();
    });