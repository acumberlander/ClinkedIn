using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class CreateClinkerRequestValidator
    {
        public bool Validate(CreateClinkerRequest requestToValidate)
        {
            return string.IsNullOrEmpty(requestToValidate.Name)
                || string.IsNullOrEmpty(requestToValidate.Password);
        }
    }
}
