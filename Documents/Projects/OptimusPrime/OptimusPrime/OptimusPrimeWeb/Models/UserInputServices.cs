using System.Text.RegularExpressions;

namespace OptimusPrimeWeb.Models
{
    public interface IUserInputServices
    {
        public Task<SortedResults> BubbleSort(UserInput userInput);
        public Task<SortedResults> SelectionSort(UserInput userInput);
    }

    public class UserInputServices : IUserInputServices
    {
        public async Task<SortedResults> SelectionSort(UserInput userInput)
        {
            return new SortedResults();
        }
        public async Task<SortedResults> BubbleSort(UserInput userInput)
        {
            var intArr = Initiate(userInput.Characters);
            BubbleSort(intArr);
            string sortedList = Conclude(intArr);
            SortedResults sortedResults = new SortedResults
            {
                UserInput = userInput,
                SortedList = sortedList
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
