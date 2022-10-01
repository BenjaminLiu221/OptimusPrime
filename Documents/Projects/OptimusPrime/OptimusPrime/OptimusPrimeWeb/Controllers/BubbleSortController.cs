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
            if (!userInput.Characters.Any(char.IsDigit).Equals(true))
            {
                TempData["NumberError"] = "Must contain a number(s).";
                ModelState.AddModelError(string.Empty, TempData["NumberError"].ToString());
            }

            if (!userInput.Characters.Any(a => !Char.IsLetterOrDigit(a)).Equals(true) || (!userInput.Characters.Any(b => !Char.IsLetter(b))))
            {
                TempData["CharacterError"] = "Must NOT contain letter(s) or special character(s).";
                ModelState.AddModelError(string.Empty, TempData["CharacterError"].ToString());
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            return View(userInput);
        }
    }
}
