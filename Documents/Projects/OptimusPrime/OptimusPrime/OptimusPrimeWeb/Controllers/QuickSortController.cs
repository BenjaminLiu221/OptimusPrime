using Microsoft.AspNetCore.Mvc;
using OptimusPrimeWeb.Models.Sort;
using OptimusPrimeWeb.Services;
using OptimusPrimeWeb.Validations;

namespace OptimusPrimeWeb.Controllers
{
    public class QuickSortController : Controller
    {
        private readonly IUserInputValidateConsumer _userInputValidateConsumer;
        private readonly IUserInputServices _userInputServices;

        public QuickSortController(IUserInputValidateConsumer userInputValidateConsumer, IUserInputServices userInputServices)
        {
            _userInputValidateConsumer = userInputValidateConsumer;
            _userInputServices = userInputServices;
        }

        public IActionResult Sort()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Sort(SortUserInput userInput)
        {
            var validationObj = await _userInputValidateConsumer.Validate(userInput.Characters);

            if (validationObj.Count > 0)
            {
                foreach (var validation in validationObj)
                {
                    TempData[$"{validation.Key}"] = $"{validation.Value}";
                    ModelState.AddModelError(string.Empty, TempData[$"{validation.Key}"].ToString());
                }
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var sortedResults = await _userInputServices.QuickSort(userInput);
                return View(sortedResults);
            }
        }
    }
}
