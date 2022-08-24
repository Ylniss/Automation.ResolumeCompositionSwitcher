using Automation.ResolumeCompositionSwitcher.Core.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Automation.ResolumeCompositionSwitcher.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<ILocalStorageService, LocalStorageService>();
        services.AddSingleton<ICompositionSwitcherStorageService, CompositionSwitcherStorageService>();
        return services;
    }
}