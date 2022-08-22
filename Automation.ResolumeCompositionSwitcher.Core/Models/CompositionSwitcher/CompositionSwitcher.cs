using Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher.ResolumeArenaProcessWrapper;

namespace Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher;

public class CompositionSwitcher
{
    private CompositionParams _compositionParams;

    public CompositionParams CompositionParams
    {
        get => _compositionParams;
        set
        {
            _compositionParams = value;
            _columnsQueue = new ShuffledColumnsQueue(_compositionParams.NumberOfColumns);
        }
    }

    public ResolumeArenaProcess ResolumeArenaProcess { get; init; }

    public event EventHandler OnSwitchColumn;

    public event EventHandler OnRandomizedSleepTime;

    public int SwitchIntervalMs => 45;

    public int CurrentColumn { get; set; } = 1;

    public bool SwitchingEnabled { get; private set; } = false;

    private ShuffledColumnsQueue _columnsQueue;

    public void ToggleSwitching(bool toggle)
    {
        SwitchingEnabled = toggle;
    }

    public CompositionSwitcher(CompositionParams compositionParams)
    {
        CompositionParams = compositionParams;

        ResolumeArenaProcess = new ResolumeArenaProcess();
        RunCompositionColumnSwitcher();
    }

    private void RunCompositionColumnSwitcher()
    {
        ResolumeArenaProcess.SetToForeground();

        Task.Run(async () =>
        {
            while (true)
            {
                if (!ResolumeArenaProcess.IsInForeground() || !SwitchingEnabled || CompositionParams is null) continue;

                SwitchToNextColumn();

                await Task.Delay(GetRandomizedSleepTimeMs());
            }
        });
    }

    private void SwitchToNextColumn()
    {
        int newColumn = _columnsQueue.Dequeue();

        int moveSize = CurrentColumn - newColumn;

        if (moveSize < 0)
        {
            for (int i = 1; i <= Math.Abs(moveSize); ++i)
            {
                if (!SwitchingEnabled) break;
                CurrentColumn++;
                OnSwitchColumn(this, new SwitchDirectionEventArgs() { Forward = true });
            }
        }
        else
        {
            for (int i = 1; i <= Math.Abs(moveSize); ++i)
            {
                if (!SwitchingEnabled) break;
                CurrentColumn--;
                OnSwitchColumn(this, new SwitchDirectionEventArgs() { Forward = false });
            }
        }
    }

    private int GetRandomizedSleepTimeMs()
    {
        var randomizer = new Random();
        var sleepTimeMs = randomizer.Next(_compositionParams.MinTimeToChangeMs, _compositionParams.MaxTimeToChangeMs + 1);

        OnRandomizedSleepTime(this, new SleepTimeEventArgs() { SleepTimeMs = sleepTimeMs });

        return sleepTimeMs;
    }
}