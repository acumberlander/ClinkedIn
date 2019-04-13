
namespace ClinkedIn.Models
{
    public class CreateWardenRequestValidator
    {
        public bool Validate(CreateWardenRequest requestToValidate)
        {
            return string.IsNullOrEmpty(requestToValidate.Name)
                || string.IsNullOrEmpty(requestToValidate.Password);
        }
    }
}
