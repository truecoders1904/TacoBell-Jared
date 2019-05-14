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
        public void ShouldParse(string str)
        {
            // TODO: Complete Should Parse
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", null)]
        public void ShouldFailParse(string str, ITrackable expected)
        {/*
            // Arrange
            TacoParser tacoparser = new TacoParser();

            // Act
            ITrackable actual = tacoparser.Parse(str);

            // Assert
            Assert.Equal(expected, actual);*/
        }
    }
}
