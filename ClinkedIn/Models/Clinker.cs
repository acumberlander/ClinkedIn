using System;
using System.Collections.Generic;
using System.Text;

namespace ClinkedIn.Models
{
    public class Clinker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public int PrisonId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<int> Interests { get; set; }
        public List<int> Services { get; set; }

        public Clinker(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
