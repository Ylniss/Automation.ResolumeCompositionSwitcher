namespace Automation.ResolumeCompositionSwitcher.UnitTests
{
    public class ArrayExtensionsTests
    {
        [Theory]
        [InlineData(4, new[] { 1, 2, 3, 4 })]
        public void Shuffle_ShouldBeExpectedResult(int expectedCount, int[] array)
        {
            array = array.Shuffle<int>();

            var result = solution.ContainsDuplicate(array);

            result.ShouldBe(expectedResult);
        }
    }
}