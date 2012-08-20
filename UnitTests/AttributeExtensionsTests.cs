using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ModelMetadataExtensions;
using ModelMetadataExtensions.Extensions;
using Moq;
using UnitTests.Resources;
using Xunit;

namespace UnitTests {
    public class AttributeExtensionsTests {
        [Fact]
        public void First_WithAttributeReturnedByAttributeProvider_ReturnsAttribute() {
            // arrange
            var attributeProvider = new Mock<ICustomAttributeProvider>();
            var attribute = new MetadataConventionsAttribute { ResourceType = typeof(TestResources) };
            attributeProvider.Setup(a => a.GetCustomAttributes(typeof(MetadataConventionsAttribute), true)).Returns(new[] { attribute });

            // act
            var retrievedAttribute = attributeProvider.Object.First<MetadataConventionsAttribute>();

            // assert
            Assert.Equal(typeof(TestResources), retrievedAttribute.ResourceType);
        }

        [Fact]
        public void First_WithNoMatchingAttribute_ReturnsNull() {
            // arrange
            var attributeProvider = new Mock<ICustomAttributeProvider>();
            var attribute = new MetadataConventionsAttribute { ResourceType = typeof(TestResources) };
            attributeProvider.Setup(a => a.GetCustomAttributes(typeof(MetadataConventionsAttribute), true)).Returns(new[] { attribute });

            // act
            var retrievedAttribute = attributeProvider.Object.First<DisplayAttribute>();

            // assert
            Assert.Null(retrievedAttribute);
        }
    }
}
