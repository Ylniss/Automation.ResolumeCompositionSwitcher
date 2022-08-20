namespace Automation.ResolumeCompositionSwitcher.Core.Models;

public class ProcessVisibilityEventArgs : MessageEventArgs
{
    public bool IsInForeground { get; init; }
}