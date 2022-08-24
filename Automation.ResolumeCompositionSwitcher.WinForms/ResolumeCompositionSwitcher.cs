using Automation.ResolumeCompositionSwitcher.Core.Constants;
using Automation.ResolumeCompositionSwitcher.Core.Models;
using Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher;
using Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher.StopTimer;
using Automation.ResolumeCompositionSwitcher.Core.Persistence;
using Automation.ResolumeCompositionSwitcher.WinForms.Controls;

namespace Automation.ResolumeCompositionSwitcher.WinForms
{
    public partial class ResolumeCompositionSwitcher : Form
    {
        private readonly CompositionSwitcher _compositionSwitcher;
        private readonly ICompositionSwitcherStorageService _storageService;

        public ResolumeCompositionSwitcher(ICompositionSwitcherStorageService storageService)
        {
            InitializeComponent();

            _storageService = storageService;
            _storageService.OnException += _storageService_OnException;

            var compositionParams = _storageService.TryLoadCompositionParams();

            _compositionSwitcher = new CompositionSwitcher(compositionParams);

            _compositionSwitcher.OnColumnSwitch += _compositionSwitcher_OnColumnSwitch;
            _compositionSwitcher.OnResolumeApiConnectionChanged += _compositionSwitcher_OnResolumeApiConnectionChanged;
            _compositionSwitcher.OnResolumeProcessConnectionChanged += _compositionSwitcher_OnResolumeProcessConnectionChanged;
            _compositionSwitcher.OnIntervalTick += _compositionSwitcher_OnIntervalTick;
            _compositionSwitcher.OnBeforeChangeColumnRequest += _compositionSwitcher_OnBeforeChangeColumnRequest;
            _compositionSwitcher.OnAfterChangeColumnRequest += _compositionSwitcher_OnAfterChangeColumnRequest;

            numberOfColumnsNumeric.Value = compositionParams.NumberOfColumns;
            minTimeToChangeMsNumeric.Value = compositionParams.MinTimeToChangeMs;
            maxTimeToChangeMsNumeric.Value = compositionParams.MaxTimeToChangeMs;

            UpdateMinimumAndMaximumOnNumerics();
        }

        private void _storageService_OnException(object? sender, MessageEventArgs e)
        {
            MessageBox.Show(e.Message, "LocalStorage file corrupted");
        }

        private void _compositionSwitcher_OnBeforeChangeColumnRequest(object? sender, MessageEventArgs e)
        {
            playPauseButton.ToggleLoading();
            connectionStatusLabel.SetText(e.Message);
        }

        private void _compositionSwitcher_OnAfterChangeColumnRequest(object? sender, EventArgs e) =>
            playPauseButton.TogglePlay(true);

        private void _compositionSwitcher_OnIntervalTick(object? sender, ElapsedMsEventArgs e) =>
            nextSwitchMsTextBox.SetText(e.ElapsedMs.ToString());

        private void _compositionSwitcher_OnResolumeApiConnectionChanged(object? sender, MessageEventArgs e)
        {
            connectionStatusLabel.SetText(e.Message);

            if (_compositionSwitcher.State != CompositionSwitcherState.Running)
                playPauseButton.TogglePlay(false);
        }

        private void _compositionSwitcher_OnResolumeProcessConnectionChanged(object? sender, MessageEventArgs e)
        {
            processStatusLabel.SetText(e.Message);

            if (!_compositionSwitcher.ProcessConnected && _compositionSwitcher.State != CompositionSwitcherState.Loading)
            {
                ToggleSwitcher(false);
                currentColumnTextBox.SetText("0");
                connectionStatusLabel.SetText(AppMessages.CompositionDisconnectedMessage);
            }
        }

        private void _compositionSwitcher_OnColumnSwitch(object? sender, SwitchColumnEventArgs e) =>
            currentColumnTextBox.SetText(e.Column.ToString());

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
            var numberOfColumns = (int)numberOfColumnsNumeric.Value;
            _compositionSwitcher.CompositionParams.NumberOfColumns = numberOfColumns;

            _storageService.SaveNumberOfColumns(numberOfColumns);

            ToggleSwitcher(false);
        }

        private bool _skipNumericsEvent = false;

        private void minTimeToChangeMsNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (_skipNumericsEvent) return;

            var minTimeToChangeMs = (int)minTimeToChangeMsNumeric.Value;
            _compositionSwitcher.CompositionParams.MinTimeToChangeMs = minTimeToChangeMs;

            _storageService.SaveMinTimeToChangeMs(minTimeToChangeMs);

            UpdateMinimumAndMaximumOnNumerics();
        }

        private void maxTimeToChangeMsNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (_skipNumericsEvent) return;

            var maxTimeToChangeMs = (int)maxTimeToChangeMsNumeric.Value;
            _compositionSwitcher.CompositionParams.MaxTimeToChangeMs = maxTimeToChangeMs;

            _storageService.SaveMaxTimeToChangeMs(maxTimeToChangeMs);

            UpdateMinimumAndMaximumOnNumerics();
        }

        private void UpdateMinimumAndMaximumOnNumerics()
        {
            _skipNumericsEvent = true;
            minTimeToChangeMsNumeric.Maximum = _compositionSwitcher.CompositionParams.MaxTimeToChangeMs;
            maxTimeToChangeMsNumeric.Minimum = _compositionSwitcher.CompositionParams.MinTimeToChangeMs;
            _skipNumericsEvent = false;
        }
    }
}