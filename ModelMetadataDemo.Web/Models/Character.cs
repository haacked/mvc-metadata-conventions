using System.ComponentModel.DataAnnotations;

namespace ModelMetadataDemo.Web.Models {
    public class Character {
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "LastNameLabel")]
        [Required]
        public string LastName { get; set; }

        public int HitPoints { get; set; }

        [Display(Name = "The Level (from DisplayAttribute)")]
        public int Level { get; set; }

        public int ArmorClass { get; set; }
    }
}