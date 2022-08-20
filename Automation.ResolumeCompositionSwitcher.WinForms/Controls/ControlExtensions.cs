namespace Automation.ResolumeCompositionSwitcher.WinForms.Controls;

public static class ControlExtensions
{
    public static void SetText(this Control control, string text)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(new MethodInvoker(() => { control.Text = text; }));
        }
    }

    public static void SetEnabled(this Control control, bool enabled)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(new MethodInvoker(() => { control.Enabled = enabled; control.BackColor = enabled ? Color.Gray : Color.DimGray; }));
        }
    }

    public static void SetValue(this NumericUpDown numeric, int value)
    {
        if (numeric.InvokeRequired)
        {
            numeric.Invoke(new MethodInvoker(() => { numeric.Value = value; }));
        }
    }
}