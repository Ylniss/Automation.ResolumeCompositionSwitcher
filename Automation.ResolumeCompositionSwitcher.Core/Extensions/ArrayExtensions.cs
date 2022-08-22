namespace Automation.ResolumeCompositionSwitcher.Core.Extensions;

public static class ArrayExtensions
{
    public static T[] Shuffle<T>(this T[] list)
    {
        var random = new Random((int)DateTime.Now.Ticks);
        for (int i = list.Length - 1; i > 0; i--)
        {
            int j = random.Next(0, i - 1);
            var e = list[i];
            list[i] = list[j];
            list[j] = e;
        }
        return list;
    }
}