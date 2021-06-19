using Asterisk.Tower;
using Asterisk.Tower.Gateway;
using Dependency;
using FluentAssertions;
using Shadow.Quack;
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
        public void TestInRowsReturnsValidArray(int rows, string[] expectations)
        {
            InjectConfigDependency('*', ' ');

            rows
                .CreateAsteriskTower()
                .Should()
                .BeEquivalentTo(expectations);
        }

        [Theory]
        [InlineData(1, new[] { "#" })]
        [InlineData(2, new[] { "-#-", "###" })]
        [InlineData(0, new string[] { })]
        [InlineData(3, new[] { "--#--", "-###-", "#####" })]
        [InlineData(4, new[] { "---#---", "--###--", "-#####-", "#######" })]
        public void TestWithAltConfig(int rows, string[] expectations)
        {
            InjectConfigDependency('#', '-');

            rows
                .CreateAsteriskTower()
                .Should()
                .BeEquivalentTo(expectations);
        }

        private static void InjectConfigDependency(char brick, char padding)
        {
            Shelf.Clear();
            Shelf.ShelveInstance<IConfig>(Duck.Implement<IConfig>(new
            {
                Brick = brick,
                Padding = padding
            }));
        }
    }
}
