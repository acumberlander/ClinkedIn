
using System;

namespace ClinkedIn.Models
{
    public class CreateClinkerRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
