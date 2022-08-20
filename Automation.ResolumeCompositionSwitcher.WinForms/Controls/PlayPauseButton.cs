namespace Automation.ResolumeCompositionSwitcher.WinForms.Controls;

public class PlayPauseButton : Button
{
    public bool Play { get; set; }
    public bool IsPaused => !Play;

    public void TogglePlay(bool play)
    {
        SetButtonImage(play);
        Play = play;
    }

    private void SetButtonImage(bool play)
    {
        if (play)
        {
            BackgroundImage = Properties.Resources.pause1;
        }
        else
        {
            BackgroundImage = Properties.Resources.play_button_arrowhead1;
        }
    }
}