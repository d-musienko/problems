using System.Collections.Immutable;
using System.Globalization;
using Xunit;

namespace Problems.Logical.FindNumberAtPositionBySequence;

public class FindNumberAtPositionBySequenceDm
{
    public int FindNumber(ImmutableArray<int> numbers, int position)
    {
        var tokens = numbers.Select(d => d.ToString(CultureInfo.InvariantCulture)).ToList();
        tokens.Sort((a, b) => String.CompareOrdinal(b + a, a + b));
        return int.Parse(tokens[position-1]);
    }

    [Theory]
    [InlineData(99, 15, 87)]
    [InlineData(99, 28, 75)]
    [InlineData(99, 99, 10)]
    [InlineData(89, 17, 76)]
    [InlineData(79, 35, 50)]
    public void Test(int max, int position, int expected)
    {
        var sequence = Enumerable.Range(1, max).ToImmutableArray();

        Assert.Equal(expected, FindNumber(sequence, position));
    }
}