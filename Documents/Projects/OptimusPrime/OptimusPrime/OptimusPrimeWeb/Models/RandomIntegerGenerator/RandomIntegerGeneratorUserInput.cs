using System.ComponentModel.DataAnnotations;

namespace OptimusPrimeWeb.Models.RandomIntegerGenerator
{
    public class RandomIntegerGeneratorUserInput
    {
        [Required]
        [Range(1, 10000)]
        public int LengthOfArr { get; set; }
        [Required]
        [Range(1, 1000)]
        public int MaxInt { get; set; }
    }
}
