using Automation.ResolumeCompositionSwitcher.Core.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Automation.ResolumeCompositionSwitcher.Core.ResolumeArenaProcessWrapper;

public class ResolumeArenaProcess
{
    public string Name => "Arena";
    public bool Connected => _resolumeArenaProcess != null;

    public event EventHandler OnProcessConnected;

    public event EventHandler OnProcessSetToForeground;

    private Process _resolumeArenaProcess;
    private int _updateRateMs = 100;

    [DllImport("User32.dll")]
    private static extern bool SetForegroundWindow(IntPtr point);

    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    public ResolumeArenaProcess()
    {
        ConnectToProccess();
        SetProcessToForeground();
        CheckIfProcessIsInForeground();
    }

    public bool IsProccessInForeground()
    {
        if (!Connected)
            return false;

        var activeHandle = GetForegroundWindow();
        return activeHandle == _resolumeArenaProcess.MainWindowHandle;
    }

    private void ConnectToProccess()
    {
        ProccessLoop(() =>
        {
            var processes = Process.GetProcessesByName(Name);

            if (processes.Length != 0)
            {
                _resolumeArenaProcess = processes.FirstOrDefault();
                OnProcessConnected?.Invoke(this, new MessageEventArgs() { Message = $"Process '{Name}' connected." });
            }
            else
            {
                _resolumeArenaProcess = null;
                OnProcessConnected?.Invoke(this, new MessageEventArgs() { Message = $"Process '{Name}' disconnected." });
            }
        }, waitForConnection: false);
    }

    public void SetProcessToForeground()
    {
        ProccessLoop(() =>
        {
            SetForegroundWindow(_resolumeArenaProcess.MainWindowHandle);
        }, waitForConnection: true, finishAfterConnectionEstabilished: true);
    }

    private void CheckIfProcessIsInForeground()
    {
        ProccessLoop(() =>
        {
            if (!IsProccessInForeground())
            {
                OnProcessSetToForeground?.Invoke(this, new ProcessVisibilityEventArgs()
                {
                    Message = $"'{Name}' process is in not in foreground",
                    IsInForeground = false
                });
            }
            else
            {
                OnProcessSetToForeground?.Invoke(this, new ProcessVisibilityEventArgs()
                {
                    Message = $"'{Name}' process is in foreground",
                    IsInForeground = true
                });
            }
        }, waitForConnection: true);
    }

    private void ProccessLoop(Action action, bool waitForConnection, bool finishAfterConnectionEstabilished = false)
    {
        Task.Run(() =>
        {
            while (true)
            {
                if (waitForConnection && !Connected) continue;

                action();

                if (finishAfterConnectionEstabilished) return;
                Thread.Sleep(_updateRateMs);
            }
        });
    }
}