using Automation.ResolumeCompositionSwitcher.Core.Params;
using Automation.ResolumeCompositionSwitcher.Core.ResolumeArenaProcessWrapper;

namespace Automation.ResolumeCompositionSwitcher.Core;

public class CompositionSwitcher : ICompositionSwitcher
{
    public CompositionParams CompositionParams { get; set; }
    public ResolumeArenaProcess ResolumeArenaProcess { get; init; }

    public event EventHandler OnSwitchToNextColumn;

    public bool SwitchingEnabled { get; private set; } = false;

    public void ToggleSwitching(bool toggle)
    {
        SwitchingEnabled = toggle;
    }

    private CancellationTokenSource cancelSwitchingOperationTokneSource = new CancellationTokenSource();

    public CompositionSwitcher()
    {
        ResolumeArenaProcess = new ResolumeArenaProcess();
        SwitchCompositionColumns();
    }

    private void SwitchCompositionColumns(CancellationToken cancellationToken = default)
    {
        ResolumeArenaProcess.SetProcessToForeground();

        Task.Run(() =>
        {
            while (true)
            {
                if (!ResolumeArenaProcess.IsProccessInForeground() || !SwitchingEnabled) continue;

                // random max columns and in for that many times SendWait
                OnSwitchToNextColumn(this, EventArgs.Empty);

                Thread.Sleep(CompositionParams.MaxTimeToChangeMs);
            }
        }, cancellationToken);
    }
}