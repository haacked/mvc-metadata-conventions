using ModelMetadataExtensions.Extensions;
using Xunit;

namespace UnitTests
{
    public class StringExtensionTests
    {
        [Fact]
        public void SplitUpperCaseToString_WithPascalCase_SplitsWithSpaces()
        {
            string original = "ThisIsPascalCased";

            string result = original.SplitUpperCaseToString();

            Assert.Equal("This Is Pascal Cased", result);
        }

        [Fact]
        public void SplitUpperCaseToString_WithCamelCase_SplitsWithSpaces()
        {
            string original = "thisIsCamelCased";

            string result = original.SplitUpperCaseToString();

            Assert.Equal("this Is Camel Cased", result);
        }

        [Fact]
        public void SplitUpperCaseToString_WithAlreadySplitString_DoesNotReSplit()
        {
            string original = "This Is a Normal Sentence";

            string result = original.SplitUpperCaseToString();

            Assert.Equal("This Is a Normal Sentence", result);
        }

        [Fact]
        public void SplitUpperCaseToString_WithNull_ReturnsNull()
        {
            string original = null;

            string result = original.SplitUpperCaseToString();

            Assert.Equal(null, result);
        }

        [Fact]
        public void SplitUpperCaseToString_WithEmptyString_ReturnsEmptyString()
        {
            string original = string.Empty;

            string result = original.SplitUpperCaseToString();

            Assert.Equal(string.Empty, result);
        }
    }
}