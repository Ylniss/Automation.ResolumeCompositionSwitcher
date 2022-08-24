using System.Diagnostics;

namespace Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher.ResolumeProcess;

public class ResolumeArenaProcess
{
    public string Name => "Arena";
    public bool Connected => _process != null;

    public event EventHandler OnProcessConnectionStatusChanged;

    private Process _process;
    private int _updateRateMs = 100;

    public ResolumeArenaProcess()
    {
        UpdateProcessConnectionStatus();
    }

    private void UpdateProcessConnectionStatus()
    {
        Task.Run(async () =>
        {
            while (true)
            {
                var processes = Process.GetProcessesByName(Name);

                if (processes.Length != 0)
                {
                    _process = processes.FirstOrDefault();
                    OnProcessConnectionStatusChanged?.Invoke(this, new MessageEventArgs() { Message = $"Process '{Name}' found." });
                }
                else
                {
                    _process = null;
                    OnProcessConnectionStatusChanged?.Invoke(this, new MessageEventArgs() { Message = $"Process '{Name}' not found." });
                }

                await Task.Delay(_updateRateMs);
            }
        });
    }
}