namespace Automation.ResolumeCompositionSwitcher.Core.Extensions;

public static class TaskExtensions
{
    public static async Task TimeoutAfter(this Task task, TimeSpan timeout)
    {
        using var timeoutCancellationTokenSource = new CancellationTokenSource();

        var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));

        if (completedTask == task)
        {
            timeoutCancellationTokenSource.Cancel();
            await task;  // Very important in order to propagate exceptions
        }
        else throw new TimeoutException("The operation has timed out.");
    }
}