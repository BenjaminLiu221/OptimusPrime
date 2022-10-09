namespace OptimusPrimeWeb.Models
{
    public interface IRandomIntegerGeneratorServices
    {
        public Task<GeneratedResults> Initiate(RandomIntegerGeneratorUserInput randomIntegerGeneratorUserInput);
    }

    public class RandomIntegerGeneratorServices : IRandomIntegerGeneratorServices
    {
        public async Task<GeneratedResults> Initiate(RandomIntegerGeneratorUserInput randomIntegerGeneratorUserInput)
        {
            Random rnd = new Random();
            var lengthOfArr = randomIntegerGeneratorUserInput.LengthOfArr;
            var maxInt = randomIntegerGeneratorUserInput.MaxInt;
            int[] intArr = new int[lengthOfArr];

            for (int i = 0; i < intArr.Length; i++)
            {
                int num = rnd.Next(1, maxInt);
                intArr[i] = num;
            }
            string[] strArr = Array.ConvertAll(intArr, a => a.ToString());
            string str = string.Join(" ", strArr);

            GeneratedResults generatedResults = new GeneratedResults()
            {
                RandomIntegerGeneratorUserInput = randomIntegerGeneratorUserInput,
                SpaceSeparatedIntegers = str
            };
            return generatedResults;
        }
    }
}
