using FluentAssertions;
using Xunit;

namespace Asterisk.Kata.Tests
{
    public class TestAsteriskTower
    {
        [Theory]
        [InlineData(1, new [] {"*"})]
        [InlineData(2, new[] { " * ", "***" })]
        [InlineData(0, new string[] {})]
        [InlineData(3, new[] { "  *  ", " *** ", "*****" })]
        [InlineData(4, new[] { "   *   ", "  ***  ", " ***** ", "*******" })]
        public void TestInRowsReturnsValidArray(int rows, string[] expectations) => 
            rows
                .CreateAsteriskTower()
                .Should()
                .BeEquivalentTo(expectations);
    }
}
