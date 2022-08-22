using Automation.ResolumeCompositionSwitcher.Core.Models;
using Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher;
using Automation.ResolumeCompositionSwitcher.WinForms.Controls;
using System.Diagnostics;

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
            _compositionSwitcher.OnRandomizedSwitchInterval += _compositionSwitcher_OnRandomizedSwitchInterval;
        }

        private void _compositionSwitcher_OnResolumeApiConnectionChanged(object? sender, EventArgs e)
        {
            var message = (e as MessageEventArgs).Message;
            connectionStatusLabel.SetText(message);
        }

        private void _compositionSwitcher_OnColumnSwitch(object? sender, EventArgs e)
        {
            var column = (e as SwitchColumnEventArgs).Column;
            currentColumnTextBox.SetText(column.ToString());
        }

        private void _compositionSwitcher_OnRandomizedSwitchInterval(object? sender, EventArgs e)
        {
            var sleepTimeMs = (e as SwitchIntervalEventArgs).IntervalMs;

            Task.Run(() =>
            {
                var stopWatch = new Stopwatch();

                stopWatch.Start();
                var elapsedMs = sleepTimeMs;
                while (elapsedMs > 0)
                {
                    elapsedMs = sleepTimeMs - (int)stopWatch.ElapsedMilliseconds;
                    nextSwitchMsTextBox.SetText(elapsedMs.ToString());
                }
                stopWatch.Stop();
            });
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