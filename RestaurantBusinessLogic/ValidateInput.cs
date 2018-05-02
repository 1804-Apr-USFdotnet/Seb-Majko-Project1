using Newtonsoft.Json;
using RestaurantBusinessLogic.CustomExceptions;

namespace RestaurantBusinessLogic
{
    /// <summary>
    /// Validates command syntax. Possible commands:
    ///     1. "reviews [string]"
    ///     2. "restaurants [optional string]"
    /// </summary>
    internal static class ValidateInput
    {
        internal static void Validate(params string[] input)
        {
            if (input.Length == 0) throw new InvalidInputException(); // no command given
            switch (input[0])
            {
                case "reviews":
                    if (input.Length == 1) throw new InvalidParameterException(); // no parameters exist
                    break;
                case "restaurants":
                    break;
                default:
                    throw new InvalidCommandException(); // invalid command
            }
        }
    }
}
