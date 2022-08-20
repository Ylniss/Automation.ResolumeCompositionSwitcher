using Automation.ResolumeCompositionSwitcher.Core;
using Automation.ResolumeCompositionSwitcher.Core.Models;
using Automation.ResolumeCompositionSwitcher.Core.Params;
using Automation.ResolumeCompositionSwitcher.WinForms.Controls;

namespace Automation.ResolumeCompositionSwitcher.WinForms
{
    public partial class ResolumeCompositionSwitcher : Form
    {
        private const string SwitchColumnKey = "{=}";

        private readonly ICompositionSwitcher _compositionSwitcher;

        public ResolumeCompositionSwitcher(ICompositionSwitcher compositionSwitcher)
        {
            InitializeComponent();
            _compositionSwitcher = compositionSwitcher;
            _compositionSwitcher.CompositionParams = new CompositionParams
            {
                NumberOfColumns = 77,
                MinTimeToChangeMs = 1000,
                MaxTimeToChangeMs = 3000
            };

            _compositionSwitcher.ResolumeArenaProcess.OnProcessConnected += ResolumeArenaProcess_OnProcessConnected;
            _compositionSwitcher.ResolumeArenaProcess.OnProcessSetToForeground += ResolumeArenaProcess_OnProcessSetToForeground;
            _compositionSwitcher.OnSwitchToNextColumn += _compositionSwitcher_OnSwitchToNextColumn;
        }

        private void ResolumeArenaProcess_OnProcessConnected(object? sender, EventArgs e)
        {
            var text = (e as MessageEventArgs).Message;
            connectionStatusLabel.SetText(text);
            playPauseButton.SetEnabled(_compositionSwitcher.ResolumeArenaProcess.Connected);
        }

        private void ResolumeArenaProcess_OnProcessSetToForeground(object? sender, EventArgs e)
        {
            var processVisibility = e as ProcessVisibilityEventArgs;
            isAppInForegroundLabel.SetText(processVisibility.Message);

            if (!processVisibility.IsInForeground)
            {
                ToggleSwitcher(false);
            }
        }

        private void _compositionSwitcher_OnSwitchToNextColumn(object? sender, EventArgs e)
        {
            SendKeys.SendWait(SwitchColumnKey);
        }

        private void playPauseButton_Click(object sender, EventArgs e)
        {
            if (!playPauseButton.Enabled)
                return;

            if (playPauseButton.IsPaused)
            {
                _compositionSwitcher.ResolumeArenaProcess.SetProcessToForeground();
                ToggleSwitcher(true);
            }
            else
            {
                ToggleSwitcher(false);
            }
        }

        private void ToggleSwitcher(bool toggle)
        {
            playPauseButton.TogglePlay(toggle);
            _compositionSwitcher.ToggleSwitching(toggle);
        }
    }
}