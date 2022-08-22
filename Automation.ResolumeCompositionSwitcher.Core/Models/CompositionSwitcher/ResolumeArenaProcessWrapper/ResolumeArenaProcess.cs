using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher.ResolumeArenaProcessWrapper;

public class ResolumeArenaProcess
{
    public string Name => "Arena";
    public bool Connected => _process != null;

    public event EventHandler OnProcessConnectionStatusChanged;

    public event EventHandler OnProcessForegroundChanged;

    private Process _process;
    private int _updateRateMs = 100;

    [DllImport("User32.dll")]
    private static extern bool SetForegroundWindow(IntPtr point);

    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    public ResolumeArenaProcess()
    {
        UpdateProcessConnectionStatus();
        SetToForeground();
        UpdateForegroundStatus();
    }

    public void SetToForeground()
    {
        ProcessLoop(() =>
        {
            SetForegroundWindow(_process.MainWindowHandle);
        }, waitForConnection: true, finishAfterConnectionEstabilished: true);
    }

    public bool IsInForeground()
    {
        if (!Connected) return false;

        var activeHandle = GetForegroundWindow();
        return activeHandle == _process.MainWindowHandle;
    }

    private void UpdateProcessConnectionStatus()
    {
        ProcessLoop(() =>
        {
            var processes = Process.GetProcessesByName(Name);

            if (processes.Length != 0)
            {
                _process = processes.FirstOrDefault();
                OnProcessConnectionStatusChanged?.Invoke(this, new MessageEventArgs() { Message = $"Process '{Name}' connected." });
            }
            else
            {
                _process = null;
                OnProcessConnectionStatusChanged?.Invoke(this, new MessageEventArgs() { Message = $"Process '{Name}' disconnected." });
            }
        }, waitForConnection: false);
    }

    private void UpdateForegroundStatus()
    {
        ProcessLoop(() =>
        {
            if (!IsInForeground())
            {
                OnProcessForegroundChanged?.Invoke(this, new ProcessForegroundEventArgs()
                {
                    Message = $"'{Name}' process is in background",
                    IsInForeground = false
                });
            }
            else
            {
                OnProcessForegroundChanged?.Invoke(this, new ProcessForegroundEventArgs()
                {
                    Message = $"'{Name}' process is in foreground",
                    IsInForeground = true
                });
            }
        }, waitForConnection: true);
    }

    private void ProcessLoop(Action action, bool waitForConnection, bool finishAfterConnectionEstabilished = false)
    {
        Task.Run(async () =>
        {
            while (true)
            {
                if (waitForConnection && !Connected) continue;

                action();

                if (finishAfterConnectionEstabilished) return;
                await Task.Delay(_updateRateMs);
            }
        });
    }
}