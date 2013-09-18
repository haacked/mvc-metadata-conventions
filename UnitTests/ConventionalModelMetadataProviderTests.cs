using ModelMetadataExtensions;
using Xunit;

namespace UnitTests
{
    public class ConventionalModelMetadataProviderTests
    {
        [Fact]
        public void Ctor_WithRequireAttribute_SetsProperty()
        {
            var provider = new ConventionalModelMetadataProvider(true);
            Assert.Equal(true, provider.RequireConventionAttribute);
        }

        [Fact]
        public void CreateMetadata_WithFullDisplayAttribute_ReturnsResourceValue()
        {
            var model = new TestModel {PropertyWithFullDisplayAttribute = "HelloWorld"};
            var provider = new ConventionalModelMetadataProvider(false);

            var metadata = provider.GetMetadataForProperty(() => model, model.GetType(),
                "PropertyWithFullDisplayAttribute");

            Assert.Equal("Property with full display attribute.", metadata.DisplayName);
        }

        [Fact]
        public void CreateMetadata_WithNoDisplayAttributeNorResource_ReturnsSpitDisplayName()
        {
            var model = new {FirstName = "HelloWorld"};
            var provider = new ConventionalModelMetadataProvider(false);

            var metadata = provider.GetMetadataForProperty(() => model, model.GetType(), "FirstName");

            Assert.Equal("First Name", metadata.DisplayName);
        }

        [Fact]
        public void CreateMetadata_WithDisplayAttributeNorResourceWithName_ReturnsSpecifiedName()
        {
            var model = new TestModel {PropertyWithDisplayAttributeHavingName = "HelloWorld"};
            var provider = new ConventionalModelMetadataProvider(false);

            var metadata = provider.GetMetadataForProperty(() => model, model.GetType(),
                "PropertyWithDisplayAttributeHavingName");

            Assert.Equal("Property That Has A Display Attribute With A Name", metadata.DisplayName);
        }

        [Fact]
        public void CreateMetadata_WithPropertyMatchingResourceKey_ReturnsResourceValue()
        {
            var model = new TestModel {PropertyWithMatchingResourceKey = "HelloWorld"};
            var provider = new ConventionalModelMetadataProvider(false);

            var metadata = provider.GetMetadataForProperty(() => model, model.GetType(),
                "PropertyWithMatchingResourceKey");

            Assert.Equal("Property With Property Name Matching Resource File", metadata.DisplayName);
        }

        [Fact]
        public void CreateMetadata_WithDisplayAttributeMatchingResourceKey_ReturnsResourceValue()
        {
            var model = new TestModel {PropertyWithDisplayAttributeMatchingResourceKey = "HelloWorld"};
            var provider = new ConventionalModelMetadataProvider(false);

            var metadata = provider.GetMetadataForProperty(() => model, model.GetType(),
                "PropertyWithDisplayAttributeMatchingResourceKey");

            Assert.Equal("Property With Display Name From Resource File", metadata.DisplayName);
        }
    }
}