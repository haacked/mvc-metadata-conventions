using System.ComponentModel.DataAnnotations;
using ModelMetadataExtensions.Extensions;
using Xunit;

namespace UnitTests
{
    public class DisplayAttributeExtensionsTests
    {
        [Fact]
        public void Copy_WithNull_ReturnsNull()
        {
            DisplayAttribute displayAttribute = null;

            var copy = displayAttribute.Copy();

            Assert.Null(copy);
        }

        [Fact]
        public void Copy_WithDisplayAttribute_ReturnsNewInstance()
        {
            var displayAttribute = new DisplayAttribute();

            var copy = displayAttribute.Copy();

            Assert.NotSame(displayAttribute, copy);
        }

        [Fact]
        public void Copy_WithDisplayAttribute_ReturnsNewInstanceWithCopiedProperties()
        {
            var displayAttribute = new DisplayAttribute
            {
                Name = "TheName",
                Description = "TheDescription",
                ResourceType = typeof (object)
            };

            var copy = displayAttribute.Copy();

            Assert.Equal(displayAttribute.Name, copy.Name);
        }

        [Fact]
        public void CanSupplyDisplayName_WithNullAttribute_ReturnsFalse()
        {
            DisplayAttribute attribute = null;

            Assert.False(attribute.CanSupplyDisplayName());
        }

        [Fact]
        public void CanSupplyDisplayName_WithEmptyAttribute_ReturnsFalse()
        {
            var attribute = new DisplayAttribute();

            Assert.False(attribute.CanSupplyDisplayName());
        }

        [Fact]
        public void CanSupplyDisplayName_WithAttributeOnlyHavingName_ReturnsFalse()
        {
            var attribute = new DisplayAttribute {Name = "Test"};

            Assert.False(attribute.CanSupplyDisplayName());
        }

        [Fact]
        public void CanSupplyDisplayName_WithAttributeHavingNameAndResourceType_ReturnsTrue()
        {
            var attribute = new DisplayAttribute {Name = "Test", ResourceType = typeof (object)};

            Assert.True(attribute.CanSupplyDisplayName());
        }
    }
}