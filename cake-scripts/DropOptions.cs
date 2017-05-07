using System.Collections.Generic;

public class DropOptions
{
    public DropOptions()
    {
        Projects = Enumerable.Empty<Project>();
    }

    public IEnumerable<Project> Projects { get; set; }
}