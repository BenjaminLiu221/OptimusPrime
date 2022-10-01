using System.ComponentModel.DataAnnotations;

namespace OptimusPrimeWeb.Models
{
    public class UserInput
    {
        [Required]
        public string Characters { get; set; }
    }
}
