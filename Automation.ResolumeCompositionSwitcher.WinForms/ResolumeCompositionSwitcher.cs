using Automation.ResolumeCompositionSwitcher.Core.Models;
using Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher;
using Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher.ResolumeArenaProcessWrapper;
using Automation.ResolumeCompositionSwitcher.WinForms.Controls;
using System.Diagnostics;

namespace Automation.ResolumeCompositionSwitcher.WinForms
{
    public partial class ResolumeCompositionSwitcher : Form
    {
        private const string SwitchBackwardColumnKey = "{[}";
        private const string SwitchForwardColumnKey = "{]}";

        private readonly CompositionSwitcher _compositionSwitcher;

        public ResolumeCompositionSwitcher()
        {
            InitializeComponent();

            var compositionParams = new CompositionParams(
                (int)numberOfColumnsNumeric.Value,
                (int)minTimeToChangeMsNumeric.Value,
                (int)maxTimeToChangeMsNumeric.Value);

            _compositionSwitcher = new CompositionSwitcher(compositionParams);

            _compositionSwitcher.ResolumeArenaProcess.OnProcessConnectionStatusChanged += ResolumeArenaProcess_OnProcessConnectionStatusChanged;
            _compositionSwitcher.ResolumeArenaProcess.OnProcessForegroundChanged += ResolumeArenaProcess_OnProcessForegroundChanged;
            _compositionSwitcher.OnSwitchColumn += _compositionSwitcher_OnSwitchColumn;
            _compositionSwitcher.OnRandomizedSleepTime += _compositionSwitcher_OnRandomizedSleepTime;
        }

        private void _compositionSwitcher_OnRandomizedSleepTime(object? sender, EventArgs e)
        {
            var sleepTimeMs = (e as SleepTimeEventArgs).SleepTimeMs;

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

        private void ResolumeArenaProcess_OnProcessConnectionStatusChanged(object? sender, EventArgs e)
        {
            var text = (e as MessageEventArgs).Message;
            connectionStatusLabel.SetText(text);
            playPauseButton.SetEnabled(_compositionSwitcher.ResolumeArenaProcess.Connected);
        }

        private void ResolumeArenaProcess_OnProcessForegroundChanged(object? sender, EventArgs e)
        {
            var processVisibility = e as ProcessForegroundEventArgs;
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

            Thread.Sleep(_compositionSwitcher.SwitchIntervalMs);
        }

        private void playPauseButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (!playPauseButton.Enabled || _compositionSwitcher.ResolumeArenaProcess.IsInForeground())
                return;

            if (playPauseButton.IsPaused)
            {
                _compositionSwitcher.ResolumeArenaProcess.SetToForeground();
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

        private void currentColumnNumeric_ValueChanged(object sender, EventArgs e)
        {
            _compositionSwitcher.CurrentColumn = (int)currentColumnNumeric.Value;
        }
    }
}