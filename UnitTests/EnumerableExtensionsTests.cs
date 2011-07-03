using ModelMetadataExtensions.Extensions;
using Xunit;

namespace UnitTests {
    public class EnumerableExtensionsTests {
        [Fact]
        public void Replace_WithEnumeration_ReturnsNewEnumerationWithItemReplaced() {
            // arrange
            var testModel = new TestModel { Id = 2 };
            var replacement = new TestModel { Id = 5 };
            var items = new TestModel[] {
                new TestModel { Id = 1 },
                testModel,
                new TestModel { Id = 3 },
                new TestModel { Id = 4 },
            };

            // act
            var newItems = items.Replace(testModel, replacement);

            // assert
            Assert.Contains(replacement, newItems);
            Assert.DoesNotContain(testModel, newItems);
        }

        [Fact]
        public void Replace_WithEnumerationAndNullSource_ReturnsNewEnumerationWithItemReplaced() {
            // arrange
            var replacement = new TestModel { Id = 5 };
            var items = new TestModel[] {
                new TestModel { Id = 1 },
                new TestModel { Id = 3 },
                new TestModel { Id = 4 },
            };

            // act
            var newItems = items.Replace(null, replacement);

            // assert
            Assert.Contains(replacement, newItems);
        }
    }
}
