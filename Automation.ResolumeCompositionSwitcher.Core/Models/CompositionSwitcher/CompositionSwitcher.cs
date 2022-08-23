using Automation.ResolumeCompositionSwitcher.Core.ResolumeArenaApi;
using Refit;
using System.Diagnostics;

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

    public event EventHandler OnResolumeApiConnectionChanged;

    public event EventHandler OnColumnSwitch;

    public event EventHandler OnRandomizedSwitchInterval;

    public event EventHandler OnIntervalTick;

    public event EventHandler OnBeforeChangeColumnRequest;

    public event EventHandler OnAfterChangeColumnRequest;

    public bool SwitchingEnabled { get; private set; } = false;

    private ShuffledColumnsQueue _columnsQueue;
    private int _switchIntervalMs = 0;

    private string _resolumeArenaApiAddress = "http://127.0.0.1:8080/api/v1/";
    private IResolumeArenaApi _resolumeArenaApi;

    private CancellationTokenSource _cancellationTokenSource;
    private CancellationToken _cancellationToken;

    public void ToggleSwitching(bool toggle)
    {
        SwitchingEnabled = toggle;

        if (toggle is true)
        {
            try
            {
                RunCompositionColumnSwitcher();
            }
            catch (Exception)
            {
                OnResolumeApiConnectionChanged?.Invoke(this, new MessageEventArgs() { Message = "Composition disconnected" });
            }
        }
        //else
        //{
        //    _cancellationTokenSource.Cancel();
        //}
    }

    public CompositionSwitcher(CompositionParams compositionParams)
    {
        CompositionParams = compositionParams;

        _resolumeArenaApi = RestService.For<IResolumeArenaApi>(_resolumeArenaApiAddress);
    }

    public void RunCompositionColumnSwitcher()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _cancellationToken = _cancellationTokenSource.Token;

        Task.Run(async () =>
        {
            while (true)
            {
                SetRandomizedSwitchIntervalMs();
                await SwitchToNextColumn();

                var stopWatch = new Stopwatch();

                stopWatch.Start();
                var elapsedMs = _switchIntervalMs;
                while (elapsedMs > 0)
                {
                    elapsedMs = _switchIntervalMs - (int)stopWatch.ElapsedMilliseconds;

                    if (!SwitchingEnabled)
                    {
                        elapsedMs = 0;

                        _cancellationToken.ThrowIfCancellationRequested();
                        break;
                    }

                    await Task.Delay(1, _cancellationToken);
                    OnIntervalTick?.Invoke(this, new SwitchIntervalEventArgs() { IntervalMs = elapsedMs });
                }
                stopWatch.Stop();

                if (!SwitchingEnabled)
                {
                    OnIntervalTick?.Invoke(this, new SwitchIntervalEventArgs() { IntervalMs = 0 });
                    _cancellationToken.ThrowIfCancellationRequested();
                    break;
                }
            }
        });

        _cancellationTokenSource.Dispose();
    }

    private async Task SwitchToNextColumn()
    {
        int newColumn = _columnsQueue.Dequeue();

        try
        {
            OnBeforeChangeColumnRequest?.Invoke(this, EventArgs.Empty);
            await _resolumeArenaApi.ChangeColumn(newColumn);
            OnAfterChangeColumnRequest?.Invoke(this, EventArgs.Empty);
        }
        catch (HttpRequestException)
        {
            SwitchingEnabled = false;
            OnResolumeApiConnectionChanged?.Invoke(this, new MessageEventArgs() { Message = "Composition disconnected" });
            return;
        }

        OnResolumeApiConnectionChanged?.Invoke(this, new MessageEventArgs() { Message = "Connected to composition" });

        OnColumnSwitch?.Invoke(this, new SwitchColumnEventArgs() { Column = newColumn });
    }

    private void SetRandomizedSwitchIntervalMs()
    {
        if (SwitchingEnabled)
        {
            var randomizer = new Random();
            _switchIntervalMs = randomizer.Next(_compositionParams.MinTimeToChangeMs, _compositionParams.MaxTimeToChangeMs + 1);
        }
        else
        {
            _switchIntervalMs = 0;
        }

        OnRandomizedSwitchInterval?.Invoke(this, new SwitchIntervalEventArgs() { IntervalMs = _switchIntervalMs });
    }
}