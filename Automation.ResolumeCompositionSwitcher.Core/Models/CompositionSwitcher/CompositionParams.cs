using Ardalis.GuardClauses;

namespace Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher;

public record CompositionParams
{
    private int _numberOfColumns;

    public event EventHandler? OnNumberOfColumnsChanged;

    public int NumberOfColumns
    {
        get => _numberOfColumns;
        set
        {
            Guard.Against.Null(value, nameof(value));
            Guard.Against.NegativeOrZero(value, nameof(value));

            _numberOfColumns = value;
            OnNumberOfColumnsChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private int _minTimeToChangeMs;
    public int MinTimeToChangeMs
    {
        get => _minTimeToChangeMs;
        set
        {
            Guard.Against.Null(value, nameof(value));
            Guard.Against.NegativeOrZero(value, nameof(value));
            if (_maxTimeToChangeMs != 0 && value > _maxTimeToChangeMs)
                throw new ArgumentOutOfRangeException(nameof(value), "Minimum time cannot be greater than maximum time");

            _minTimeToChangeMs = value;
        }
    }

    private int _maxTimeToChangeMs;
    public int MaxTimeToChangeMs
    {
        get => _maxTimeToChangeMs;
        set
        {
            Guard.Against.Null(value, nameof(value));
            Guard.Against.NegativeOrZero(value, nameof(value));
            if (_minTimeToChangeMs != 0 && value < _minTimeToChangeMs)
                throw new ArgumentOutOfRangeException(nameof(value), "Maximum time cannot be less than minimum time");

            _maxTimeToChangeMs = value;
        }
    }

    public CompositionParams(int numberOfColumns, int minTimeToChangeMs, int maxTimeToChangeMs)
    {
        NumberOfColumns = numberOfColumns;
        MinTimeToChangeMs = minTimeToChangeMs;
        MaxTimeToChangeMs = maxTimeToChangeMs;
    }
}