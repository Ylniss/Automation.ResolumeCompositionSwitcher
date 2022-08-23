namespace Automation.ResolumeCompositionSwitcher.WinForms.Controls;

public class PlayPauseButton : Button
{
    public bool Play { get; set; }
    public bool IsPaused => !Play;

    public void TogglePlay(bool play)
    {
        if (play)
        {
            SetButtonImage("play");
        }
        else
        {
            SetButtonImage("pause");
        }

        Play = play;
    }

    public void ToggleLoading()
    {
        SetButtonImage("loading");
    }

    private void SetButtonImage(string imageName)
    {
        _ = imageName switch
        {
            "play" => BackgroundImage = Properties.Resources.pause1,
            "loading" => BackgroundImage = Properties.Resources.loading,
            _ => BackgroundImage = Properties.Resources.play_button_arrowhead1
        };
    }
}