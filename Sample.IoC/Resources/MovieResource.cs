using System.ComponentModel.DataAnnotations;

namespace Sample.IoC.Resources
{
    public class MovieResource
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Genre { get; set; }
    }
}
