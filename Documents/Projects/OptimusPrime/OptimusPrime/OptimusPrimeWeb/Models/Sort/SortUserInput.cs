using System.ComponentModel.DataAnnotations;

namespace OptimusPrimeWeb.Models.Sort
{
    public class SortUserInput
    {
        [Required]
        public string Characters { get; set; }
    }
}
