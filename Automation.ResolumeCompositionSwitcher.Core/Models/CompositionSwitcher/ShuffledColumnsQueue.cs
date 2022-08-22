using Automation.ResolumeCompositionSwitcher.Core.Extensions;
using System.Collections.ObjectModel;

namespace Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher;

public class ShuffledColumnsQueue : Collection<int>
{
    private readonly Queue<int> _columnsQueue = new Queue<int>();

    private const int _queueSetsCount = 10;

    private int _columnsCount;

    public ShuffledColumnsQueue(int columnsCount)
    {
        _columnsCount = columnsCount;

        for (int i = 0; i < _queueSetsCount; i++)
        {
            Repopulate();
        }
    }

    public int Dequeue()
    {
        if (_columnsQueue.Count == 1)
        {
            Repopulate();
        }

        return _columnsQueue.Dequeue();
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
            _columnsQueue.Enqueue(column);
        }
    }
}