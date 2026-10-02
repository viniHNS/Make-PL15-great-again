using SPTarkov.Server.Core.Models.Spt.Mod;

namespace MakePL15GreatAgain;

public record ModMetadata : IModMetadata
{
    public string ModGuid { get; init; } = "com.vinihns.makepl15greatagain";
    public string Name { get; init; } = "Make PL-15 Great Again";
    public string Author { get; init; } = "ViniHNS";
    public List<string>? Contributors { get; init; }
    public SemanticVersioning.Version Version { get; init; } = new("1.5.0");
    public SemanticVersioning.Range SptVersion { get; init; } = new("~4.1.6");
    public bool HasPrepatcher { get; init; } = false;
    public List<string>? Incompatibilities { get; init; }
    public Dictionary<string, SemanticVersioning.Range>? ModDependencies { get; init; }
    public string? Url { get; init; } = "https://github.com/viniHNS/Make-PL15-great-again";
    public string License { get; init; } = "MIT";
}
