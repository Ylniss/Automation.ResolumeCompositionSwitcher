using Automation.ResolumeCompositionSwitcher.Core.Models;
using Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher;
using Automation.ResolumeCompositionSwitcher.WinForms.Controls;

namespace Automation.ResolumeCompositionSwitcher.WinForms
{
    public partial class ResolumeCompositionSwitcher : Form
    {
        private readonly CompositionSwitcher _compositionSwitcher;

        public ResolumeCompositionSwitcher()
        {
            InitializeComponent();

            var compositionParams = new CompositionParams(
                (int)numberOfColumnsNumeric.Value,
                (int)minTimeToChangeMsNumeric.Value,
                (int)maxTimeToChangeMsNumeric.Value);

            _compositionSwitcher = new CompositionSwitcher(compositionParams);

            _compositionSwitcher.OnColumnSwitch += _compositionSwitcher_OnColumnSwitch;
            _compositionSwitcher.OnResolumeApiConnectionChanged += _compositionSwitcher_OnResolumeApiConnectionChanged;
            _compositionSwitcher.OnIntervalTick += _compositionSwitcher_OnIntervalTick;
            _compositionSwitcher.OnBeforeChangeColumnRequest += _compositionSwitcher_OnBeforeChangeColumnRequest;
            _compositionSwitcher.OnAfterChangeColumnRequest += _compositionSwitcher_OnAfterChangeColumnRequest;
        }

        private void _compositionSwitcher_OnBeforeChangeColumnRequest(object? sender, EventArgs e)
        {
            playPauseButton.ToggleLoading();
            connectionStatusLabel.SetText("Connecting to Resolume API...");
        }

        private void _compositionSwitcher_OnAfterChangeColumnRequest(object? sender, EventArgs e)
        {
            playPauseButton.TogglePlay(true);
        }

        private void _compositionSwitcher_OnIntervalTick(object? sender, EventArgs e)
        {
            var elapsedMs = (e as SwitchIntervalEventArgs).IntervalMs;
            nextSwitchMsTextBox.SetText(elapsedMs.ToString());
        }

        private void _compositionSwitcher_OnResolumeApiConnectionChanged(object? sender, EventArgs e)
        {
            var message = (e as MessageEventArgs).Message;
            connectionStatusLabel.SetText(message);

            if (!_compositionSwitcher.SwitchingEnabled)
            {
                playPauseButton.TogglePlay(false);
                nextSwitchMsTextBox.SetText("0");
            }
        }

        private void _compositionSwitcher_OnColumnSwitch(object? sender, EventArgs e)
        {
            var column = (e as SwitchColumnEventArgs).Column;
            currentColumnTextBox.SetText(column.ToString());
        }

        private void playPauseButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (!playPauseButton.Enabled)
                return;

            ToggleSwitcher(playPauseButton.IsPaused);
        }

        private void ToggleSwitcher(bool toggle)
        {
            playPauseButton.TogglePlay(toggle);
            _compositionSwitcher.ToggleSwitching(toggle);
        }

        private void numberOfColumnsNumeric_ValueChanged(object sender, EventArgs e)
        {
            _compositionSwitcher.CompositionParams = new CompositionParams(
                (int)numberOfColumnsNumeric.Value,
                _compositionSwitcher.CompositionParams.MinTimeToChangeMs,
                _compositionSwitcher.CompositionParams.MaxTimeToChangeMs);

            ToggleSwitcher(false);
        }

        private void minTimeToChangeMsNumeric_ValueChanged(object sender, EventArgs e)
        {
            _compositionSwitcher.CompositionParams = new CompositionParams(
                _compositionSwitcher.CompositionParams.NumberOfColumns,
                (int)minTimeToChangeMsNumeric.Value,
                _compositionSwitcher.CompositionParams.MaxTimeToChangeMs);
        }

        private void maxTimeToChangeMsNumeric_ValueChanged(object sender, EventArgs e)
        {
            _compositionSwitcher.CompositionParams = new CompositionParams(
                _compositionSwitcher.CompositionParams.NumberOfColumns,
                _compositionSwitcher.CompositionParams.MinTimeToChangeMs,
                (int)maxTimeToChangeMsNumeric.Value);
        }
    }
}