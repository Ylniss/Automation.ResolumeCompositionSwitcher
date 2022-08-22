using Automation.ResolumeCompositionSwitcher.Core.ResolumeArenaApi;
using Refit;

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

    public bool SwitchingEnabled { get; private set; } = false;

    private ShuffledColumnsQueue _columnsQueue;
    private int _switchIntervalMs = 0;

    private string _resolumeArenaApiAddress = "http://127.0.0.1:8080/api/v1/";
    private IResolumeArenaApi _resolumeArenaApi;

    public void ToggleSwitching(bool toggle)
    {
        SwitchingEnabled = toggle;
    }

    public CompositionSwitcher(CompositionParams compositionParams)
    {
        CompositionParams = compositionParams;

        _resolumeArenaApi = RestService.For<IResolumeArenaApi>(_resolumeArenaApiAddress);
        RunCompositionColumnSwitcher();
    }

    private void RunCompositionColumnSwitcher()
    {
        Task.Run(async () =>
        {
            while (true)
            {
                SetRandomizedSwitchIntervalMs();

                if (!SwitchingEnabled || CompositionParams is null) continue;

                await SwitchToNextColumn();

                await Task.Delay(_switchIntervalMs);
            }
        });
    }

    private async Task SwitchToNextColumn()
    {
        int newColumn = _columnsQueue.Dequeue();

        try
        {
            await _resolumeArenaApi.ChangeColumn(newColumn);
        }
        catch (HttpRequestException)
        {
            OnResolumeApiConnectionChanged?.Invoke(this, new MessageEventArgs() { Message = "Composition disconnected" });
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