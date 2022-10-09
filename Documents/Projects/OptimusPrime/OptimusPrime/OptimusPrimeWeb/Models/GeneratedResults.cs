using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OptimusPrimeWeb.Models
{
    public class GeneratedResults
    {
        public RandomIntegerGeneratorUserInput RandomIntegerGeneratorUserInput { get; set; }
        [ValidateNever]
        public string SpaceSeparatedIntegers { get; set; }
    }
}
