Task("PaketInstall")
    .Description("Runs paket install")
    .IsDependentOn("BootstrapPaket")
    .Does(() =>
    {
        if (StartProcess(Constants.PaketExecutible, "install") != 0)
        {
            Error("Paket restore failed");
        }
    });

Task("PaketRestore")
    .Description("Runs paket restore")
    .IsDependentOn("BootstrapPaket")
    .Does(() =>
    {
        if (StartProcess(Constants.PaketExecutible, "restore") != 0)
        {
            Error("Paket restore failed");
        }
    });

Task("BootstrapPaket")
    .Description("Downloads paket if not installed. Called by paketInstall")
    .Does(() =>
    {
        if (StartProcess(Constants.PaketBootstrapperExecutible) != 0)
        {
            Error("Unable to fetch paket.exe");
        }
    });