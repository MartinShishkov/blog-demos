using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CleanControllers.Web.Models.Web
{
    public class SimpleFormPostModel
    {
        // We can't use our Person error codes here because of a compile time error.
        // We can try to create some workaround but it's going to get messy.
        [Required]
        [MinLength(3, ErrorMessage = "This has to be at least 3 chars long dammit")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "This has to be at least 3 chars long dammit")]
        public string LastName { get; set; }

        [Required]
        [Range(minimum: 18, maximum: 1000, ErrorMessage = "You have to be between 18 and 1000 years old")]
        public int Age { get; set; }

        [Required]
        public string[] Consent { get; set; }

        public bool ShouldCauseServerError => SimulateServerError != null && SimulateServerError.Contains("yes");

        public string[] SimulateServerError { get; set; }
    }
}