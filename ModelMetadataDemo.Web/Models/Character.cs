using System.ComponentModel.DataAnnotations;
using MetadataExtensionsDemo.Web.Resources;

namespace ModelMetadataDemo.Web.Models {
    public class Character {
        [Display(ResourceType = typeof(Resource))]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Character_LastName")]
        [Required]
        public string LastName { get; set; }

        public int HitPoints { get; set; }

        [Display(Name = "The Level (from DisplayAttribute)")]
        public int Level { get; set; }
    }
}