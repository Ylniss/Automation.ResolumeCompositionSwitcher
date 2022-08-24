using System.Diagnostics;

namespace Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher.ResolumeProcess;

public class ResolumeArenaProcess
{
    public string Name => "Arena";
    public bool Connected => _process != null;

    private const int UpdateRateMs = 3000;

    public event EventHandler<MessageEventArgs> OnProcessConnectionStatusChanged;

    private Process _process;

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

                await Task.Delay(UpdateRateMs);
            }
        });
    }
}