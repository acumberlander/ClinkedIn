using System;
using System.Collections.Generic;

namespace ClinkedIn.Models
{
    public class Clinker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public bool IsPrisoner { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Clinker(string name, string password, int age, bool isPrisoner, DateTime releaseDate)
        {
            Name = name;
            Password = password;
            Age = age;
            IsPrisoner = isPrisoner;
            ReleaseDate = releaseDate;
        }

    }
}
