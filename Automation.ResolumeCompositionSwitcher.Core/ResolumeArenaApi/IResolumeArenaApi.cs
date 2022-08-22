using Refit;

namespace Automation.ResolumeCompositionSwitcher.Core.ResolumeArenaApi;

public interface IResolumeArenaApi
{
    [Post("/composition/columns/{column}/connect")]
    Task ChangeColumn(int column);
}