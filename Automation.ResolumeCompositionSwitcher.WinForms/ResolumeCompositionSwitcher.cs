using Automation.ResolumeCompositionSwitcher.Core;
using Automation.ResolumeCompositionSwitcher.Core.Models;
using Automation.ResolumeCompositionSwitcher.Core.Params;
using Automation.ResolumeCompositionSwitcher.WinForms.Controls;

namespace Automation.ResolumeCompositionSwitcher.WinForms
{
    public partial class ResolumeCompositionSwitcher : Form
    {
        private const string SwitchForwardColumnKey = "{=}";
        private const string SwitchBackwardColumnKey = "{-}";

        private readonly ICompositionSwitcher _compositionSwitcher;

        public ResolumeCompositionSwitcher(ICompositionSwitcher compositionSwitcher)
        {
            InitializeComponent();
            _compositionSwitcher = compositionSwitcher;
            _compositionSwitcher.CompositionParams = new CompositionParams
            {
                NumberOfColumns = (int)numberOfColumnsNumeric.Value,
                MinTimeToChangeMs = (int)minTimeToChangeMsNumeric.Value,
                MaxTimeToChangeMs = (int)maxTimeToChangeMsNumeric.Value
            };

            _compositionSwitcher.ResolumeArenaProcess.OnProcessConnected += ResolumeArenaProcess_OnProcessConnected;
            _compositionSwitcher.ResolumeArenaProcess.OnProcessSetToForeground += ResolumeArenaProcess_OnProcessSetToForeground;
            _compositionSwitcher.OnSwitchColumn += _compositionSwitcher_OnSwitchColumn;
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

        private void _compositionSwitcher_OnSwitchColumn(object? sender, EventArgs e)
        {
            var switchDirection = e as SwitchDirectionEventArgs;

            if (switchDirection.Forward)
            {
                SendKeys.SendWait(SwitchForwardColumnKey);
            }
            else
            {
                SendKeys.SendWait(SwitchBackwardColumnKey);
            }
            currentColumnNumeric.SetValue(_compositionSwitcher.CurrentColumn);

            Thread.Sleep(35);
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

        private void numberOfColumnsNumeric_ValueChanged(object sender, EventArgs e)
        {
            _compositionSwitcher.CompositionParams = new CompositionParams()
            {
                NumberOfColumns = (int)numberOfColumnsNumeric.Value,
                MinTimeToChangeMs = _compositionSwitcher.CompositionParams.MinTimeToChangeMs,
                MaxTimeToChangeMs = _compositionSwitcher.CompositionParams.MaxTimeToChangeMs,
            };

            ToggleSwitcher(false);
        }

        private void minTimeToChangeMsNumeric_ValueChanged(object sender, EventArgs e)
        {
            _compositionSwitcher.CompositionParams = new CompositionParams()
            {
                NumberOfColumns = _compositionSwitcher.CompositionParams.NumberOfColumns,
                MinTimeToChangeMs = (int)minTimeToChangeMsNumeric.Value,
                MaxTimeToChangeMs = _compositionSwitcher.CompositionParams.MaxTimeToChangeMs,
            };
        }

        private void maxTimeToChangeMsNumeric_ValueChanged(object sender, EventArgs e)
        {
            _compositionSwitcher.CompositionParams = new CompositionParams()
            {
                NumberOfColumns = _compositionSwitcher.CompositionParams.NumberOfColumns,
                MinTimeToChangeMs = _compositionSwitcher.CompositionParams.MinTimeToChangeMs,
                MaxTimeToChangeMs = (int)maxTimeToChangeMsNumeric.Value,
            };
        }

        private void currentColumnNumeric_ValueChanged(object sender, EventArgs e)
        {
            _compositionSwitcher.CurrentColumn = (int)currentColumnNumeric.Value;
        }
    }
}