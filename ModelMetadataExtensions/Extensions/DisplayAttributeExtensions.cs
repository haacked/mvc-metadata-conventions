using System.ComponentModel.DataAnnotations;

namespace ModelMetadataExtensions.Extensions
{
    public static class DisplayAttributeExtensions
    {
        public static DisplayAttribute Copy(this DisplayAttribute attribute)
        {
            if (attribute == null)
            {
                return null;
            }

            // DisplayAttribute is sealed, so it's safe to copy.
            var copy = new DisplayAttribute
            {
                Name = attribute.Name,
                GroupName = attribute.GroupName,
                Description = attribute.Description,
                ResourceType = attribute.ResourceType,
                ShortName = attribute.ShortName,
                Prompt = attribute.Prompt
            };

            return copy;
        }

        public static bool CanSupplyDisplayName(this DisplayAttribute attribute)
        {
            return attribute != null
                   && attribute.ResourceType != null
                   && !string.IsNullOrEmpty(attribute.Name);
        }
    }
}