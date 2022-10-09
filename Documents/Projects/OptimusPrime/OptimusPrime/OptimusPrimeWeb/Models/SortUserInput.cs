using System.ComponentModel.DataAnnotations;

namespace OptimusPrimeWeb.Models
{
    public class SortUserInput
    {
        [Required]
        public string Characters { get; set; }
    }
}
