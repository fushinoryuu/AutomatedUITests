using System.Collections.Generic;

public class DropOptions
{
    public IEnumerable<Project> Projects { get; set; }

    public DropOptions()
    {
        Projects = Enumerable.Empty<Project>();
    }
}