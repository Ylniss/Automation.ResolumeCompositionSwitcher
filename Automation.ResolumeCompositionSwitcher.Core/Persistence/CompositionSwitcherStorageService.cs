using Automation.ResolumeCompositionSwitcher.Core.Models;
using Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher;
using Newtonsoft.Json;

namespace Automation.ResolumeCompositionSwitcher.Core.Persistence;

public class CompositionSwitcherStorageService : ICompositionSwitcherStorageService
{
    private const string NumberOfColumnsKey = "NumberOfColumns";
    private const string MinTimeToChangeMsKey = "MinTimeToChangeMs";
    private const string MaxTimeToChangeMsKey = "MaxTimeToChangeMs";

    private const int NumberOfColumnsDefault = 50;
    private const int MinTimeToChangeMsDefault = 10000;
    private const int MaxTimeToChangeMsDefault = 20000;

    private readonly ILocalStorageService _localStorage;

    public event EventHandler<MessageEventArgs>? OnException;

    public CompositionSwitcherStorageService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public void SaveNumberOfColumns(int numberOfColumns)
    {
        _localStorage.SetStorageValue(NumberOfColumnsKey, numberOfColumns);
    }

    public void SaveMinTimeToChangeMs(int minTimeToChangeMs)
    {
        _localStorage.SetStorageValue(MinTimeToChangeMsKey, minTimeToChangeMs);
    }

    public void SaveMaxTimeToChangeMs(int maxTimeToChangeMs)
    {
        _localStorage.SetStorageValue(MaxTimeToChangeMsKey, maxTimeToChangeMs);
    }

    public CompositionParams TryLoadCompositionParams()
    {
        SetDefaultsIfDontExist();

        CompositionParams compositionParams;

        try
        {
            compositionParams = LoadCompositionParams();
        }
        catch (ArgumentOutOfRangeException)
        {
            compositionParams = HandleExceptionAndGetDefaultCompositionParams("Minimum time has to be lower than Maximum. Retrieving default values");
        }
        catch (ArgumentNullException)
        {
            compositionParams = HandleExceptionAndGetDefaultCompositionParams("Missing values. Retrieving default values");
        }
        catch (ArgumentException)
        {
            compositionParams = HandleExceptionAndGetDefaultCompositionParams("Some values are negative or zero. Retrieving default values");
        }
        catch (JsonSerializationException)
        {
            compositionParams = HandleExceptionAndGetDefaultCompositionParams("Invalid JSON. Retrieving default values");
        }

        return compositionParams;
    }

    private CompositionParams HandleExceptionAndGetDefaultCompositionParams(string message)
    {
        OnException?.Invoke(this, new MessageEventArgs() { Message = message });
        SetDefaults();
        return LoadCompositionParams();
    }

    private CompositionParams LoadCompositionParams() =>
        new CompositionParams(_localStorage.GetStorageValue<int>(NumberOfColumnsKey),
                 _localStorage.GetStorageValue<int>(MinTimeToChangeMsKey),
                 _localStorage.GetStorageValue<int>(MaxTimeToChangeMsKey));

    private void SetDefaultsIfDontExist()
    {
        if (!_localStorage.Exists(NumberOfColumnsKey))
            _localStorage.SetStorageValue(NumberOfColumnsKey, NumberOfColumnsDefault);

        if (!_localStorage.Exists(MinTimeToChangeMsKey))
            _localStorage.SetStorageValue(MinTimeToChangeMsKey, MinTimeToChangeMsDefault);

        if (!_localStorage.Exists(MaxTimeToChangeMsKey))
            _localStorage.SetStorageValue(MaxTimeToChangeMsKey, MaxTimeToChangeMsDefault);
    }

    private void SetDefaults()
    {
        _localStorage.SetStorageValue(NumberOfColumnsKey, NumberOfColumnsDefault);
        _localStorage.SetStorageValue(MinTimeToChangeMsKey, MinTimeToChangeMsDefault);
        _localStorage.SetStorageValue(MaxTimeToChangeMsKey, MaxTimeToChangeMsDefault);
    }
}