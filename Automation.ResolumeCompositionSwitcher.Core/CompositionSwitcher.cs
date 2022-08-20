using Automation.ResolumeCompositionSwitcher.Core.Models;
using Automation.ResolumeCompositionSwitcher.Core.Params;
using Automation.ResolumeCompositionSwitcher.Core.ResolumeArenaProcessWrapper;

namespace Automation.ResolumeCompositionSwitcher.Core;

public class CompositionSwitcher : ICompositionSwitcher
{
    public CompositionParams CompositionParams { get; set; }
    public ResolumeArenaProcess ResolumeArenaProcess { get; init; }

    public event EventHandler OnSwitchColumn;

    public int CurrentColumn { get; set; } = 1;

    public bool SwitchingEnabled { get; private set; } = false;

    public void ToggleSwitching(bool toggle)
    {
        SwitchingEnabled = toggle;
    }

    public CompositionSwitcher()
    {
        ResolumeArenaProcess = new ResolumeArenaProcess();
        RunCompositionColumnSwitcher();
    }

    private void RunCompositionColumnSwitcher()
    {
        ResolumeArenaProcess.SetProcessToForeground();

        Task.Run(() =>
        {
            while (true)
            {
                if (!ResolumeArenaProcess.IsProccessInForeground() || !SwitchingEnabled || CompositionParams is null) continue;

                RandomizeColumn();
                Thread.Sleep(GetRandomizedSleepTimeMs());
            }
        });
    }

    private void RandomizeColumn()
    {
        var randomizer = new Random();
        int newColumn = randomizer.Next(1, CompositionParams.NumberOfColumns + 1);

        var moveSize = CurrentColumn - newColumn;

        if (moveSize < 0)
        {
            for (int i = 1; i <= Math.Abs(moveSize); ++i)
            {
                OnSwitchColumn(this, new SwitchDirectionEventArgs() { Forward = true });
                CurrentColumn++;
            }
        }
        else
        {
            for (int i = 1; i <= Math.Abs(moveSize); ++i)
            {
                OnSwitchColumn(this, new SwitchDirectionEventArgs() { Forward = false });
                CurrentColumn--;
            }
        }
    }

    private int GetRandomizedSleepTimeMs()
    {
        var randomizer = new Random();
        return randomizer.Next(CompositionParams.MinTimeToChangeMs, CompositionParams.MaxTimeToChangeMs + 1);
    }
}