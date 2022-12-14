using System.Text.RegularExpressions;

namespace OptimusPrimeWeb.Validations
{
    public interface IUserInputValidateConsumer
    {
        public Task<Dictionary<string, string>> Validate(string characters);
    }

    public class SortUserInputValidationConsumer : IUserInputValidateConsumer
    {
        public async Task<Dictionary<string,string>> Validate(string characters)
        {
            Regex numRgx = new Regex("^[0-9 ]*$");

            Dictionary<string, string> ValidationObj = new Dictionary<string, string>();

            if (!numRgx.IsMatch(characters).Equals(true))
            {
                ValidationObj.Add("NumberError", "Must contain number(s) separated by a space.");
            }
            
            if (!Char.IsWhiteSpace(characters, 0).Equals(false))
            {
                ValidationObj.Add("LeadingWhiteSpaceError", "First value must be a number NOT a space.");
            }

            if (!Char.IsWhiteSpace(characters, characters.Length - 1).Equals(false))
            {
                ValidationObj.Add("TrailingWhiteSpaceError", "Last value must be a number NOT a space.");
            }

            return ValidationObj;
        }
    }
}
