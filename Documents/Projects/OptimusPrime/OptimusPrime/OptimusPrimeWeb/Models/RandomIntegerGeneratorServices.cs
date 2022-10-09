namespace OptimusPrimeWeb.Models
{
    public interface IRandomIntegerGeneratorServices
    {
        public Task<RandomIntegerGeneratorResults> Initiate(RandomIntegerGeneratorResults randomIntegerGeneratorResults);
    }

    public class RandomIntegerGeneratorServices : IRandomIntegerGeneratorServices
    {
        public async Task<RandomIntegerGeneratorResults> Initiate(RandomIntegerGeneratorResults randomIntegerGeneratorResults)
        {
            Random rnd = new Random();
            var lengthOfArr = randomIntegerGeneratorResults.LengthOfArr;
            var maxInt = randomIntegerGeneratorResults.MaxInt;
            int[] intArr = new int[lengthOfArr];

            for (int i = 0; i < intArr.Length; i++)
            {
                int num = rnd.Next(1, maxInt);
                intArr[i] = num;
            }
            string[] strArr = Array.ConvertAll(intArr, a => a.ToString());
            string str = string.Join(" ", strArr);
            randomIntegerGeneratorResults.SpaceSeparatedIntegers = str;
            return randomIntegerGeneratorResults;
        }
    }
}
