using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OptimusPrimeWeb.Models.RandomIntegerGenerator
{
    public class GeneratedResults
    {
        public RandomIntegerGeneratorUserInput RandomIntegerGeneratorUserInput { get; set; }
        [ValidateNever]
        public string SpaceSeparatedIntegers { get; set; }
    }
}
