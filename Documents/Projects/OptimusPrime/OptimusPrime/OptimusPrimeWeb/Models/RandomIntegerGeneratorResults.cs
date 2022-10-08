using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OptimusPrimeWeb.Models
{
    public class RandomIntegerGeneratorResults
    {
        [Required]
        [Range(1,10000)]
        public int LengthOfArr { get; set; }
        [Required]
        [Range(1,1000)]
        public int MaxInt { get; set; }
        [ValidateNever]
        public string SpaceSeparatedIntegers { get; set; }
    }
}
