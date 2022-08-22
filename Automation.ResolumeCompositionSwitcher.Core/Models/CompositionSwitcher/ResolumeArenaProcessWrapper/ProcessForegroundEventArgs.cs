namespace Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher.ResolumeArenaProcessWrapper;

public class ProcessForegroundEventArgs : MessageEventArgs
{
    public bool IsInForeground { get; init; }
}