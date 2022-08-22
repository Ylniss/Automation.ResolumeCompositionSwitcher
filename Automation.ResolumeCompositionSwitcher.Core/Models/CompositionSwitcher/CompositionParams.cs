using Ardalis.GuardClauses;

namespace Automation.ResolumeCompositionSwitcher.Core.Models.CompositionSwitcher;

public record CompositionParams
{
    public int NumberOfColumns { get; }
    public int MinTimeToChangeMs { get; }
    public int MaxTimeToChangeMs { get; }

    public CompositionParams(int numberOfColumns, int minTimeToChangeMs, int maxTimeToChangeMs)
    {
        Guard.Against.Null(numberOfColumns, nameof(numberOfColumns));
        Guard.Against.Null(minTimeToChangeMs, nameof(minTimeToChangeMs));
        Guard.Against.Null(maxTimeToChangeMs, nameof(maxTimeToChangeMs));

        Guard.Against.NegativeOrZero(numberOfColumns, nameof(numberOfColumns));
        Guard.Against.NegativeOrZero(minTimeToChangeMs, nameof(minTimeToChangeMs));
        Guard.Against.NegativeOrZero(maxTimeToChangeMs, nameof(maxTimeToChangeMs));

        NumberOfColumns = numberOfColumns;
        MinTimeToChangeMs = minTimeToChangeMs;
        MaxTimeToChangeMs = maxTimeToChangeMs;
    }
}