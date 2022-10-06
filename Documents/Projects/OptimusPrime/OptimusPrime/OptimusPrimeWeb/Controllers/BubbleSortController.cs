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
            Regex numRgx = new Regex("[0-9 ]");

            if (numRgx.IsMatch(userInput.Characters).Equals(false))
            {
                TempData["NumberError"] = "Must contain number(s) separated by a space.";
                ModelState.AddModelError(string.Empty, TempData["NumberError"].ToString());
            }

            if (Char.IsWhiteSpace(userInput.Characters, 0).Equals(true))
            {
                TempData["LeadingWhiteSpaceError"] = "First value must be a number NOT a space.";
                ModelState.AddModelError(string.Empty, TempData["LeadingWhiteSpaceError"].ToString());
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                string sortedList = Initiate(userInput.Characters);
                SortedResults sortedResults = new SortedResults
                {
                    UserInput = userInput,
                    SortedList = sortedList
                };
                return View(sortedResults);
            }
        }

        public static string Initiate(string stringOfNums)
        {
            string cleanedStringOfNums = Regex.Replace(stringOfNums, @"\s+", " ");
            string[] strArr = cleanedStringOfNums.Split(' ');
            int[] intArr = Array.ConvertAll(strArr, a => int.Parse(a));
            BubbleSort(intArr);
            string sortedNums = string.Join(",", intArr);
            return sortedNums;
        }

        public static void BubbleSort(int[] array)
        {
            for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            {
                for (int i = 0; i < partIndex; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(array, i, i + 1);
                    }
                }
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            if (i == j)
                return;
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
