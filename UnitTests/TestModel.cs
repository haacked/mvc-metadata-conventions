using System.ComponentModel.DataAnnotations;
using ModelMetadataExtensions;
using UnitTests.Resources;

namespace UnitTests
{
    [MetadataConventions(ResourceType = typeof (TestResources))]
    public class TestModel
    {
        public int Id { get; set; }

        [Display(Name = "Property That Has A Display Attribute With A Name")]
        public string PropertyWithDisplayAttributeHavingName { get; set; }

        [Display(Name = "TestModel_PropertyWithDisplayAttributeMatchingResourceKey")]
        public string PropertyWithDisplayAttributeMatchingResourceKey { get; set; }

        [Display(Name = "PropertyWithFullDisplayAttribute", ResourceType = typeof (AnotherTestResources))]
        public string PropertyWithFullDisplayAttribute { get; set; }

        public string PropertyWithMatchingResourceKey { get; set; }
    }
}