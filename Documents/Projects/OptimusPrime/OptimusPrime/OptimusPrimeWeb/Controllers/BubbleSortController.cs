using Microsoft.AspNetCore.Mvc;
using OptimusPrimeWeb.Models;

namespace OptimusPrimeWeb.Controllers
{
    public class BubbleSortController : Controller
    {
        public IActionResult Sort()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Sort(UserInput userInput)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return View(userInput);
        }
    }
}
