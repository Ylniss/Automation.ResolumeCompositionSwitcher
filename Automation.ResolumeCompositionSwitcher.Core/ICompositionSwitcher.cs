using Automation.ResolumeCompositionSwitcher.Core.Params;
using Automation.ResolumeCompositionSwitcher.Core.ResolumeArenaProcessWrapper;

namespace Automation.ResolumeCompositionSwitcher.Core;

public interface ICompositionSwitcher
{
    CompositionParams CompositionParams { get; set; }
    ResolumeArenaProcess ResolumeArenaProcess { get; init; }
    bool SwitchingEnabled { get; }

    void ToggleSwitching(bool toggle);

    event EventHandler OnSwitchToNextColumn;
}