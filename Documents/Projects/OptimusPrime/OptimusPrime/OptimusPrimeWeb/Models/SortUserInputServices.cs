using System.Diagnostics;
using System.Text.RegularExpressions;

namespace OptimusPrimeWeb.Models
{
    public interface IUserInputServices
    {
        public Task<SortedResults> BubbleSort(SortUserInput userInput);
        public Task<SortedResults> SelectionSort(SortUserInput userInput);
    }

    public class SortUserInputServices : IUserInputServices
    {
        Stopwatch timer = new Stopwatch();
        public async Task<SortedResults> BubbleSort(SortUserInput userInput)
        {
            var intArr = Initiate(userInput.Characters);
            timer.Start();
            BubbleSort(intArr);
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            string timeElapsed = $"Time Elapsed: {timeTaken.ToString()}";
            string sortedList = Conclude(intArr);
            SortedResults sortedResults = new SortedResults
            {
                UserInput = userInput,
                SortedList = sortedList,
                TimeElapsed = timeElapsed
            };
            return sortedResults;
        }

        public async Task<SortedResults> SelectionSort(SortUserInput userInput)
        {
            var intArr = Initiate(userInput.Characters);
            timer.Start();
            SelectionSort(intArr);
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            string timeElapsed = $"Time Elapsed: {timeTaken.ToString()}";
            string sortedList = Conclude(intArr);
            SortedResults sortedResults = new SortedResults
            {
                UserInput = userInput,
                SortedList = sortedList,
                TimeElapsed = timeElapsed
            };
            return sortedResults;
        }

        public static int[] Initiate(string stringOfNums)
        {
            string cleanedStringOfNums = Regex.Replace(stringOfNums, @"\s+", " ");
            string[] strArr = cleanedStringOfNums.Split(' ');
            int[] intArr = Array.ConvertAll(strArr, a => int.Parse(a));
            return intArr;
        }

        public static string Conclude(int[] intArr)
        {
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

        public static void SelectionSort(int[] array)
        {
            for (int partIndex = array.Length-1; partIndex > 0; partIndex--)
            {
                int largestAt = 0;
                for (int i = 1; i <= partIndex; i++)
                {
                    if (array[i] > array[largestAt])
                    {
                        largestAt = i;
                    }
                }
                Swap(array, largestAt, partIndex);
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
