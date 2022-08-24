namespace Automation.ResolumeCompositionSwitcher.Core.Extensions;

public static class ArrayExtensions
{
    public static T[] Shuffle<T>(this T[] array)
    {
        var random = new Random((int)DateTime.Now.Ticks);
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = random.Next(0, i - 1);
            var e = array[i];
            array[i] = array[j];
            array[j] = e;
        }
        return array;
    }
}