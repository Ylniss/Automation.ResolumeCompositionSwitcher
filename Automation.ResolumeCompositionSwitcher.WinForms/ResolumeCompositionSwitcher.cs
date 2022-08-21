using Automation.ResolumeCompositionSwitcher.Core;
using Automation.ResolumeCompositionSwitcher.Core.Models;
using Automation.ResolumeCompositionSwitcher.Core.Params;
using Automation.ResolumeCompositionSwitcher.WinForms.Controls;
using System.Diagnostics;

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

            Thread.Sleep(_compositionSwitcher.SwitchIntervalMs);
        }

        private void playPauseButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (!playPauseButton.Enabled || _compositionSwitcher.ResolumeArenaProcess.IsProccessInForeground())
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