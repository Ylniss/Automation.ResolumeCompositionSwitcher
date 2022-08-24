using System.Diagnostics;

namespace Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher.StopTimer;

public class CountdownStopTimer
{
    private int _elapsedMs = 0;

    public int ElapsedMs
    {
        get => _elapsedMs;
        set
        {
            if (value < 0) _elapsedMs = 0;
            _elapsedMs = value;
        }
    }

    public event EventHandler OnTick;

    public async Task Countdown(int milliseconds)
    {
        var stopWatch = new Stopwatch();

        stopWatch.Start();
        ElapsedMs = milliseconds;
        while (ElapsedMs > 0)
        {
            ElapsedMs = milliseconds - (int)stopWatch.ElapsedMilliseconds;

            OnTick?.Invoke(this, new ElapsedMsEventArgs() { ElapsedMs = ElapsedMs });
            await Task.Delay(1);
        }
        stopWatch.Stop();
    }
}