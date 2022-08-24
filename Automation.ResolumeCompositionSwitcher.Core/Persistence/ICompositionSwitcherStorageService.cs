using Automation.ResolumeCompositionSwitcher.Core.Models;
using Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher;

namespace Automation.ResolumeCompositionSwitcher.Core.Persistence;

public interface ICompositionSwitcherStorageService
{
    public event EventHandler<MessageEventArgs>? OnException;

    void SaveNumberOfColumns(int numberOfColumns);

    void SaveMinTimeToChangeMs(int minTimeToChangeMs);

    void SaveMaxTimeToChangeMs(int maxTimeToChangeMs);

    CompositionParams TryLoadCompositionParams();
}