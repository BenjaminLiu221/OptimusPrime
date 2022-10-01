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
            if (userInput.Characters.Any(char.IsDigit).Equals(false))
            {
                TempData["error"] = "Must contain a number(s).";
                ModelState.AddModelError(string.Empty, TempData["error"].ToString());
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            return View(userInput);
        }
    }
}
