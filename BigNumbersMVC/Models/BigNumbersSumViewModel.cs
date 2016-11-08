using System.ComponentModel.DataAnnotations;

namespace BigNumbersMVC.Models
{
    public class BigNumbersSumViewModel
    {
        [Required]
        [RegularExpression(@"^-?[0-9]+$", ErrorMessage = "Number 1 is not a number")]
        public string Number1 { get; set; }

        [Required]
        [RegularExpression(@"^-?[0-9]+$", ErrorMessage = "Number 2 is not a number")]
        public string Number2 { get; set; }

        public string Result { get; set; }
    }
}
