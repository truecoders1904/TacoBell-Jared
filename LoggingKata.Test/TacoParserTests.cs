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
        [InlineData("0, 0, Taco Bell Warrior", 0, 0, "Taco Bell Warrior")]
        [InlineData("-90, 180, Taco Bell Gardendale", -90, 180, "Taco Bell Gardendale")]
        [InlineData("90, -180, Taco Bell Cullman", 90, -180, "Taco Bell Cullman")]
        public void ShouldParse(string str, double expectedLat, double expectedLon, string expectedName)
        {
         
            // Arrange
            TacoParser tacoparser = new TacoParser();

            // Act
            ITrackable actual = tacoparser.Parse(str);

            // Assert
            Assert.Equal(expectedLat, actual.Location.Latitude);
            Assert.Equal(expectedLon, actual.Location.Longitude);
            Assert.Equal(expectedName, actual.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("-91, 50, Taco Bell Warrior")]
        [InlineData("91, 50, Taco Bell Warrior")]
        [InlineData("50, -181, Taco Bell Warrior")]
        [InlineData("50, 181, Taco Bell Warrior")]
        [InlineData("50, 50, ")]
        [InlineData("50, 50,")]
        [InlineData(", 50, Taco Bell Warrior")]
        [InlineData("50,, Taco Bell Warrior")]
        [InlineData("taco, 50, Taco Bell Warrior")]
        [InlineData("50, bell, Taco Bell Warrior")]
        [InlineData("50, bell, Wendy's Gardendale")]
        [InlineData("50, bell, Taco Mama Downtown Birmingham")]
        [InlineData("50, 50, Taco Bell Warrior, oops too many parameters")]
        public void ShouldFailParse(string str)
        {
            // Arrange
            TacoParser tacoparser = new TacoParser();

            // Act
            ITrackable actual = tacoparser.Parse(str);

            // Assert
            Assert.Null(actual);
        }
    }
}
