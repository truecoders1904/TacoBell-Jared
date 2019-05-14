using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
        }

        [Theory]
        [InlineData("Example")]
        [InlineData("50, 50, Taco Bell Warrior", null)]
        [InlineData("0, 180, Taco Bell Gardendale", null)]
        [InlineData("90, 0, Taco Bell Cullman", null)]
        public void ShouldParse(string str, ITrackable expected)
        {
            // Arrange
            TacoParser tacoparser = new TacoParser();

            // Act
            ITrackable actual = tacoparser.Parse(str);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", null)]
        [InlineData("-1, 50, Taco Bell Warrior", null)]
        [InlineData("50, -1, Taco Bell Warrior", null)]
        [InlineData("91, 50, Taco Bell Warrior", null)]
        [InlineData("50, 181, Taco Bell Warrior", null)]
        [InlineData("50, 50,", null)]
        [InlineData(", 50, Taco Bell Warrior", null)]
        [InlineData("50,, Taco Bell Warrior", null)]
        [InlineData("taco, 50, Taco Bell Warrior", null)]
        [InlineData("50, bell, Taco Bell Warrior", null)]
        public void ShouldFailParse(string str, ITrackable expected)
        {
            // Arrange
            TacoParser tacoparser = new TacoParser();

            // Act
            ITrackable actual = tacoparser.Parse(str);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
