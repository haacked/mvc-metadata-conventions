using ModelMetadataExtensions;
using Xunit;

namespace UnitTests {
    public class ConventionalModelMetadataProviderTests {
        [Fact]
        public void Ctor_WithRequireAttribute_SetsProperty() {
            var provider = new ConventionalModelMetadataProvider(requireAttribute: true);
            Assert.Equal(true, provider.RequireAttribute);
        }

        [Fact]
        public void CreateMetadata_WithFullDisplayAttribute_ReturnsResourceValue() {
            // arrange
            var model = new TestModel { PropertyWithFullDisplayAttribute = "HelloWorld" };
            var provider = new ConventionalModelMetadataProvider(requireAttribute: false);

            // act
            var metadata = provider.GetMetadataForProperty(() => model, model.GetType(), "PropertyWithFullDisplayAttribute");

            // assert
            Assert.Equal("Property with full display attribute.", metadata.DisplayName);
        }

        [Fact]
        public void CreateMetadata_WithNoDisplayAttributeNorResource_ReturnsSpitDisplayName() {
            // arrange
            var model = new { FirstName = "HelloWorld" };
            var provider = new ConventionalModelMetadataProvider(requireAttribute: false);

            // act
            var metadata = provider.GetMetadataForProperty(() => model, model.GetType(), "FirstName");

            // assert
            Assert.Equal("First Name", metadata.DisplayName);
        }

        [Fact]
        public void CreateMetadata_WithDisplayAttributeNorResourceWithName_ReturnsSpecifiedName() {
            // arrange
            var model = new TestModel { PropertyWithDisplayAttributeHavingName = "HelloWorld" };
            var provider = new ConventionalModelMetadataProvider(requireAttribute: false);

            // act
            var metadata = provider.GetMetadataForProperty(() => model, model.GetType(), "PropertyWithDisplayAttributeHavingName");

            // assert
            Assert.Equal("Property That Has A Display Attribute With A Name", metadata.DisplayName);
        }

        [Fact]
        public void CreateMetadata_WithPropertyMatchingResourceKey_ReturnsResourceValue() {
            // arrange
            var model = new TestModel { PropertyWithMatchingResourceKey = "HelloWorld" };
            var provider = new ConventionalModelMetadataProvider(requireAttribute: false);

            // act
            var metadata = provider.GetMetadataForProperty(() => model, model.GetType(), "PropertyWithMatchingResourceKey");

            // assert
            Assert.Equal("Property With Property Name Matching Resource File", metadata.DisplayName);
        }

        [Fact]
        public void CreateMetadata_WithDisplayAttributeMatchingResourceKey_ReturnsResourceValue() {
            // arrange
            var model = new TestModel { PropertyWithDisplayAttributeMatchingResourceKey = "HelloWorld" };
            var provider = new ConventionalModelMetadataProvider(requireAttribute: false);

            // act
            var metadata = provider.GetMetadataForProperty(() => model, model.GetType(), "PropertyWithDisplayAttributeMatchingResourceKey");

            // assert
            Assert.Equal("Property With Display Name From Resource File", metadata.DisplayName);
        }
    }
}
