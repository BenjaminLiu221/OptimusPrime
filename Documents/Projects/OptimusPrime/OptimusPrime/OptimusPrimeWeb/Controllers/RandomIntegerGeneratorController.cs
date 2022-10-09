using Microsoft.AspNetCore.Mvc;
using OptimusPrimeWeb.Models;

namespace OptimusPrimeWeb.Controllers
{
    public class RandomIntegerGeneratorController : Controller
    {
        private readonly IRandomIntegerGeneratorServices _randomIntegerGeneratorServices;

        public RandomIntegerGeneratorController(IRandomIntegerGeneratorServices randomIntegerGeneratorServices)
        {
            _randomIntegerGeneratorServices = randomIntegerGeneratorServices;
        }

        public IActionResult Generate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Generate(RandomIntegerGeneratorResults randomIntegerGeneratorResults)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var results = await _randomIntegerGeneratorServices.Initiate(randomIntegerGeneratorResults);
                return View(results);
            }
        }
    }
}
