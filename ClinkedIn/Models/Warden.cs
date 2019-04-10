using System;
using System.Collections.Generic;
using System.Text;

namespace ClinkedIn.Models
{
    public class Warden
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public Warden(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
