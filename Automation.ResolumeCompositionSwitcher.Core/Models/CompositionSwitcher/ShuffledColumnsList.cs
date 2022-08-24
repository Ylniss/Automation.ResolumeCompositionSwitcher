using Automation.ResolumeCompositionSwitcher.Core.Extensions;
using System.Collections.ObjectModel;

namespace Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher;

public class ShuffledColumnsList : Collection<int>
{
    private readonly List<int> _columns = new List<int>();

    private const int _queueSetsCount = 10;

    private int _columnsCount;

    private int _currentIndex = 0;

    public ShuffledColumnsList(int columnsCount)
    {
        _columnsCount = columnsCount;

        for (int i = 0; i < _queueSetsCount; i++)
        {
            Repopulate();
        }
    }

    public int Next()
    {
        if (_currentIndex == _columnsCount - 1)
            Repopulate();

        return _columns[_currentIndex++];
    }

    public int Previous()
    {
        _currentIndex--;
        if (_currentIndex < 0) _currentIndex = 0;

        return _columns[_currentIndex];
    }

    private void Repopulate()
    {
        var columns = new int[_columnsCount];

        for (int i = 0; i < _columnsCount; i++)
        {
            columns[i] = i + 1;
        }

        columns.Shuffle();

        foreach (var column in columns)
        {
            _columns.Add(column);
        }
    }
}