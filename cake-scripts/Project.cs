using System.Collections.Generic;

public class Project
{
    public string Name { get; set; }
    public IEnumerable<string> Folders { get; set; }
    public IEnumerable<string> Files { get; set; }

    public Project()
    {
        Folders = Enumerable.Empty<string>();
        Files = Enumerable.Empty<string>();
    }
}