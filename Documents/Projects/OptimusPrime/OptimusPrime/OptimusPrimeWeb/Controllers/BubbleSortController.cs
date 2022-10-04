using Microsoft.AspNetCore.Mvc;
using OptimusPrimeWeb.Models;
using System.Text.RegularExpressions;

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
            Regex rgx = new Regex("[0-9],");

            if (rgx.IsMatch(userInput.Characters).Equals(false))
            {
                TempData["Error"] = "Must contain numbers separated by a comma.";
                ModelState.AddModelError(string.Empty, TempData["Error"].ToString());
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                string sortedList = Initiate(userInput.Characters).ToString();
                SortedResults sortedResults = new SortedResults
                {
                    UserInput = userInput,
                    SortedList = sortedList
                };
                return View(sortedResults);
            }
        }

        public async Task<string> Initiate(string listOfNum)
        {
            string sortedList = "";
            return sortedList;
        }
    }
}
