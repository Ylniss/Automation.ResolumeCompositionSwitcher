using Automation.ResolumeCompositionSwitcher.Core.Constants;
using Automation.ResolumeCompositionSwitcher.Core.Extensions;
using Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher.ResolumeProcess;
using Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher.StopTimer;
using Automation.ResolumeCompositionSwitcher.Core.ResolumeArenaApi;
using Refit;

namespace Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher;

public class CompositionSwitcher
{
    public CompositionParams CompositionParams { get; set; }

    public event EventHandler<string>? OnResolumeApiConnectionChanged;

    public event EventHandler<string>? OnResolumeProcessConnectionChanged;

    public event EventHandler<int>? OnColumnSwitch;

    public event EventHandler<int>? OnRandomizedSwitchInterval;

    public event EventHandler<int>? OnIntervalTick;

    public event EventHandler<string>? OnBeforeChangeColumnRequest;

    public event EventHandler? OnAfterChangeColumnRequest;

    public CompositionSwitcherState State { get; private set; } = CompositionSwitcherState.Paused;
    public bool ProcessConnected => _resolumeArenaProcess.Connected;

    private ShuffledColumnsList _shuffledColumns;
    private int _switchIntervalMs = 0;

    private string _resolumeArenaApiAddress = "http://127.0.0.1:8080/api/v1/";
    private IResolumeArenaApi _resolumeArenaApi;

    private CountdownStopTimer _stopTimer = new CountdownStopTimer();
    private ResolumeArenaProcess _resolumeArenaProcess = new ResolumeArenaProcess();

    public void ToggleSwitching(bool toggle)
    {
        if (toggle)
            State = CompositionSwitcherState.Running;
        else
            State = CompositionSwitcherState.Paused;

        if (State == CompositionSwitcherState.Running)
            RunCompositionColumnSwitcher();
    }

    public CompositionSwitcher(CompositionParams compositionParams)
    {
        CompositionParams = compositionParams;
        CompositionParams.OnNumberOfColumnsChanged += CompositionParams_OnNumberOfColumnsChanged;

        _stopTimer.OnTick += _stopTimer_OnTick;
        _resolumeArenaProcess.OnProcessConnectionStatusChanged += _resolumeArenaProcess_OnProcessConnectionStatusChanged;

        _shuffledColumns = new ShuffledColumnsList(CompositionParams.NumberOfColumns);

        _resolumeArenaApi = RestService.For<IResolumeArenaApi>(_resolumeArenaApiAddress);
    }

    private void _resolumeArenaProcess_OnProcessConnectionStatusChanged(object? sender, string message)
    {
        OnResolumeProcessConnectionChanged?.Invoke(this, message);
    }

    private void _stopTimer_OnTick(object? sender, int elapsedMs)
    {
        if (State != CompositionSwitcherState.Running)
            elapsedMs = _stopTimer.ElapsedMs = 0;

        OnIntervalTick?.Invoke(this, elapsedMs);
    }

    private void CompositionParams_OnNumberOfColumnsChanged(object? sender, EventArgs e)
    {
        _shuffledColumns = new ShuffledColumnsList(CompositionParams.NumberOfColumns);
    }

    public void RunCompositionColumnSwitcher()
    {
        Task.Run(async () =>
        {
            while (true)
            {
                SetRandomizedSwitchIntervalMs();
                await SwitchToNextColumn();
                await CountDownTimeToNextSwitch();

                if (State != CompositionSwitcherState.Running) break;
            }
        });
    }

    private async Task CountDownTimeToNextSwitch()
    {
        await _stopTimer.Countdown(_switchIntervalMs);
    }

    public async Task SwitchToNextColumn()
    {
        var column = _shuffledColumns.Next();
        await SwitchToColumn(column);
    }

    public async Task SwitchToPreviousColumn()
    {
        var column = _shuffledColumns.Previous();
        await SwitchToColumn(column);
    }

    private async Task SwitchToColumn(int column)
    {
        try
        {
            State = CompositionSwitcherState.Loading;
            OnBeforeChangeColumnRequest?.Invoke(this, AppMessages.ConnectingToApiMessage);
            await _resolumeArenaApi.ChangeColumn(column).TimeoutAfter(TimeSpan.FromSeconds(3));
            State = CompositionSwitcherState.Running;
            OnAfterChangeColumnRequest?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception ex) when (ex is HttpRequestException
                                   || ex is ApiException
                                   || ex is TimeoutException)
        {
            State = CompositionSwitcherState.Paused;
            OnResolumeApiConnectionChanged?.Invoke(this, AppMessages.ConnectionToApiFailedMessage);
            return;
        }

        OnResolumeApiConnectionChanged?.Invoke(this, AppMessages.ConnectedToCompositionMessage);

        OnColumnSwitch?.Invoke(this, column);
    }

    private void SetRandomizedSwitchIntervalMs()
    {
        if (State == CompositionSwitcherState.Running)
            _switchIntervalMs = new Random().
                Next(CompositionParams.MinTimeToChangeMs, CompositionParams.MaxTimeToChangeMs + 1);
        else
            _switchIntervalMs = 0;

        OnRandomizedSwitchInterval?.Invoke(this, _switchIntervalMs);
    }
}