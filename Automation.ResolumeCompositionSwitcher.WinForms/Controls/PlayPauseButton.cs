namespace Automation.ResolumeCompositionSwitcher.WinForms.Controls;

public class PlayPauseButton : Button
{
    public bool Play { get; set; }
    public bool IsPaused => !Play;

    private PictureBox _loadingPictureBox;

    public PlayPauseButton(PictureBox loadingPictureBox)
    {
        _loadingPictureBox = loadingPictureBox;
    }

    public void TogglePlay(bool play)
    {
        _loadingPictureBox.SetVisible(false);
        this.SetVisible(true);
        SetButtonImage(play);

        Play = play;
    }

    public void ToggleLoading()
    {
        this.SetVisible(false);
        _loadingPictureBox.SetVisible(true);
    }

    private void SetButtonImage(bool play)
    {
        _ = play switch
        {
            true => BackgroundImage = Properties.Resources.pause1,
            false => BackgroundImage = Properties.Resources.play_button_arrowhead1,
        };
    }
}