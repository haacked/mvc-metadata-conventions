using ModelMetadataExtensions.Extensions;
using Xunit;

namespace UnitTests {
    public class StringExtensionTests {
        [Fact]
        public void SplitUpperCaseToString_WithPascalCase_SplitsWithSpaces() {
            // arrange
            var original = "ThisIsPascalCased";

            // act
            var result = original.SplitUpperCaseToString();

            // assert
            Assert.Equal("This Is Pascal Cased", result);
        }

        [Fact]
        public void SplitUpperCaseToString_WithCamelCase_SplitsWithSpaces() {
            // arrange
            var original = "thisIsCamelCased";

            // act
            var result = original.SplitUpperCaseToString();

            // assert
            Assert.Equal("this Is Camel Cased", result);
        }

        [Fact]
        public void SplitUpperCaseToString_WithAlreadySplitString_DoesNotReSplit() {
            // arrange
            var original = "This Is a Normal Sentence";

            // act
            var result = original.SplitUpperCaseToString();

            // assert
            Assert.Equal("This Is a Normal Sentence", result);
        }

        [Fact]
        public void SplitUpperCaseToString_WithNull_ReturnsNull() {
            // arrange
            string original = null;

            // act
            var result = original.SplitUpperCaseToString();

            // assert
            Assert.Equal(null, result);
        }

        [Fact]
        public void SplitUpperCaseToString_WithEmptyString_ReturnsEmptyString() {
            // arrange
            string original = string.Empty;

            // act
            var result = original.SplitUpperCaseToString();

            // assert
            Assert.Equal(string.Empty, result);
        }
    }
}
