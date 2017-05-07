Task("PaketRestore")
    .Description("Runs paket restore command.")
    .IsDependentOn("BootstrapPaket")
    .Does(() =>
    {
        if (StartProcess(Constants.PaketExecutible, "restore") != 0)
        {
            Error("Paket restore failed");
        }
    });

Task("BootstrapPaket")
    .Description("Downloads paket if not installed.")
    .Does(() =>
    {
        if (StartProcess(Constants.PaketBootstrapperExecutible) != 0)
        {
            Error("Unable to fetch paket.exe");
        }
    });