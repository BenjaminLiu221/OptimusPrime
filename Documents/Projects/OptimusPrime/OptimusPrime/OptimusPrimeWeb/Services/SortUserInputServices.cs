﻿using OptimusPrimeWeb.Models.Sort;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace OptimusPrimeWeb.Services
{
    public interface IUserInputServices
    {
        public Task<SortedResults> BubbleSort(SortUserInput userInput);
        public Task<SortedResults> SelectionSort(SortUserInput userInput);
        public Task<SortedResults> InsertionSort(SortUserInput userInput);
        public Task<SortedResults> ShellSort(SortUserInput userInput);
        public Task<SortedResults> MergeSort(SortUserInput userInput);
        public Task<SortedResults> QuickSort(SortUserInput userInput);
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

        public async Task<SortedResults> InsertionSort(SortUserInput userInput)
        {
            var intArr = Initiate(userInput.Characters);
            timer.Start();
            InsertionSort(intArr);
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

        public async Task<SortedResults> ShellSort(SortUserInput userInput)
        {
            var intArr = Initiate(userInput.Characters);
            timer.Start();
            ShellSort(intArr);
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

        public async Task<SortedResults> MergeSort(SortUserInput userInput)
        {
            var intArr = Initiate(userInput.Characters);
            timer.Start();
            MergeSort(intArr);
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

        public async Task<SortedResults> QuickSort(SortUserInput userInput)
        {
            var intArr = Initiate(userInput.Characters);
            timer.Start();
            QuickSort(intArr);
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

        public static void InsertionSort(int[] array)
        {
            for (int partIndex = 1; partIndex < array.Length; partIndex++)
            {
                int curUnsorted = array[partIndex];
                int i = 0;
                for (i = partIndex; i > 0 && array[i - 1] > curUnsorted; i--)
                {
                    array[i] = array[i - 1];
                }

                array[i] = curUnsorted;
            }
        }

        public static void ShellSort(int[] array)
        {
            int gap = 1;
            while (gap < array.Length / 3)
                gap = 3 * gap + 1;

            while (gap >= 1)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    for (int j = i; j >= gap && array[j] < array[j - gap]; j -= gap)
                    {
                        Swap(array, j, j - gap);
                    }
                }
                gap /= 3;
            }
        }

        public static void MergeSort(int[] array)
        {
            int[] aux = new int[array.Length];
            Sort(0, array.Length - 1);

            void Sort(int low, int high)
            {
                if (high <= low)
                    return;

                int mid = (high + low) / 2;
                Sort(low, mid);
                Sort(mid+1, high);
                Merge(low, mid, high);
            }

            void Merge(int low, int mid, int high)
            {
                if (array[mid] <= array[mid + 1])
                    return;
                int i = low;
                int j = mid + 1;

                Array.Copy(array, low, aux, low, high - low - 1);

                for (int k = low; k <= high; k++)
                {
                    if (i > mid)
                        array[k] = aux[j++];
                    else if (j > high)
                        array[k] = aux[i++];
                    else if (aux[j] < aux[i])
                        array[k] = aux[j++];
                    else
                        array[k] = aux[i++];
                }
            }
        }

        public static void QuickSort(int[] array)
        {
            Sort(0, array.Length - 1);

            void Sort(int low, int high)
            {
                if (high <= low)
                    return;
                int j = Partition(low, high);
                Sort(low, j - 1);
                Sort(j + 1, high);
            }

            int Partition(int low, int high)
            {
                int i = low;
                int j = high + 1;

                int pivot = array[low];
                while (true)
                {
                    while (array[++i] < pivot)
                    {
                        if (i == high)
                            break;
                    }

                    while (pivot < array[--j])
                    {
                        if (j == low)
                            break;
                    }

                    if (i >= j)
                        break;

                    Swap(array, i, j);
                }
                Swap(array, low, j);
                return j;
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
