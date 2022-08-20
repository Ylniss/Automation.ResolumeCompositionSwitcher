namespace Automation.ResolumeCompositionSwitcher.Core.Params;

public record CompositionParams
{
    public int NumberOfColumns { get; init; }
    public int MinTimeToChangeMs { get; init; }
    public int MaxTimeToChangeMs { get; init; }
}