namespace Automation.ResolumeCompositionSwitcher.Core.Persistence;

public interface ILocalStorageService
{
    void ClearStorage(IEnumerable<string> keys);

    bool Exists(string key);

    T GetStorageValue<T>(string key);

    void SetStorageValue<T>(string key, T value);
}