using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace legacy_business_logic.Validators
{
    public class SocialIdentifierValidator
    {
        public static void Validate(string socialIdentifier)
        {
            // Is valid when all digits are equals
            bool isValid = socialIdentifier.Distinct().Count() == 1;
            if (!isValid)
            {
                throw new ValidationException("Social identifier is incorrect.");
            }
        }
    }
}